using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StoneEntrevista.Application.Entities
{
    public class Participacao
    {
        [JsonPropertyName("valor_da_participacao")]
        public string ValorParticipacao { get; set; }
        
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
        
        [JsonPropertyName("matricula")]
        public string Matricula { get; set; }
    }
}