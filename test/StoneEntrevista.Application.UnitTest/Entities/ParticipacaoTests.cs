using System;
using Xunit;
using StoneEntrevista.Application.Services;
using StoneEntrevista.Application.Entities;

namespace StoneEntrevista.Application.UnitTest.Entities
{
    public class ParticipacaoTests
    {
        [Fact]
        public void Participacao_DeveriaInstanciarCorretamente()
        {
            Participacao participacao = new Participacao
            {
                Matricula = "0009968",
                Nome = "Victor Wilson",
                ValorParticipacao = 12696.20m
            };

            Assert.Equal("Victor Wilson", participacao.Nome);
            Assert.Equal("0009968", participacao.Matricula);
            Assert.Equal(12696.20m, participacao.ValorParticipacao);
        }

        [Fact]
        public void Participacao_ValorDaParticipacaoDeveSerMaiorQueZero()
        {
            Participacao participacao = new Participacao
            {
                Matricula = "0009968",
                Nome = "Victor Wilson",
                ValorParticipacao = 1m
            };

            Assert.True(participacao.ValorParticipacao > 0m);
        }
    }
}