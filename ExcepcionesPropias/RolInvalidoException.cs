using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class RolInvalidoException : Exception
    {
        public RolInvalidoException(string mensaje) : base(mensaje) { }
    }
}
