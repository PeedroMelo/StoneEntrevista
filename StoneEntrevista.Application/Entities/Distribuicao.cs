using System.Collections.Generic;

namespace StoneEntrevista.Application.Entities
{
    public class Distribuicao
    {
        public int TotalFuncionarios { get; set; }
        public double TotalDistribuido { get; set; }
        public double TotalDisponibilizado { get; set; }
        public double SaldoTotalDisponibilizado { get; set; }
        public List<Participacao> Participacoes { get; set; }
    }
}