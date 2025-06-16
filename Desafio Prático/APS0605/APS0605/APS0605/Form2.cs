using APS0605.Controller;
using System.Drawing;
using System.Windows.Forms;

namespace APS0605
{
    public partial class Form2 : Form
    {
        // Shared instances of system components
        private readonly Screening _screening;                  // Sorting system
        private readonly GeneralClinic _generalClinic;             // Clinical control
        private readonly HistoryServices _historyServices;  // Service record

        public Form2()
        {
            InitializeComponent();

            // Initialize the main components
            _screening = new Screening();
            _generalClinic = new GeneralClinic(_screening);  // Inject triage into the general practitioner
            _historyServices = new HistoryServices();

            // Load the home screen (UserControl1)
            UserControl1 uc = new UserControl1(_screening, _generalClinic, _historyServices);
            AddUserControl(uc);
        }

        // Method to manage the display of UserControls
        private void AddUserControl(UserControl userControl)
        {
            // Set the UserControl to fill the entire space
            userControl.Dock = DockStyle.Fill;

            // Clear the panel and add the new control
            guna2Panel2.Controls.Clear();
            guna2Panel2.Controls.Add(userControl);
            userControl.BringToFront();

            // Updates the appearance of the navigation buttons
            guna2Button1.FillColor = (userControl is UserControl2) ? Color.Gray : Color.Transparent;
            guna2Button2.FillColor = (userControl is UserControl1) ? Color.Gray : Color.Transparent;
        }

        // Form Load Event - Initial Setup
        private void Form2_Load(object sender, System.EventArgs e)
        {
            guna2Panel1.Width = 71;   // Side panel collapsed
            this.Width = 831;         // Initial width of the form
        }

        // Control variable for the side panel
        private bool expandedPanel = false;

        // Event to expand/collapse the side panel
        private void guna2PictureBox1_Click(object sender, System.EventArgs e)
        {
            // Toggle between expanded/collapsed states
            guna2Panel1.Width = expandedPanel ? 71 : 165;
            this.Width = expandedPanel ? 831 : 927;
            expandedPanel = !expandedPanel;

            // Force redesign of components
            this.Refresh();
            guna2Panel1.Refresh();
        }

        // Button to display UserControl2 (Screen 2)
        private void guna2Button1_Click(object sender, System.EventArgs e)
        {
            UserControl2 uc = new UserControl2(_screening, _generalClinic, _historyServices);
            AddUserControl(uc);
        }

        // Button to display UserControl1 (Screen 1 - Home)
        private void guna2Button2_Click(object sender, System.EventArgs e)
        {
            UserControl1 uc = new UserControl1(_screening, _generalClinic, _historyServices);
            AddUserControl(uc);
        }
    }
}