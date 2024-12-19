using System;
using System.Data.OleDb;
using System.Windows.Forms;
using BrewBreeze.Forms;

namespace BrewBreeze
{
    public partial class LoginForm : FormShadow
    {
        private string dbConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BrewBreezeDB.accdb;";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Username and password are required.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var connection = new OleDbConnection(dbConn))
            {
                connection.Open();

                string query = "SELECT [User ID], [Name], [Username], [Password], [Role] FROM Users WHERE [Username] = @username";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);

                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string storedName = reader["Name"].ToString();
                    string storedUsername = reader["Username"].ToString();
                    string storedPassword = reader["Password"].ToString();
                    int userId = Convert.ToInt32(reader["User ID"]);
                    string roleName = reader["Role"].ToString();

                    if (storedUsername == username && password == storedPassword)
                    {
                        MessageBox.Show($"Welcome, {storedUsername}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        AdminPanel mainForm = new AdminPanel(roleName, storedName);
                        mainForm.Show();

                        mainForm.FormClosed += (s, args) => this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password. Please try again.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Username does not exist. Please try again.", "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                connection.Close();
            }
        }

        private void lblForgetPassword_Click(object sender, EventArgs e)
        {
            PasswordRecovery recoveryForm = new PasswordRecovery();
            recoveryForm.ShowDialog();
        }

        private void ckShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !ckShowHidePassword.Checked;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}
