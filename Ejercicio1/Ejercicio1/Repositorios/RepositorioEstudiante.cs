using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.dal
{
    class RepositorioEstudiante: RepositorioGeneral<Estudiantes>
    {
        public RepositorioEstudiante(AcademiaEntities contexto) : base(contexto)
        {

        }
    }
}
