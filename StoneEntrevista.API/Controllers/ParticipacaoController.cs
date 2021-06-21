using Microsoft.AspNetCore.Mvc;
using StoneEntrevista.Application.Interfaces;
using StoneEntrevista.Application.Services;

namespace ParticipacaoLucros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipacaoController : ControllerBase
    {
        private readonly IFuncionariosRepo _funcionariosRepository;

        public ParticipacaoController(IFuncionariosRepo funcionariosRepository)
        {
            _funcionariosRepository = funcionariosRepository;
        }

        [HttpGet]
        public ActionResult CalcularParticipacao(
            [FromQuery(Name = "total_disponibilizado")] decimal totalDisponibilizado = 0
        )
        {
            if (totalDisponibilizado == 0)
            {
                return StatusCode(401, "Campo \"Total disponibilizado\" não pode estar zerado.");
            }

            ParticipacaoService participacaoService = new ParticipacaoService(totalDisponibilizado);

            var participacao = participacaoService.CalcularParticipacao(_funcionariosRepository.GetAll());

            if (participacao.TotalFuncionarios == 0)
            {
                return Content("Nenhum funcionário encontrado. Verifique a base de dados e tente novamente.");
            }

            if (participacao.SaldoTotalDisponibilizado < 0)
            {
                return Content("Infelizmente, valor disponibilizado foi menor que o valor distribuído.");
            }

            return Ok(participacao);
        }
    }
}