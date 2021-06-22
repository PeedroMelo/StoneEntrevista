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
        /// Get the list of employees
        /// </summary>
        /// <returns>Employees list</returns>
        [HttpGet]
        public ActionResult<List<Funcionario>> getAll()
        {
            return Ok(_funcionariosRepository.GetAll());
        }

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