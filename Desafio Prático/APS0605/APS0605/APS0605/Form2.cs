using APS0605.Controller;
using System.Drawing;
using System.Windows.Forms;

namespace APS0605
{
    public partial class Form2 : Form
    {
        // Instâncias compartilhadas dos componentes do sistema
        private readonly Triagem _triagem;                  // Sistema de triagem
        private readonly ClinicoGeral _clinico;             // Controle clínico
        private readonly HistoricoAtendimentos _historico;   // Registro de atendimentos

        public Form2()
        {
            InitializeComponent();

            // Inicializa os componentes principais
            _triagem = new Triagem();
            _clinico = new ClinicoGeral(_triagem);  // Injeta a triagem no clínico geral
            _historico = new HistoricoAtendimentos();

            // Carrega a tela inicial (UserControl1)
            UserControl1 uc = new UserControl1(_triagem, _clinico, _historico);
            AdicionarUserControl(uc);
        }

        // Método para gerenciar a exibição de UserControls
        private void AdicionarUserControl(UserControl userControl)
        {
            // Configura o UserControl para preencher todo o espaço
            userControl.Dock = DockStyle.Fill;

            // Limpa o painel e adiciona o novo controle
            guna2Panel2.Controls.Clear();
            guna2Panel2.Controls.Add(userControl);
            userControl.BringToFront();

            // Atualiza a aparência dos botões de navegação
            guna2Button1.FillColor = (userControl is UserControl2) ? Color.Gray : Color.Transparent;
            guna2Button2.FillColor = (userControl is UserControl1) ? Color.Gray : Color.Transparent;
        }

        // Evento Load do formulário - Configuração inicial
        private void Form2_Load(object sender, System.EventArgs e)
        {
            guna2Panel1.Width = 71;   // Painel lateral recolhido
            this.Width = 831;         // Largura inicial do formulário
        }

        // Variável de controle para o painel lateral
        private bool panelExpandido = false;

        // Evento para expandir/recolher o painel lateral
        private void guna2PictureBox1_Click(object sender, System.EventArgs e)
        {
            // Alterna entre estados expandido/recolhido
            guna2Panel1.Width = panelExpandido ? 71 : 165;
            this.Width = panelExpandido ? 831 : 927;
            panelExpandido = !panelExpandido;

            // Força redesenho dos componentes
            this.Refresh();
            guna2Panel1.Refresh();
        }

        // Botão para exibir o UserControl2 (Tela 2)
        private void guna2Button1_Click(object sender, System.EventArgs e)
        {
            UserControl2 uc = new UserControl2(_triagem, _clinico, _historico);
            AdicionarUserControl(uc);
        }

        // Botão para exibir o UserControl1 (Tela 1 - Inicial)
        private void guna2Button2_Click(object sender, System.EventArgs e)
        {
            UserControl1 uc = new UserControl1(_triagem, _clinico, _historico);
            AdicionarUserControl(uc);
        }
    }
}