using System;
using System.Globalization;
using StoneEntrevista.Application.Entities;

namespace StoneEntrevista.Application.Services
{
    public class BonusService
    {
        private int _pesoFaixaSalarial { get; set; }

        private int _pesoTempoAdmissao { get; set; }

        private int _pesoAreaAtuacao { get; set; }

        private decimal _salarioBruto { get; set; }

        public BonusService(Funcionario funcionario)
        {
            _salarioBruto = funcionario.SalarioBruto;

            _pesoFaixaSalarial = CalcularFaixaSalarial();
            _pesoTempoAdmissao = CalcularTempoAdmissao(funcionario.DataAdmissao);
            _pesoAreaAtuacao = CalcularAreaAtuacao(funcionario.Area);
        }

        public decimal CalcularBonus()
        {
            decimal bonus = ((_salarioBruto * _pesoTempoAdmissao + _salarioBruto * _pesoAreaAtuacao) / (_salarioBruto * _pesoFaixaSalarial)) * 12;
            
            return decimal.Parse((_salarioBruto * bonus / 100).ToString("F2", CultureInfo.InvariantCulture));
        }

        private int CalcularFaixaSalarial()
        {
            int pesoFaixaSalarial;
            decimal salarioMinimo = (decimal) 1000.00;

            if (_salarioBruto > (salarioMinimo * 8))
            {
                pesoFaixaSalarial = 5;
            }
            else if (_salarioBruto > (salarioMinimo * 5))
            {
                pesoFaixaSalarial = 3;
            }
            else if (_salarioBruto > (salarioMinimo * 3))
            {
                pesoFaixaSalarial = 2;
            }
            else
            {
                pesoFaixaSalarial = 1;
            }

            return pesoFaixaSalarial;
        }

        private int CalcularTempoAdmissao(DateTime dataAdmissao)
        {
            int tempoAdmissao = DateTime.Now.Subtract(dataAdmissao).Days / 365;
            int pesoTempoAdmissao;

            // Peso Tempo Admissao
            if (tempoAdmissao > 8)
            {
                pesoTempoAdmissao = 5;
            }
            else if (tempoAdmissao > 3 && tempoAdmissao <= 8)
            {
                pesoTempoAdmissao = 3;
            }
            else if (tempoAdmissao > 1 && tempoAdmissao <= 3)
            {
                pesoTempoAdmissao = 2;
            }
            else
            {
                pesoTempoAdmissao = 1;
            }
            return pesoTempoAdmissao;
        }

        private int CalcularAreaAtuacao(string areaAtuacao)
        {
            int pesoAreaAtuacao;

            switch (areaAtuacao)
            {
                case "Relacionamento com o Cliente":
                    pesoAreaAtuacao = 5;
                    break;

                case "Serviços Gerais":
                    pesoAreaAtuacao = 3;
                    break;

                case "Contabilidade":
                    pesoAreaAtuacao = 2;
                    break;
                
                case "Financeiro":
                    pesoAreaAtuacao = 2;
                    break;
                
                case "Tecnologia":
                    pesoAreaAtuacao = 2;
                    break;

                default:
                    pesoAreaAtuacao = 1;
                    break;
            }

            return pesoAreaAtuacao;
        }
    }
}