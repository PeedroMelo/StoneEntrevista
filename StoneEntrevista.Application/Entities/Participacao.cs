using System.Text.Json.Serialization;

namespace StoneEntrevista.Application.Entities
{
    public class Participacao
    {
        [JsonPropertyName("valor_da_participacao")]
        public double ValorParticipacao { get; set; }
        
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
        
        [JsonPropertyName("matricula")]
        public string Matricula { get; set; }
    }
}