//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Historiales
    {
        public int idHistoria { get; set; }
        public string usuario { get; set; }
        public string medico { get; set; }
        public string sintomas { get; set; }
        public string diagnostico { get; set; }
        public string tratamiento { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
    
        public virtual Medicos Medicos { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
