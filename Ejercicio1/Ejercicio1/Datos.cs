using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Datos
    {
        AcademiaEntities context = new AcademiaEntities();
        public Estudiantes GetAlumno(int id)
        {
            return context.Estudiantes.Where(a => a.EstudentID == id).FirstOrDefault();
        }

        // Añadir
        public void añadir(Estudiantes st)
        {
            context.Estudiantes.Add(st);
            context.SaveChanges();
        }

        //Borrar
        public void delete(int id)
        {
            Estudiantes st = context.Estudiantes.Where(s => s.EstudentID == id).FirstOrDefault();
            if (st != null)
            {
                context.Estudiantes.Remove(st);
                context.SaveChanges();
            }
        }

        //Modificar
        public void modificar(Estudiantes stud)
        {
            context.Entry(stud).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Estudiantes GetPrimerAlumno()
        {
            return context.Estudiantes.FirstOrDefault();
        }

        public List<Estudiantes> GetAll()
        {
            try
            {
                return context.Estudiantes.Include("EstudianteDireccion").ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
