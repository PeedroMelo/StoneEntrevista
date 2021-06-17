using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StoneEntrevista.Application.Interfaces;
using StoneEntrevista.Application.Services;

namespace ParticipacaoLucros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipacaoController : ControllerBase
    {
        private readonly IFuncionariosRepo _mockFuncionariosRepository;

        public ParticipacaoController(IFuncionariosRepo funcionariosRepository)
        {
            _mockFuncionariosRepository = funcionariosRepository;
        }

        [HttpGet]
        public ActionResult CalcularParticipacao()
        {
            ParticipacaoService participacaoService = new ParticipacaoService();

            var participacao = participacaoService.CalcularParticipacao(_mockFuncionariosRepository.BuscarFuncionarios());
            return Ok(participacao);
        }
    }
}