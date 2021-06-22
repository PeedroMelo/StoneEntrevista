using System.Collections.Generic;
using StoneEntrevista.Application.Entities;

namespace StoneEntrevista.Application.Interfaces
{
    public interface IDistribuicaoLucrosService
    {
        DistribuicaoLucros CalcularDistribuicao(List<Funcionario> funcionario);
    }
}