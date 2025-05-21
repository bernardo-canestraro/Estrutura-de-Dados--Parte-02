using System;
using System.Windows.Forms;

namespace APS0605.Controller
{
    public partial class UserControl2 : UserControl
    {
        // Dependências injetadas
        private readonly Triagem _triagem;                  // Sistema de triagem
        private readonly ClinicoGeral _clinico;             // Gerenciamento clínico
        private readonly HistoricoAtendimentos _historico;   // Registro de atendimentos

        public UserControl2(Triagem triagem, ClinicoGeral clinico, HistoricoAtendimentos historico)
        {
            InitializeComponent();
            // Inicializa as dependências
            _triagem = triagem;
            _clinico = clinico;
            _historico = historico;
        }

        // Evento de clique no botão de cadastro
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validação do nome (campo obrigatório)
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    MessageBox.Show("Nome do paciente é obrigatório!", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validação da pressão arterial (número positivo)
                if (!double.TryParse(txtPressaoArterial.Text, out double pressaoArterial) || pressaoArterial <= 0)
                {
                    MessageBox.Show("Pressão arterial inválida!", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validação da temperatura (número positivo)
                if (!double.TryParse(txtTemperatura.Text, out double temperatura) || temperatura <= 0)
                {
                    MessageBox.Show("Temperatura inválida!", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validação da oxigenação (número positivo)
                if (!double.TryParse(txtNivelOxigenacao.Text, out double nivelOxigenacao) || nivelOxigenacao <= 0)
                {
                    MessageBox.Show("Nível de oxigenação inválido!", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cria e registra o novo paciente
                var novoPaciente = new Paciente(txtNome.Text, pressaoArterial, temperatura, nivelOxigenacao);
                _triagem.AdicionarPaciente(novoPaciente);  // Adiciona à fila de triagem
                _clinico.AdicionarPaciente(novoPaciente);  // Registra no sistema clínico

                MessageBox.Show("Paciente adicionado à fila de triagem.", "Sucesso",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpeza dos campos após cadastro
                txtNome.Clear();
                txtPressaoArterial.Clear();
                txtTemperatura.Clear();
                txtNivelOxigenacao.Clear();
            }
            catch (Exception ex)
            {
                // Tratamento genérico de erros
                MessageBox.Show($"Erro: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Validação de entrada para pressão arterial (apenas números)
        private void txtPressaoArterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloqueia caracteres inválidos
            }
        }

        // Validação de entrada para temperatura (números e ponto decimal)
        private void txtTemperatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        // Validação de entrada para oxigenação (números e ponto decimal)
        private void txtNivelOxigenacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}