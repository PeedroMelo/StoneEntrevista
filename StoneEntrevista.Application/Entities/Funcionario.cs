using System;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StoneEntrevista.Application.Entities
{
    public class Funcionario
    {
		[BsonId]
		public ObjectId Id { get; set; }

		[BsonElement("matricula")]
        public string Matricula { get; set; }

		[BsonElement("nome")]
		public string Nome { get; set; }

		[BsonElement("cargo")]
		public string Cargo { get; set; }

		[BsonElement("area")]
		public string Area { get; set; }

		[BsonElement("salario_bruto")]
		public double SalarioBruto { get; set; }

		[BsonElement("data_admissao")]
		public DateTime DataAdmissao { get; set; }
    }
}