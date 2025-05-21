using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS0605
{
    // Classe que representa um paciente e sua classificação de prioridade
    public class Paciente
    {
        // Propriedades básicas do paciente
        public string Nome { get; set; }           // Nome do paciente
        public double PressaoArterial { get; set; } // Valor da pressão arterial
        public double Temperatura { get; set; }    // Temperatura corporal
        public double NivelOxigenacao { get; set; } // Nível de oxigenação no sangue (%)
        public string Prioridade { get; set; }     // Classificação de prioridade (Vermelha/Amarela/Verde)

        // Construtor que inicializa os dados do paciente e já classifica sua prioridade
        public Paciente(string nome, double pressaoArterial, double temperatura, double nivelOxigenacao)
        {
            Nome = nome;
            PressaoArterial = pressaoArterial;
            Temperatura = temperatura;
            NivelOxigenacao = nivelOxigenacao;
            Prioridade = ClassificarPrioridade(); // Classifica automaticamente a prioridade
        }

        // Método privado que determina a prioridade com base nos sinais vitais
        private string ClassificarPrioridade()
        {
            // Critérios para prioridade VERMELHA (emergência):
            // - Pressão arterial muito alta (> 18)
            // - Febre muito alta (> 39°C)
            // - Oxigenação crítica (< 90%)
            if (PressaoArterial > 18 || Temperatura > 39 || NivelOxigenacao < 90)
                return "Vermelha"; // Prioridade Máxima

            // Critério para prioridade AMARELA (urgente):
            // - Pressão arterial alta (> 12)
            else if (PressaoArterial > 12)
                return "Amarela"; // Prioridade Média

            // Caso contrário: prioridade VERDE (normal)
            else
                return "Verde"; // Prioridade Normal
        }
    }
}