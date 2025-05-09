using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class EnvioEstandar : Envio
    {
        public override double CalcularEficiencia()
        {
            if (FechaEstimadaEntrega == default || FechaEntrega == default)
                return 0;

            var horasEstimadas = (FechaEstimadaEntrega - FechaSalida).TotalHours;
            var horasReales = (FechaEntrega - FechaSalida).TotalHours;

            return (horasEstimadas / horasReales) * 100;
        }
    }
}
