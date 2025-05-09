using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Seguimiento
    {
        public int Id { get; set; }

        public Estado Estado { get; set; }
        public DateTime FechaHora { get; set; }
        public string Comentario { get; set; }

        public Envio Envio { get; set; } // relación inversa
    }
}
