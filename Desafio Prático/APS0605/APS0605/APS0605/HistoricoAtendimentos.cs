using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS0605
{
    // Classe que gerencia o histórico de pacientes atendidos usando uma Stack (Pilha)
    // Segue o princípio LIFO (Last In, First Out) - Último a Entrar, Primeiro a Sair
    public class HistoricoAtendimentos
    {
        // Pilha interna para armazenar os pacientes atendidos
        private Stack<Paciente> historico = new Stack<Paciente>();

        // Adiciona um paciente ao topo da pilha de histórico
        public void AdicionarAoHistorico(Paciente paciente)
        {
            historico.Push(paciente); // Empilha o paciente
        }

        // Remove e retorna o último paciente atendido (do topo da pilha)
        // ATENÇÃO: Lança InvalidOperationException se a pilha estiver vazia
        public Paciente RemoverDoHistorico()
        {
            return historico.Pop(); // Desempilha o paciente mais recente
        }

        // Verifica se existem pacientes no histórico
        public bool TemHistorico()
        {
            return historico.Count > 0;
        }

        // Retorna uma lista com todo o histórico de atendimentos
        // (ordem: do mais recente para o mais antigo)
        public List<Paciente> ObterHistoricoCompleto()
        {
            return new List<Paciente>(historico); // Converte a pilha para lista
        }
    }
}