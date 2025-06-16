using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APS0605
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Initial password field configuration
            guna2TextBox2.PasswordChar = '•'; // Sets the mask character for password
            guna2TextBox2.IconRight = Properties.Resources.view; // Home icon (open eye)
        }

        // Login button click event
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Simple credential check (user: "Login", password: "Password")
            if (guna2TextBox1.Text == "Login" && guna2TextBox2.Text == "Senha")
            {
                // Authentication successful:
                Form2 newForm = new Form2(); // Create an instance of the next form
                newForm.Show();             // Show the new form
                this.Hide();               // Hide the login form
            }
            else
            {
                // Authentication failed:
                MessageBox.Show("Login ou senha incorretos!", "Erro de Autenticação",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Control variable for password visibility
        private bool visiblePassword = false;

        // Evento de clique no ícone do campo de senha
        private void guna2TextBox2_IconRightClick(object sender, EventArgs e)
        {
            // Toggle the visibility state
            visiblePassword = !visiblePassword;

            if (visiblePassword)
            {
                // Show the password text
                guna2TextBox2.PasswordChar = '\0'; // Remove the mask
                guna2TextBox2.IconRight = Properties.Resources.hide; // Closed eye icon
            }
            else
            {
                // Hide the password text
                guna2TextBox2.PasswordChar = '•'; //Apply mask
                guna2TextBox2.IconRight = Properties.Resources.view; // Open eye icon
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}