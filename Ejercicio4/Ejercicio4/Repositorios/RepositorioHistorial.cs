﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.Repositorios
{
    public class RepositorioHistorial : RepositorioGenerico<Historiales>
    {
        public RepositorioHistorial(CentroMedicoEntities contexto) : base(contexto)
        {

        }
    }
}
