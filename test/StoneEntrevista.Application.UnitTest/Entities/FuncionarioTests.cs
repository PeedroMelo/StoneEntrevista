using System;
using Xunit;
using StoneEntrevista.Application.Services;
using StoneEntrevista.Application.Entities;

namespace StoneEntrevista.Application.UnitTest.Entities
{
    public class FuncionarioTests
    {
        [Fact]
        public void Funcionario_DeveriaInstanciarCorretamente()
        {
            Funcionario funcionario = new Funcionario
            {
                Matricula = "0009968",
                Nome = "Victor Wilson",
                Area = "Diretoria",
                Cargo = "Diretor Financeiro",
                SalarioBruto = (decimal)12696.20,
                DataAdmissao = new DateTime(2012, 01, 05)
            };

            Assert.NotNull(funcionario.Matricula);
            Assert.NotNull(funcionario.Nome);
            Assert.NotNull(funcionario.Area);
            Assert.NotNull(funcionario.Cargo);
            Assert.NotNull(funcionario.SalarioBruto);
            Assert.NotNull(funcionario.DataAdmissao);
        }
    }
}