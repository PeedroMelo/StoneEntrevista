using System.Collections.Generic;
using System.Linq;
using StoneEntrevista.Application.Entities;

namespace StoneEntrevista.Application.Services
{
    public class ParticipacaoService
    {
        public double TotalDisponibilizado { get; set; }

        public Distribuicao CalcularParticipacao(List<Funcionario> funcionarios)
        {
            List<Participacao> participacoes = new List<Participacao>();

            double totalDistribuido = 0;

            foreach (Funcionario funcionario in funcionarios)
            {
                BonusService bonusService = new BonusService(funcionario);
                double valorParticipacao = bonusService.CalcularBonus();

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
            distribuicao.TotalDisponibilizado = 1000000.00;
            distribuicao.TotalDistribuido = totalDistribuido;
            distribuicao.SaldoTotalDisponibilizado = distribuicao.TotalDisponibilizado - totalDistribuido;
            distribuicao.Participacoes = participacoes;

            return distribuicao;
        }
    }
}