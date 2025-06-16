using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS0605
{
    // Class that manages the queue of patients for triage (FIFO order)
    public class Screening
    {
        // Queue that stores patients waiting for care
        private Queue<Patient> queueSorting = new Queue<Patient>();

        // Add a patient to the end of the waiting queue
        public void AddPatient(Patient patient)
        {
            queueSorting.Enqueue(patient);
        }
    }
}