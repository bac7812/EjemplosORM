using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Ejercicio1.Repositorios
{
    public class RepositorioAlumnos : RepositorioGenerico<Estudiantes>
    {
        public RepositorioAlumnos(AcademiaEntities contexto) : base(contexto)
        {

        }
        //    AcademiaEntities contexto = new AcademiaEntities();
        //    public UnidadTrabajo unidadTrabajo = new UnidadTrabajo();
        //    AcademiaEntities contexto;

        //    public RepositorioAlumnos(AcademiaEntities contexto)
        //    {
        //        this.contexto = contexto;
        //    }

        //    public Estudiantes GetAlumno(int id)
        //    {
        //        return contexto.Estudiantes.Where(e => e.EstudianteID == id).FirstOrDefault();
        //    }

        //    // Añadir
        //    public void añadir(Estudiantes estudiante)
        //    {
        //        contexto.Estudiantes.Add(estudiante);
        //        contexto.SaveChanges();
        //    }

        //    //Modificar
        //    public void modificar(Estudiantes estudiante)
        //    {
        //        contexto.Entry(estudiante).State = System.Data.Entity.EntityState.Modified;
        //        contexto.SaveChanges();
        //    }

        //    //Borrar
        //    public void eliminar(int id)
        //    {
        //        Estudiantes estudiante = contexto.Estudiantes.Where(e => e.EstudianteID == id).FirstOrDefault();
        //        if (estudiante != null)
        //        {
        //            contexto.Estudiantes.Remove(estudiante);
        //            contexto.SaveChanges();
        //        }
        //    }

        //    //Mostrar el primer alumno
        //    public Estudiantes GetPrimerAlumno()
        //    {
        //        return contexto.Estudiantes.FirstOrDefault();
        //    }

        //    //Mostrar todos los alumnos
        //    public List<Estudiantes> GetAll()
        //    {
        //        try
        //        {
        //            return contexto.Estudiantes.Include("EstudianteDireccion").ToList();
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }
    }
}
