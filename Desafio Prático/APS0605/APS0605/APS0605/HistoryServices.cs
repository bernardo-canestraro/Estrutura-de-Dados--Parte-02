using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS0605
{
    // Class that manages the history of patients attended using a Stack
    // Follows the LIFO (Last In, First Out) principle
    public class HistoryServices
    {
        // Internal stack to store patients attended
        private Stack<Patient> history = new Stack<Patient>();

        // Add a patient to the top of the history stack
        public void AddToHistory(Patient patient)
        {
            history.Push(patient); // Empilha o paciente
        }

        // Remove and return the last patient served (from the top of the stack)
        // WARNING: Throws InvalidOperationException if the stack is empty
        public Patient RemoveFromHistory()
        {
            return history.Pop(); // Pop the most recent patient
        }

        // Check if there are patients in the history
        public bool HasHistory()
        {
            return history.Count > 0;
        }

        // Returns a list with all the service history
        // (order: newest to oldest)
        public List<Patient> GetFullHistory()
        {
            return new List<Patient>(history); // Convert the stack to a list
        }
    }
}