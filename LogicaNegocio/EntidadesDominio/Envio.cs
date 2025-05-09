using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public abstract class Envio
    {
        public int Id { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaEstimadaEntrega { get; set; }
        public DateTime FechaEntrega { get; set; }

        public bool SeRetiraEnAgencia { get; set; }

        public Agencia AgenciaDeRetiro { get; set; } // null si se entrega a domicilio

        public Estado EstadoActual { get; set; }
        public Cliente Cliente { get; set; }
        public List<Seguimiento> Seguimientos { get; set; } = new();

        public abstract double CalcularEficiencia();
    }
}
