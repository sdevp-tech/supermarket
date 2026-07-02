using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginForm1
{
    public partial class الفئات : Form
    {
        private string connectionString = "Data Source=DESKTOP-J6KA8B8;Initial Catalog=mini_supermarket;Integrated Security=True";
        private bool isEditMode = false;
        private int currentCategoryId = 0;

        public الفئات()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            SetFormState(false);
        }

        private void LoadCategories()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Get all categories
                    DataTable categories = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT CategoryID, CategoryName, ParentCategoryID FROM Categories", conn);
                    adapter.Fill(categories);

                    // Clear existing nodes
                    treeViewCategories.Nodes.Clear();
                    cboParentCategory.Items.Clear();
                    cboParentCategory.Items.Add("(None)");

                    // Build tree structure
                    foreach (DataRow row in categories.Rows)
                    {
                        if (row["ParentCategoryID"] == DBNull.Value)
                        {
                            TreeNode node = new TreeNode(row["CategoryName"].ToString());
                            node.Tag = row["CategoryID"];
                            treeViewCategories.Nodes.Add(node);
                            cboParentCategory.Items.Add(row["CategoryName"]);
                            AddChildNodes(node, categories);
                        }
                    }

                    treeViewCategories.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        private void AddChildNodes(TreeNode parentNode, DataTable categories)
        {
            foreach (DataRow row in categories.Rows)
            {
                if (row["ParentCategoryID"] != DBNull.Value &&
                    Convert.ToInt32(row["ParentCategoryID"]) == Convert.ToInt32(parentNode.Tag))
                {
                    TreeNode childNode = new TreeNode(row["CategoryName"].ToString());
                    childNode.Tag = row["CategoryID"];
                    parentNode.Nodes.Add(childNode);
                    cboParentCategory.Items.Add(row["CategoryName"]);
                    AddChildNodes(childNode, categories);
                }
            }
        }

        private void treeViewCategories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewCategories.SelectedNode != null)
            {
                currentCategoryId = Convert.ToInt32(treeViewCategories.SelectedNode.Tag);
                txtCategoryName.Text = treeViewCategories.SelectedNode.Text;

                // Find parent category name
                string parentName = FindParentName(treeViewCategories.SelectedNode);
                cboParentCategory.SelectedItem = string.IsNullOrEmpty(parentName) ? "(None)" : parentName;
            }
        }

        private string FindParentName(TreeNode node)
        {
            if (node.Parent != null)
            {
                return node.Parent.Text;
            }
            return string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetFormState(true);
            isEditMode = false;
            currentCategoryId = 0;
            txtCategoryName.Clear();
            cboParentCategory.SelectedIndex = 0;
            txtCategoryName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (treeViewCategories.SelectedNode == null)
            {
                MessageBox.Show("Please select a category to edit.");
                return;
            }

            SetFormState(true);
            isEditMode = true;
            txtCategoryName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (treeViewCategories.SelectedNode == null)
            {
                MessageBox.Show("Please select a category to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this category and all its subcategories?",
                "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Check if category has products
                        SqlCommand checkCmd = new SqlCommand(
                            "SELECT COUNT(*) FROM Products WHERE CategoryID = @CategoryID", conn);
                        checkCmd.Parameters.AddWithValue("@CategoryID", currentCategoryId);
                        int productCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (productCount > 0)
                        {
                            MessageBox.Show("Cannot delete category that contains products.");
                            return;
                        }

                        // Delete category and subcategories recursively
                        DeleteCategoryAndChildren(conn, currentCategoryId);

                        LoadCategories();
                        SetFormState(false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting category: " + ex.Message);
                }
            }
        }

        private void DeleteCategoryAndChildren(SqlConnection conn, int categoryId)
        {
            // First delete all child categories
            SqlCommand getChildrenCmd = new SqlCommand(
                "SELECT CategoryID FROM Categories WHERE ParentCategoryID = @ParentID", conn);
            getChildrenCmd.Parameters.AddWithValue("@ParentID", categoryId);

            using (SqlDataReader reader = getChildrenCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int childId = reader.GetInt32(0);
                    DeleteCategoryAndChildren(conn, childId);
                }
            }

            // Then delete the category itself
            SqlCommand deleteCmd = new SqlCommand(
                "DELETE FROM Categories WHERE CategoryID = @CategoryID", conn);
            deleteCmd.Parameters.AddWithValue("@CategoryID", categoryId);
            deleteCmd.ExecuteNonQuery();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    object parentId = GetSelectedParentId();

                    if (isEditMode)
                    {
                        // Update existing category
                        SqlCommand cmd = new SqlCommand(
                            "UPDATE Categories SET CategoryName = @Name, ParentCategoryID = @ParentID " +
                            "WHERE CategoryID = @CategoryID", conn);

                        cmd.Parameters.AddWithValue("@Name", txtCategoryName.Text);
                        cmd.Parameters.AddWithValue("@ParentID", parentId);
                        cmd.Parameters.AddWithValue("@CategoryID", currentCategoryId);

                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // Insert new category
                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Categories (CategoryName, ParentCategoryID) " +
                            "VALUES (@Name, @ParentID); SELECT SCOPE_IDENTITY();", conn);

                        cmd.Parameters.AddWithValue("@Name", txtCategoryName.Text);
                        cmd.Parameters.AddWithValue("@ParentID", parentId);

                        currentCategoryId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    LoadCategories();
                    SetFormState(false);

                    // Select the newly added/edited category
                    SelectNodeByTag(treeViewCategories.Nodes, currentCategoryId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving category: " + ex.Message);
            }
        }

        private object GetSelectedParentId()
        {
            if (cboParentCategory.SelectedIndex <= 0)
                return DBNull.Value;

            // Find the category ID by name
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT CategoryID FROM Categories WHERE CategoryName = @Name", conn);
                cmd.Parameters.AddWithValue("@Name", cboParentCategory.SelectedItem.ToString());
                object result = cmd.ExecuteScalar();
                return result ?? DBNull.Value;
            }
        }

        private bool SelectNodeByTag(TreeNodeCollection nodes, int tagValue)
        {
            foreach (TreeNode node in nodes)
            {
                if (Convert.ToInt32(node.Tag) == tagValue)
                {
                    treeViewCategories.SelectedNode = node;
                    return true;
                }
                if (SelectNodeByTag(node.Nodes, tagValue))
                {
                    return true;
                }
            }
            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetFormState(false);
            if (treeViewCategories.SelectedNode != null)
            {
                treeViewCategories_AfterSelect(null,
                    new TreeViewEventArgs(treeViewCategories.SelectedNode));
            }
        }

        private void SetFormState(bool editing)
        {
            treeViewCategories.Enabled = !editing;
            btnAdd.Enabled = !editing;
            btnEdit.Enabled = !editing && treeViewCategories.SelectedNode != null;
            btnDelete.Enabled = !editing && treeViewCategories.SelectedNode != null;

            txtCategoryName.Enabled = editing;
            cboParentCategory.Enabled = editing;
            btnSave.Enabled = editing;
            btnCancel.Enabled = editing;
        }
    }
}