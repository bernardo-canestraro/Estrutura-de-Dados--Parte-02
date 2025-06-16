using System;
using System.Windows.Forms;

namespace APS0605.Controller
{
    public partial class UserControl2 : UserControl
    {
        // Injected dependencies
        private readonly Screening _screening;              // Sorting system
        private readonly GeneralClinic _generalClinic;             // Clinical management
        private readonly HistoryServices _historyServices;  // Service record

        public UserControl2(Screening screening, GeneralClinic generalClinic, HistoryServices historyServices)
        {
            InitializeComponent();
            // Initialize dependencies
            _screening = screening;
            _generalClinic = generalClinic;
            _historyServices = historyServices;
        }

        // Click event on the registration button
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Name validation (required field)
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Nome do paciente é obrigatório!", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Blood pressure validation (positive number)
                if (!double.TryParse(txtBloodPressure.Text, out double pressaoArterial) || pressaoArterial <= 0)
                {
                    MessageBox.Show("Pressão arterial inválida!", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Temperature validation (positive number)
                if (!double.TryParse(txtTemperature.Text, out double temperatura) || temperatura <= 0)
                {
                    MessageBox.Show("Temperatura inválida!", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Oxygenation validation (positive number)
                if (!double.TryParse(txtOxygenLevel.Text, out double nivelOxigenacao) || nivelOxigenacao <= 0)
                {
                    MessageBox.Show("Nível de oxigenação inválido!", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create and register the new patient
                var newPatient = new Patient(txtName.Text, pressaoArterial, temperatura, nivelOxigenacao);
                _screening.AddPatient(newPatient);  // Add to sorting queue
                _generalClinic.AddPatient(newPatient);  // Register in the clinical system

                MessageBox.Show("Paciente adicionado à fila de triagem.", "Sucesso",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cleaning fields after registration
                txtName.Clear();
                txtBloodPressure.Clear();
                txtTemperature.Clear();
                txtOxygenLevel.Clear();
            }
            catch (Exception ex)
            {
                // Generic error handling
                MessageBox.Show($"Erro: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Input validation for blood pressure (numbers only)
        private void txtBloodPressure_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block invalid characters
            }
        }

        // Input validation for temperature (numbers and decimal point)
        private void txtTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        // Input validation for oxygenation (numbers and decimal point)
        private void txtOxygenLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}