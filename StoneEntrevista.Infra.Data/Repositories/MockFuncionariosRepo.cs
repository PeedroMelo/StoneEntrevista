using System;
using System.Collections.Generic;
using StoneEntrevista.Application.Entities;
using StoneEntrevista.Application.Interfaces;

namespace StoneEntrevista.Infra.Data.Repositories
{
    public class MockFuncionariosRepo : IFuncionariosRepo
    {
        public List<Funcionario> BuscarFuncionarios()
        {
            List<Funcionario> funcionario = new List<Funcionario>
            {
                new Funcionario
				{
                    Matricula = "0009968",
                    Nome = "Victor Wilson",
					Area="Diretoria",
					Cargo="Diretor Financeiro",
                    SalarioBruto=12696.20,
                    DataAdmissao=new DateTime(2012, 01, 05)
                },
                new Funcionario
				{
					Matricula="0004468",
					Nome="Flossie Wilson",
					Area="Contabilidade",
					Cargo="Auxiliar de Contabilidade",
					SalarioBruto=1396.52,
					DataAdmissao=new DateTime(2015, 01, 05)
				},
                new Funcionario
				{
					Matricula="0008174",
					Nome="Sherman Hodges",
					Area="Relacionamento com o Cliente",
					Cargo="Líder de Relacionamento",
					SalarioBruto=3899.74,
					DataAdmissao=new DateTime(2015, 06, 07)
				},
                new Funcionario
				{
					Matricula="0007463",
					Nome="Charlotte Romero",
					Area="Financeiro",
					Cargo="Contador Pleno",
					SalarioBruto=3199.82,
					DataAdmissao=new DateTime(2018, 01, 03)
				},
				new Funcionario
				{
					Matricula="0005253",
					Nome="Wong Austin",
					Area="Financeiro",
					Cargo="Economista Júnior",
					SalarioBruto=2215.04,
					DataAdmissao=new DateTime(2016, 08, 27)
				},
				new Funcionario
				{
					Matricula="0004867",
					Nome="Danielle Blanchard",
					Area="Diretoria",
					Cargo="Auxiliar Administrativo",
					SalarioBruto=2768.28,
					DataAdmissao=new DateTime(2015, 10, 17)
				},
				new Funcionario
				{
					Matricula="0001843",
					Nome="Daugherty Kramer",
					Area="Serviços Gerais",
					Cargo="Atendente de Almoxarifado",
					SalarioBruto=2120.08,
					DataAdmissao=new DateTime(2016, 04, 21)
				}
            };

            return funcionario;
        }
    }
}