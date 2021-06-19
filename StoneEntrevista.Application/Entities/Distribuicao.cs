using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoneEntrevista.Application.Entities
{
    public class Distribuicao
    {
        [JsonPropertyName("total_de_funcionarios")]
        public int TotalFuncionarios { get; set; }
        
        [JsonPropertyName("total_distribuido")]
        public double TotalDistribuido { get; set; }
        
        [JsonPropertyName("total_disponibilizado")]
        public double TotalDisponibilizado { get; set; }
        
        [JsonPropertyName("saldo_total_disponibilizado")]
        public double SaldoTotalDisponibilizado { get; set; }
        
        [JsonPropertyName("participacoes")]
        public List<Participacao> Participacoes { get; set; }
    }
}