using System.Collections.Generic;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StoneEntrevista.Application.Entities
{
    public class Distribuicao
    {
        [JsonPropertyName("total_de_funcionarios")]
        public int TotalFuncionarios { get; set; }
        
        [JsonPropertyName("total_distribuido")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal TotalDistribuido { get; set; }
        
        [JsonPropertyName("total_disponibilizado")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal TotalDisponibilizado { get; set; }
        
        [JsonPropertyName("saldo_total_disponibilizado")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal SaldoTotalDisponibilizado { get; set; }
        
        [JsonPropertyName("participacoes")]
        public List<Participacao> Participacoes { get; set; }

        public Distribuicao()
        {
        }
    }
}