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
					// Cargo = new Cargo { CargoDescricao="Diretor Financeiro", Area = new Area { AreaDescricao="Diretoria" }},
					Area="Diretoria",
					Cargo="Diretor Financeiro",
                    SalarioBruto=12696.20,
                    DataAdmissao=new DateTime(2012, 01, 05)
                },
                new Funcionario
				{
					Matricula="0004468",
					Nome="Flossie Wilson",
					// Cargo = new Cargo { CargoDescricao="Auxiliar de Contabilidade", Area = new Area { AreaDescricao="Contabilidade" }},
					Area="Contabilidade",
					Cargo="Auxiliar de Contabilidade",
					SalarioBruto=1396.52,
					DataAdmissao=new DateTime(2015, 01, 05)
				},
                new Funcionario
				{
					Matricula="0009968",
					Nome="Victor Wilson",
					// Cargo = new Cargo { CargoDescricao="Líder de Relacionamento", Area = new Area { AreaDescricao="Relacionamento com o Cliente" }},
					Area="Relacionamento com o Cliente",
					Cargo="Líder de Relacionamento",
					SalarioBruto=3899.74,
					DataAdmissao=new DateTime(2015, 06, 07)
				},
                new Funcionario
				{
					Matricula="0007463",
					Nome="Charlotte Romero",
					// Cargo = new Cargo { CargoDescricao="Contador Pleno", Area = new Area { AreaDescricao="Financeiro" }},
					Area="Financeiro",
					Cargo="Contador Pleno",
					SalarioBruto=3199.82,
					DataAdmissao=new DateTime(2018, 01, 03)
				}
            };

            return funcionario;
        }
    }
}