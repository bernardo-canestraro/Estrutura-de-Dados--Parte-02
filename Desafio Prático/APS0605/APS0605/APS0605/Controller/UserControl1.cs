using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace APS0605.Controller
{
    public partial class UserControl1 : UserControl
    {
        // Injected dependencies
        private readonly Screening _screening;             // Sorting queue control
        private readonly GeneralClinic _generalClinic;            // Clinical management
        private readonly HistoryServices _historyServices; // Service record

        public UserControl1(Screening screening, GeneralClinic generalClinic, HistoryServices historyServices)
        {
            InitializeComponent();

            // Dependency injection
            _screening = screening;
            _generalClinic = generalClinic;
            _historyServices = historyServices;

            // Initial configuration
            ConfigureDataGridView();      // Prepare the DataGridView
            UpdatePatientList();    // Load initial patients

            // Subscription to events for automatic update
            _generalClinic.PatientAdded += UpdatePatientList;
            _generalClinic.PatientAttended += UpdatePatientList;
        }

        // DataGridView configuration for displaying patients
        private void ConfigureDataGridView()
        {
            dgvPacientes.AutoGenerateColumns = false;  // Disable automatic column generation
            dgvPacientes.AllowUserToAddRows = false;   // Prevents user from adding lines
            dgvPacientes.ReadOnly = true;              // Make the grid read-only

            // Add columns manually
            dgvPacientes.Columns.Add("Nome", "Nome");
            dgvPacientes.Columns.Add("Pressao", "Pressão Arterial");
            dgvPacientes.Columns.Add("Temperatura", "Temperatura");
            dgvPacientes.Columns.Add("Oxigenacao", "Oxigenação");
            dgvPacientes.Columns.Add("Prioridade", "Prioridade");
        }

        // Update the list of patients in the DataGridView
        public void UpdatePatientList()
        {
            dgvPacientes.Rows.Clear();  // Clear the grid

            // Add each patient to the grid
            foreach (var paciente in _generalClinic.GetAllPatients())
            {
                dgvPacientes.Rows.Add(
                    paciente.Name,
                    paciente.BloodPressure,
                    paciente.Temperature,
                    paciente.OxygenationLevel,
                    paciente.Priority
                );
            }
        }

        // Click event to serve next patient
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            var pacienteAtendido = _generalClinic.Tomeet();  // Attend to the next patient

            if (pacienteAtendido != null)
            {
                // Logs to history and displays message
                _historyServices.AddToHistory(pacienteAtendido);
                MessageBox.Show($"Paciente {pacienteAtendido.Name} atendido com prioridade {pacienteAtendido.Priority}.");
            }
            else
            {
                MessageBox.Show("Nenhum paciente para atender.");
            }
        }
    }
}