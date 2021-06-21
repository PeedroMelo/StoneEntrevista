using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using StoneEntrevista.Application.Entities;

namespace StoneEntrevista.Application.Services
{
    public class ParticipacaoService
    {
        public decimal _totalDisponibilizado { get; set; } = 0;

        public ParticipacaoService(decimal totalDisponibilizado)
        {
            _totalDisponibilizado = totalDisponibilizado;
        }

        public Distribuicao CalcularParticipacao(List<Funcionario> funcionarios)
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
                        Nome = funcionario.Nome,
                        Matricula = funcionario.Matricula,
                        ValorParticipacao = valorParticipacao
                    }
                );
            }

            Distribuicao distribuicao = new Distribuicao();

            distribuicao.TotalFuncionarios = participacoes.Count();
            distribuicao.TotalDisponibilizado =_totalDisponibilizado;
                // .ToString("C2", CultureInfo.CreateSpecificCulture("pt-BR"));
            distribuicao.TotalDistribuido = totalDistribuido;
            distribuicao.SaldoTotalDisponibilizado =_totalDisponibilizado - totalDistribuido;
            distribuicao.Participacoes = participacoes;

            return distribuicao;
        }
    }
}