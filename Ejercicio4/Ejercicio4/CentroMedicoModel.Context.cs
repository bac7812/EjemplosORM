﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ejercicio4
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CentroMedicoEntities : DbContext
    {
        public CentroMedicoEntities()
            : base("name=CentroMedicoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Citas> Citas { get; set; }
        public virtual DbSet<Especialidades> Especialidades { get; set; }
        public virtual DbSet<Historiales> Historiales { get; set; }
        public virtual DbSet<Horarios> Horarios { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<ServicioMedico> ServicioMedico { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
