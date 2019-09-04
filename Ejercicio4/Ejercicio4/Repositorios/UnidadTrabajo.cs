using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.Repositorios
{
    public class UnidadTrabajo
    {
        private CentroMedicoEntities contexto = new CentroMedicoEntities();
        private RepositorioPaciente repositorioPaciente;
        private RepositorioMedico repositorioMedico;
        private RepositorioHistorial repositorioHistorial;
        private RepositorioCita repositorioCita;
        private RepositorioHorario repositorioHorario;

        public RepositorioPaciente RepositorioPaciente
        {
            get
            {
                if(this.repositorioPaciente == null)
                {
                    this.repositorioPaciente = new RepositorioPaciente(contexto);
                }
                return repositorioPaciente;
            }
        }

        public RepositorioMedico RepositorioMedico
        {
            get
            {
                if(this.repositorioMedico == null)
                {
                    this.repositorioMedico = new RepositorioMedico(contexto);
                }
                return repositorioMedico;
            }
        }

        public RepositorioHistorial RepositorioHistorial
        {
            get
            {
                if(this.repositorioHistorial == null)
                {
                    this.repositorioHistorial = new RepositorioHistorial(contexto);
                }
                return repositorioHistorial;
            }
        }

        public RepositorioCita RepositorioCita
        {
            get
            {
                if(this.repositorioCita == null)
                {
                    this.repositorioCita = new RepositorioCita(contexto);
                }
                return repositorioCita;
            }
        }

        public RepositorioHorario RepositorioHorario
        {
            get
            {
                if(this.repositorioHorario == null)
                {
                    this.repositorioHorario = new RepositorioHorario(contexto);
                }
                return repositorioHorario;
            }
        }
    }
}
