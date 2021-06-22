using System;
using Xunit;
using StoneEntrevista.Application.Services;
using StoneEntrevista.Application.Entities;

namespace StoneEntrevista.Application.UnitTest.Services
{
    public class BonusServiceTest
    {
        [Fact]
        public void CalcularBonus_DeveriaRetornarOBonusCalculado()
        {
            Funcionario funcionario = new Funcionario
            {
                Matricula = "0009968",
                Nome = "Victor Wilson",
                Area = "Diretoria",
                Cargo = "Diretor Financeiro",
                SalarioBruto = 12696.20m,
                DataAdmissao = new DateTime(2012, 01, 05)
            };

            BonusService bonusService = new BonusService(funcionario);
            decimal valorParticipacao = bonusService.CalcularBonus();
            decimal valorEsperado = 1828.25m;

            Assert.Equal(valorEsperado, valorParticipacao);

            Funcionario funcionario2 = new Funcionario
            {
                Matricula = "0004468",
                Nome = "Flossie Wilson",
                Area = "Relacionamento com o Cliente",
                Cargo = "Líder de Relacionamento",
                SalarioBruto = 3899.74m,
                DataAdmissao = new DateTime(2015, 06, 07)
            };

            Assert.NotEqual(funcionario.Matricula, funcionario2.Matricula);

            BonusService bonusService2 = new BonusService(funcionario2);
            decimal valorParticipacao2 = bonusService2.CalcularBonus();
            decimal valorEsperado2 = 1871.88m;

            Assert.Equal(valorEsperado2, valorParticipacao2);
        }
    }
}
