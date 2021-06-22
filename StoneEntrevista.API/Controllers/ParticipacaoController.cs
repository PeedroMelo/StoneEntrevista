using Microsoft.AspNetCore.Mvc;
using StoneEntrevista.Application.Interfaces;
using StoneEntrevista.Application.Services;
using StoneEntrevista.Application.Helpers;

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

            DistribuicaoLucrosService distribuicaoLucrosService = new DistribuicaoLucrosService(totalDisponibilizado);

            var distribuicao = distribuicaoLucrosService.CalcularDistribuicao(_funcionariosRepository.GetAll());

            if (distribuicao.TotalFuncionarios == 0)
            {
                return Content("Nenhum funcionário encontrado. Verifique a base de dados e tente novamente.");
            }

            if (distribuicao.SaldoTotalDisponibilizado < 0)
            {
                return Content("Infelizmente, valor disponibilizado foi menor que o valor distribuído.");
            }

            return Ok(new
            {
                total_funcionarios = distribuicao.TotalFuncionarios,
                total_distribuidos = CurrencySerializer.DecimalToString(distribuicao.TotalDistribuido),
                total_disponibilizado = CurrencySerializer.DecimalToString(distribuicao.TotalDisponibilizado),
                saldo_total_disponibilizado = CurrencySerializer.DecimalToString(distribuicao.SaldoTotalDisponibilizado),
                distribuicao.Participacoes
            });
        }
    }
}