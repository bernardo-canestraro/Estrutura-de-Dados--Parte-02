using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS0605
{
    // Class representing a patient and their priority classification
    public class Patient
    {
        // Basic patient properties
        public string Name { get; set; }           // Patient name
        public double BloodPressure { get; set; } // Blood pressure value
        public double Temperature { get; set; }    // Body temperature
        public double OxygenationLevel { get; set; } // Blood oxygen level (%)
        public string Priority { get; set; }     // Priority rating (Red/Yellow/Green)

        // Constructor that initializes the patient data and classifies its priority
        public Patient(string name, double bloodPressure, double temperature, double oxygenationLevel)
        {
            Name = name;
            BloodPressure = bloodPressure;
            Temperature = temperature;
            OxygenationLevel = oxygenationLevel;
            Priority = SortPriority(); // Automatically sort the priority
        }

        // Private method that determines priority based on vital signs
        private string SortPriority()
        {
            // Criteria for RED priority (emergency):
            // - Very high blood pressure (> 18)
            // - Very high fever (> 39°C)
            // - Critical oxygenation (< 90%)
            if (BloodPressure > 18 || Temperature > 39 || OxygenationLevel < 90)
                return "Vermelha"; // Maximum Priority

            // Criteria for YELLOW priority (urgent):
            // - High blood pressure (> 12)
            else if (BloodPressure > 12)
                return "Amarela"; // Medium Priority

            // Otherwise: GREEN priority (normal)
            else
                return "Verde"; // Normal Priority
        }
    }
}