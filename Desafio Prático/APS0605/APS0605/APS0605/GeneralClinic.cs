using System;
using System.Collections.Generic;
using System.Linq;

namespace APS0605
{
    // Class that manages patient care with priorities
    public class GeneralClinic
    {
        // List of patients already treated
        private List<Patient> patientsServed = new List<Patient>();

        // General list of all patients
        private List<Patient> listPatients = new List<Patient>();

        // Dictionary of queues by priority (Red, Yellow, Green)
        private Dictionary<string, Queue<Patient>> queuePriority = new Dictionary<string, Queue<Patient>>();

        // Reference for the triage system
        private Screening screening;

        // Events to notify when changes occur
        public event Action PatientAdded;
        public event Action PatientAttended;

        // Constructor that initializes the priority queues
        public GeneralClinic(Screening screening)
        {
            this.screening = screening;
            queuePriority["Vermelha"] = new Queue<Patient>();
            queuePriority["Amarela"] = new Queue<Patient>();
            queuePriority["Verde"] = new Queue<Patient>();
        }

        // Add a new patient to the system
        public void AddPatient(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));

            if (!queuePriority.ContainsKey(patient.Priority))
                throw new ArgumentException($"Prioridade {patient.Priority} inválida");

            // Add to control lists
            listPatients.Add(patient);
            queuePriority[patient.Priority].Enqueue(patient);

            // Notify listeners
            PatientAdded?.Invoke();
        }

        // Attend to the next patient according to priority
        public Patient Tomeet()
        {
            // Check in order of priority (Red > Yellow > Green)
            foreach (var prioridade in new[] { "Vermelha", "Amarela", "Verde" })
            {
                if (queuePriority[prioridade].Count > 0)
                {
                    var patient = queuePriority[prioridade].Dequeue();
                    patientsServed.Add(patient);

                    PatientAttended?.Invoke();
                    return patient;
                }
            }
            return null; // Returns null if there are no patients
        }

        // Returns the total number of patients waiting
        public int TotalPatientsInQueue()
        {
            return queuePriority.Sum(q => q.Value.Count);
        }

        // Get all patients in the queue, sorted by priority
        public List<Patient> GetAllPatients()
        {
            var allPatients = new List<Patient>();
            allPatients.AddRange(queuePriority["Vermelha"].ToList());
            allPatients.AddRange(queuePriority["Amarela"].ToList());
            allPatients.AddRange(queuePriority["Verde"].ToList());
            return allPatients;
        }

        // Returns a copy of the list of patients treated
        public List<Patient> GetPatientsAttended()
        {
            return new List<Patient>(patientsServed); // Protective copy
        }

        // Clear all queues and lists
        public void ClearQueues()
        {
            queuePriority["Vermelha"].Clear();
            queuePriority["Amarela"].Clear();
            queuePriority["Verde"].Clear();
            listPatients.Clear();
        }
    }
}