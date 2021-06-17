using System.Collections.Generic;
using StoneEntrevista.Application.Entities;

namespace StoneEntrevista.Application.Interfaces
{
    public interface IFuncionariosRepo
    {
        public List<Funcionario> BuscarFuncionarios();
    }
}