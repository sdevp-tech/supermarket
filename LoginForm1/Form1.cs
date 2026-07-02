using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LoginForm1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password!");
                return;
            }

            string hashedPassword = SecurityHelper.HashPassword(password);


            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT UserID, UserType, PasswordHash FROM Users WHERE Username = @Username", conn);
                    cmd.Parameters.AddWithValue("@Username", username);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        string storedHash = reader["PasswordHash"].ToString();
                        if (hashedPassword == storedHash)
                        {
                            CurrentUser.UserID = (int)reader["UserID"];
                            CurrentUser.UserType = reader["UserType"].ToString();
                            this.Hide();

                            if (CurrentUser.UserType == "Cashier")
                            {
                                new POS().Show();
                            }
                            else
                            {
                                new واجهة_المشرف().Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid credentials!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("User not found!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserManagementForm user = new UserManagementForm();
            user.Show();
        }


        // عند إغلاق التطبيق

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            BackupDatabase();
        }

        private void BackupDatabase()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("EXEC [dbo].[BackupDatabaseNow]", conn);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("تم إنشاء نسخة احتياطية بنجاح!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("فشل النسخ الاحتياطي: " + (ex.Message));
            }
        }










    }
}
