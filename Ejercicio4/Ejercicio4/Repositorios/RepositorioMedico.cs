using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.Repositorios
{
    public class RepositorioMedico : RepositorioGenerico<Medicos>
    {
        public RepositorioMedico(CentroMedicoEntities contexto) : base(contexto)
        {

        }
    }
}
