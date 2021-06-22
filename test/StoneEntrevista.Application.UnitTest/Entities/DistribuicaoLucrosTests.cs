using System;
using Xunit;
using StoneEntrevista.Application.Services;
using StoneEntrevista.Application.Entities;

namespace StoneEntrevista.Application.UnitTest.Entities
{
    public class DistribuicaoLucrosTests
    {
        [Fact]
        public void DistribuicaoLucros_DeveriaInstanciarCorretamente()
        {
            DistribuicaoLucros distribuicao = new DistribuicaoLucros
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
        public void DistribuicaoLucros_DeveriaHaverPeloMenosUmFuncionario()
        {
            DistribuicaoLucros distribuicao = new DistribuicaoLucros
            {
                TotalFuncionarios = 1,
                TotalDistribuido = 1000m,
                TotalDisponibilizado = 1000m
            };

            Assert.True(distribuicao.TotalFuncionarios > 0);
        }

        [Fact]
        public void DistribuicaoLucros_DeveriaDisponibilizarUmValorPositivo()
        {
            DistribuicaoLucros distribuicao = new DistribuicaoLucros
            {
                TotalFuncionarios = 1,
                TotalDistribuido = 1000m,
                TotalDisponibilizado = 1m
            };

            Assert.True(distribuicao.TotalDisponibilizado > 0);
        }
    }
}