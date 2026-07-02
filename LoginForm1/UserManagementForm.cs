using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace LoginForm1
{
    public partial class UserManagementForm : Form
    {
        public UserManagementForm()
        {
            InitializeComponent();
            LoadUsers();
            SetupDataGridView();
            cmbUserType.Items.AddRange(new string[] { "Admin", "Manager", "Cashier" });
        }
        private void SetupDataGridView()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.Columns.Clear();

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UserID",
                HeaderText = "رقم المستخدم",
                Name = "colID",
                Width = 150
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Username",
                HeaderText = "اسم المستخدم",
                Name = "colUsername",
                Width = 200
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UserType",
                HeaderText = "نوع المستخدم",
                Name = "colUserType",
                Width = 100
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IsActive",
                HeaderText = "المستخدم نشط",
                Name = "colIsActive",
                Width = 150
            });
        }
        private void loadTheme()
        {
            foreach (Control btns in this.Controls)
            {

                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;

                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label1.ForeColor = ThemeColor.SecondaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;


        }


        private void LoadUsers()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT UserID, Username, UserType, IsActive FROM Users";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvUsers.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username is required!");
                return;
            }

            if (cmbUserType.SelectedIndex == -1)
            {
                MessageBox.Show("Select a user type!");
                return;
            }

            string hashedPassword = SecurityHelper.HashPassword(txtPassword.Text);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Users (Username, UserType, PasswordHash) " +
                    "VALUES (@Username, @UserType, @PasswordHash)", conn);

                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@UserType", cmbUserType.SelectedItem);
                cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                try
                {
                    cmd.ExecuteNonQuery();
                    LoadUsers();
                    ClearFields();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user first!");
                return;
            }

            int userID = (int)dgvUsers.SelectedRows[0].Cells["colID"].Value;
            string newPassword = SecurityHelper.HashPassword(txtPassword.Text);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Users SET Username = @Username, UserType = @UserType, " +
                    "PasswordHash = @PasswordHash WHERE UserID = @UserID", conn);

                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@UserType", cmbUserType.SelectedItem);
                cmd.Parameters.AddWithValue("@PasswordHash", newPassword);
                cmd.Parameters.AddWithValue("@UserID", userID);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("خطا: يرجاء تعبئة جميع الخانات  " + ex.Message);
                }
                LoadUsers();
                ClearFields();
                try
                {
                    cmd.ExecuteNonQuery();
                    LoadUsers();
                    ClearFields();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;

            int userID = (int)dgvUsers.SelectedRows[0].Cells["colID"].Value;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Users WHERE UserID = @UserID", conn);
                cmd.Parameters.AddWithValue("@UserID", userID);
                try
                {
                    cmd.ExecuteNonQuery();
                    LoadUsers();
                    ClearFields();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvUsers.SelectedRows[0];
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                cmbUserType.SelectedItem = row.Cells["UserType"].Value.ToString();
                txtPassword.Clear();
            }
        }

        private void ClearFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            cmbUserType.SelectedIndex = -1;
        }



        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            loadTheme();
        }
    }
}