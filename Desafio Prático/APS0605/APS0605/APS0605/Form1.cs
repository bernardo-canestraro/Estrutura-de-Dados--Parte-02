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
            // Configuração inicial do campo de senha
            guna2TextBox2.PasswordChar = '•'; // Define o caractere de máscara para senha
            guna2TextBox2.IconRight = Properties.Resources.view; // Ícone inicial (olho aberto)
        }

        // Evento de clique no botão de login
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Verificação simples de credenciais (usuário: "Login", senha: "Senha")
            if (guna2TextBox1.Text == "Login" && guna2TextBox2.Text == "Senha")
            {
                // Autenticação bem-sucedida:
                Form2 newForm = new Form2(); // Cria instância do próximo formulário
                newForm.Show();             // Mostra o novo formulário
                this.Hide();               // Oculta o formulário de login
            }
            else
            {
                // Autenticação falhou:
                MessageBox.Show("Login ou senha incorretos!", "Erro de Autenticação",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Variável de controle para visibilidade da senha
        private bool senhaVisivel = false;

        // Evento de clique no ícone do campo de senha
        private void guna2TextBox2_IconRightClick(object sender, EventArgs e)
        {
            // Alterna o estado de visibilidade
            senhaVisivel = !senhaVisivel;

            if (senhaVisivel)
            {
                // Mostra o texto da senha
                guna2TextBox2.PasswordChar = '\0'; // Remove a máscara
                guna2TextBox2.IconRight = Properties.Resources.hide; // Ícone de olho fechado
            }
            else
            {
                // Oculta o texto da senha
                guna2TextBox2.PasswordChar = '•'; // Aplica máscara
                guna2TextBox2.IconRight = Properties.Resources.view; // Ícone de olho aberto
            }
        }
    }
}