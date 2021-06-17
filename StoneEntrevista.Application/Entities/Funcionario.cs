using System;

namespace StoneEntrevista.Application.Entities
{
    public class Funcionario
    {
        public string Matricula { get; set; }

		public string Nome { get; set; }

		public string Cargo { get; set; }

		public string Area { get; set; }

		public double SalarioBruto { get; set; }

		public DateTime DataAdmissao { get; set; }
    }
}