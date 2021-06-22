using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using StoneEntrevista.Application.Entities;
using StoneEntrevista.Application.Interfaces;
using StoneEntrevista.Application.Helpers;

namespace StoneEntrevista.Application.Services
{
    public class DistribuicaoLucrosService : IDistribuicaoLucrosService
    {
        public decimal _totalDisponibilizado { get; set; } = 0;

        public DistribuicaoLucrosService(decimal totalDisponibilizado)
        {
            _totalDisponibilizado = totalDisponibilizado;
        }

        public DistribuicaoLucros CalcularDistribuicao(List<Funcionario> funcionarios)
        {
            List<Participacao> participacoes = new List<Participacao>();

            decimal totalDistribuido = 0;

            foreach (Funcionario funcionario in funcionarios)
            {
                BonusService bonusService = new BonusService(funcionario);
                decimal valorParticipacao = bonusService.CalcularBonus();

                totalDistribuido += valorParticipacao;

                participacoes.Add(
                    new Participacao
                    {
                        Matricula = funcionario.Matricula,
                        Nome = funcionario.Nome,
                        ValorParticipacao = CurrencySerializer.DecimalToString(valorParticipacao)
                    }
                );
            }

            DistribuicaoLucros distribuicao = new DistribuicaoLucros();

            distribuicao.TotalFuncionarios = participacoes.Count();
            distribuicao.TotalDisponibilizado =_totalDisponibilizado;
            distribuicao.TotalDistribuido = totalDistribuido;
            distribuicao.SaldoTotalDisponibilizado =_totalDisponibilizado - totalDistribuido;
            distribuicao.Participacoes = participacoes;

            return distribuicao;
        }
    }
}