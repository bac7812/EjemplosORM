using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Repositorios
{
    public class RepositorioCursos : RepositorioGenerico<Cursos>
    {
        public RepositorioCursos(AcademiaEntities contexto) : base(contexto)
        {

        }
        //AcademiaEntities contexto = new AcademiaEntities();
        //public UnidadTrabajo unidadTrabajo = new UnidadTrabajo();
        //AcademiaEntities contexto;

        //public RepositorioCursos(AcademiaEntities contexto)
        //{
        //    this.contexto = contexto;
        //}

        //// Añadir
        //public void añadir(Cursos curso)
        //{
        //    contexto.Cursos.Add(curso);
        //    contexto.SaveChanges();
        //}

        ////Modificar
        //public void modificar(Cursos curso)
        //{
        //    contexto.Entry(curso).State = System.Data.Entity.EntityState.Modified;
        //    contexto.SaveChanges();
        //}

        ////Borrar
        //public void eliminar(int id)
        //{
        //    Cursos st = contexto.Cursos.Where(s => s.CursoId == id).FirstOrDefault();
        //    if (st != null)
        //    {
        //        contexto.Cursos.Remove(st);
        //        contexto.SaveChanges();
        //    }
        //}

        ////Mostrar un curso
        //public Cursos getCurso(int idCurso)
        //{
        //    return contexto.Cursos.Where(c => c.CursoId == idCurso).FirstOrDefault();
        //}

        ////Mostrar todos los cursos
        //public List<Cursos> getCursos()
        //{
        //    return contexto.Cursos.Include("Profesores").Include("Estudiantes").ToList();
        //}
    }
}
