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
		private readonly IFuncionariosRepo _mockFuncionariosRepository;

   		public FuncionariosController(IFuncionariosRepo funcionariosRepository)
		{
			_mockFuncionariosRepository = funcionariosRepository;
		}

		/// <summary>
		/// Get the list of employees
		/// </summary>
		/// <returns>Employees list</returns>
		[HttpGet]
		public ActionResult <List<Funcionario>> getAll()
		{
			return Ok(_mockFuncionariosRepository.BuscarFuncionarios());
		}
	}
}