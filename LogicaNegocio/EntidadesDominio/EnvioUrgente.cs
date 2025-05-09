using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class EnvioUrgente : Envio
    {
        public bool TienePrioridad { get; set; }

        public override double CalcularEficiencia()
        {
            var horasEstimadas = (FechaEstimadaEntrega - FechaSalida).TotalHours;
            var horasReales = (FechaEntrega - FechaSalida).TotalHours;

            double eficienciaBase = (horasEstimadas / horasReales) * 100;

            // Penalización si no cumple con prioridad
            return TienePrioridad && FechaEntrega > FechaEstimadaEntrega
                ? eficienciaBase * 0.8
                : eficienciaBase;
        }
    }
}
