using System;
using Xunit;
using StoneEntrevista.Application.Services;
using StoneEntrevista.Application.Entities;

namespace StoneEntrevista.Application.UnitTest.Entities
{
    public class DistribuicaoTests
    {
        [Fact]
        public void Distribuicao_DeveriaInstanciarCorretamente()
        {
            Distribuicao distribuicao = new Distribuicao
            {
                TotalFuncionarios = 1,
                TotalDistribuido = 1000m,
                TotalDisponibilizado = 1000m
            };

            Assert.NotNull(distribuicao.TotalFuncionarios);
            Assert.NotNull(distribuicao.TotalDistribuido);
            Assert.NotNull(distribuicao.TotalDisponibilizado);
        }

        [Fact]
        public void Distribuicao_DeveriaHaverPeloMenosUmFuncionario()
        {
            Distribuicao distribuicao = new Distribuicao
            {
                TotalFuncionarios = 1,
                TotalDistribuido = 1000m,
                TotalDisponibilizado = 1000m
            };

            Assert.True(distribuicao.TotalFuncionarios > 0);
        }

        [Fact]
        public void Distribuicao_DeveriaDisponibilizarUmValorPositivo()
        {
            Distribuicao distribuicao = new Distribuicao
            {
                TotalFuncionarios = 1,
                TotalDistribuido = 1000m,
                TotalDisponibilizado = 1m
            };

            Assert.True(distribuicao.TotalDisponibilizado > 0);
        }
    }
}