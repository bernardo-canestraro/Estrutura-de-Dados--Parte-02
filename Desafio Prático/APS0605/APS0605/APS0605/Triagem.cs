using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS0605
{
    // Classe que gerencia a fila de pacientes para triagem (ordem FIFO)
    public class Triagem
    {
        // Fila que armazena os pacientes esperando atendimento
        private Queue<Paciente> filaTriagem = new Queue<Paciente>();

        // Adiciona um paciente no final da fila de espera
        public void AdicionarPaciente(Paciente paciente)
        {
            filaTriagem.Enqueue(paciente);
        }

        // Remove e retorna oz próximo paciente a ser atendido (início da fila)
        // ATENÇÃO: Lança erro se a fila estiver vazia
        //public Paciente AtenderPaciente()
        //{
        //    return filaTriagem.Dequeue();
        //}

        //// Verifica se ainda tem pacientes na fila
        //public bool TemPacientes()
        //{
        //    return filaTriagem.Count > 0;
        //}
    }
}