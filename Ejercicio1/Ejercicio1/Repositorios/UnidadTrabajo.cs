using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio1.Repositorios;

namespace Ejercicio1.Repositorios
{
    public class UnidadTrabajo
    {
        private AcademiaEntities contexto = new AcademiaEntities();
        private RepositorioAlumnos repositorioAlumnos;
        private RepositorioCursos repositorioCursos;

        public RepositorioAlumnos RepositorioAlumno
        {
            get
            {
                if (this.repositorioAlumnos == null)
                {
                    this.repositorioAlumnos = new RepositorioAlumnos(contexto);
                }
                return repositorioAlumnos;
            }
        }

        public RepositorioCursos RepositorioCurso
        {
            get
            {
                if (this.repositorioCursos == null)
                {
                    this.repositorioCursos = new RepositorioCursos(contexto);
                }
                return repositorioCursos;
            }
        }
    }
}
