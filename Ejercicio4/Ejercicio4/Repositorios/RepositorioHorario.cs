using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.Repositorios
{
    public class RepositorioHorario : RepositorioGenerico<Horarios>
    {
        public RepositorioHorario(CentroMedicoEntities contexto) : base(contexto)
        {

        }
    }
}
