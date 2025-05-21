using System;
using System.Collections.Generic;
using System.Linq;

namespace APS0605
{
    // Classe que gerencia o atendimento de pacientes com prioridades
    public class ClinicoGeral
    {
        // Lista de pacientes já atendidos
        private List<Paciente> pacientesAtendidos = new List<Paciente>();

        // Lista geral de todos os pacientes
        private List<Paciente> listaPacientes = new List<Paciente>();

        // Dicionário de filas por prioridade (Vermelha, Amarela, Verde)
        private Dictionary<string, Queue<Paciente>> filaPrioridade = new Dictionary<string, Queue<Paciente>>();

        // Referência para o sistema de triagem
        private Triagem triagem;

        // Eventos para notificação quando ocorrem alterações
        public event Action PacienteAdicionado;
        public event Action PacienteAtendido;

        // Construtor que inicializa as filas de prioridade
        public ClinicoGeral(Triagem triagem)
        {
            this.triagem = triagem;
            filaPrioridade["Vermelha"] = new Queue<Paciente>();
            filaPrioridade["Amarela"] = new Queue<Paciente>();
            filaPrioridade["Verde"] = new Queue<Paciente>();
        }

        // Adiciona um novo paciente ao sistema
        public void AdicionarPaciente(Paciente paciente)
        {
            if (paciente == null)
                throw new ArgumentNullException(nameof(paciente));

            if (!filaPrioridade.ContainsKey(paciente.Prioridade))
                throw new ArgumentException($"Prioridade {paciente.Prioridade} inválida");

            // Adiciona às listas de controle
            listaPacientes.Add(paciente);
            filaPrioridade[paciente.Prioridade].Enqueue(paciente);

            // Notifica os ouvintes
            PacienteAdicionado?.Invoke();
        }

        // Atende o próximo paciente conforme prioridade
        public Paciente Atender()
        {
            // Verifica em ordem de prioridade (Vermelha > Amarela > Verde)
            foreach (var prioridade in new[] { "Vermelha", "Amarela", "Verde" })
            {
                if (filaPrioridade[prioridade].Count > 0)
                {
                    var paciente = filaPrioridade[prioridade].Dequeue();
                    pacientesAtendidos.Add(paciente);

                    PacienteAtendido?.Invoke();
                    return paciente;
                }
            }
            return null; // Retorna null se não houver pacientes
        }

        // Retorna o total de pacientes aguardando
        public int TotalPacientesNaFila()
        {
            return filaPrioridade.Sum(q => q.Value.Count);
        }

        // Obtém todos os pacientes na fila, ordenados por prioridade
        public List<Paciente> ObterTodosPacientes()
        {
            var todosPacientes = new List<Paciente>();
            todosPacientes.AddRange(filaPrioridade["Vermelha"].ToList());
            todosPacientes.AddRange(filaPrioridade["Amarela"].ToList());
            todosPacientes.AddRange(filaPrioridade["Verde"].ToList());
            return todosPacientes;
        }

        // Retorna cópia da lista de pacientes atendidos
        public List<Paciente> ObterPacientesAtendidos()
        {
            return new List<Paciente>(pacientesAtendidos); // Cópia protetora
        }

        // Limpa todas as filas e listas
        public void LimparFilas()
        {
            filaPrioridade["Vermelha"].Clear();
            filaPrioridade["Amarela"].Clear();
            filaPrioridade["Verde"].Clear();
            listaPacientes.Clear();
        }
    }
}