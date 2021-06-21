using System;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StoneEntrevista.Application.Entities
{
    public class Funcionario
    {
		[BsonId]
		[JsonIgnore]
		public ObjectId Id { get; set; }

		[JsonPropertyName("matricula")]
        public string Matricula { get; set; }

		[JsonPropertyName("nome")]
		public string Nome { get; set; }

		[JsonPropertyName("cargo")]
		public string Cargo { get; set; }

		[JsonPropertyName("area")]
		public string Area { get; set; }

		[JsonPropertyName("salario_bruto")]
		[BsonRepresentation(BsonType.Decimal128)]
		public decimal SalarioBruto { get; set; }

		[JsonPropertyName("data_de_admissao")]
		public DateTime DataAdmissao { get; set; }
    }
}