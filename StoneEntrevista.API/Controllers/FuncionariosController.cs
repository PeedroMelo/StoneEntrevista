using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StoneEntrevista.Application.Entities;
using StoneEntrevista.Application.Interfaces;

namespace StoneEntrevista.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionariosRepo _funcionariosRepository;

        public FuncionariosController(IFuncionariosRepo funcionariosRepository)
        {
            _funcionariosRepository = funcionariosRepository;
        }

        /// <summary>
        /// Retorna a lista completa dos funcionários cadastrados no sistema.
        /// </summary>
        /// <returns>Lista de funcionários</returns>
        [HttpGet]
        public ActionResult<List<Funcionario>> getAll()
        {
            return Ok(_funcionariosRepository.GetAll());
        }

        /// <summary>
        /// Retorna o funcionário baseado em seu número de matrícula.
        /// </summary>
        /// <param name="matricula">Número da martícula. Ex: 0007676</param>
        /// <returns>Objeto contendo os dados do funcionário.</returns>
        [HttpGet("{matricula}", Name = "GetFuncionarioByMatricula")]
        public ActionResult<Funcionario> GetFuncionarioByMatricula(string matricula)
        {
            var funcionario = _funcionariosRepository.GetById(matricula);
            if (funcionario == null)
            {
                return NotFound(new
                {
                    message = "Nenhum funcionário encontrado com o ID enviado."
                });
            }
            return Ok(_funcionariosRepository.GetById(matricula));
        }

        /// <summary>
        /// Cadastro de um novo usuário.
        /// </summary>
        /// <param name="funcionario">Objeto com os dados do funcionário.</param>
        /// <returns>Objeto contendo os dados do funcionário.</returns>
        [HttpPost]
        public ActionResult<Funcionario> AddFuncionario(Funcionario funcionario)
        {
            Funcionario funcionarioData = _funcionariosRepository.GetById(funcionario.Matricula);

            if (funcionarioData == null)
            {
                _funcionariosRepository.Add(funcionario);
            }

            return Ok(_funcionariosRepository.GetById(funcionario.Matricula));
        }
    }
}