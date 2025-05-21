using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace APS0605.Controller
{
    public partial class UserControl1 : UserControl
    {
        // Dependências injetadas
        private readonly Triagem _triagem;                  // Controle de fila de triagem
        private readonly ClinicoGeral _clinico;            // Gerenciamento clínico
        private readonly HistoricoAtendimentos _historico;  // Registro de atendimentos

        public UserControl1(Triagem triagem, ClinicoGeral clinico, HistoricoAtendimentos historico)
        {
            InitializeComponent();

            // Injeção das dependências
            _triagem = triagem;
            _clinico = clinico;
            _historico = historico;

            // Configuração inicial
            ConfigurarDataGridView();      // Prepara o DataGridView
            AtualizarListaPacientes();    // Carrega os pacientes iniciais

            // Assinatura dos eventos para atualização automática
            _clinico.PacienteAdicionado += AtualizarListaPacientes;
            _clinico.PacienteAtendido += AtualizarListaPacientes;
        }

        // Configuração do DataGridView para exibição de pacientes
        private void ConfigurarDataGridView()
        {
            dgvPacientes.AutoGenerateColumns = false;  // Desativa geração automática de colunas
            dgvPacientes.AllowUserToAddRows = false;   // Impede adição de linhas pelo usuário
            dgvPacientes.ReadOnly = true;              // Torna a grid somente leitura

            // Adiciona colunas manualmente
            dgvPacientes.Columns.Add("Nome", "Nome");
            dgvPacientes.Columns.Add("Pressao", "Pressão Arterial");
            dgvPacientes.Columns.Add("Temperatura", "Temperatura");
            dgvPacientes.Columns.Add("Oxigenacao", "Oxigenação");
            dgvPacientes.Columns.Add("Prioridade", "Prioridade");
        }

        // Atualiza a lista de pacientes no DataGridView
        public void AtualizarListaPacientes()
        {
            dgvPacientes.Rows.Clear();  // Limpa a grid

            // Adiciona cada paciente na grid
            foreach (var paciente in _clinico.ObterTodosPacientes())
            {
                dgvPacientes.Rows.Add(
                    paciente.Nome,
                    paciente.PressaoArterial,
                    paciente.Temperatura,
                    paciente.NivelOxigenacao,
                    paciente.Prioridade
                );
            }
        }

        // Evento de clique para atender próximo paciente
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            var pacienteAtendido = _clinico.Atender();  // Atende o próximo paciente

            if (pacienteAtendido != null)
            {
                // Registra no histórico e mostra mensagem
                _historico.AdicionarAoHistorico(pacienteAtendido);
                MessageBox.Show($"Paciente {pacienteAtendido.Nome} atendido com prioridade {pacienteAtendido.Prioridade}.");
            }
            else
            {
                MessageBox.Show("Nenhum paciente para atender.");
            }
        }
    }
}