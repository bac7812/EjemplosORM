using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.Repositorios
{
    public class RepositorioPaciente : RepositorioGenerico<Usuarios>
    {
        public RepositorioPaciente(CentroMedicoEntities contexto) : base(contexto)
        {

        }
    }
}
