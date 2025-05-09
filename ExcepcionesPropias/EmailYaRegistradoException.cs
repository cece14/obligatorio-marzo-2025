using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class EmailYaRegistradoException : Exception
    {
        public EmailYaRegistradoException(string email)
            : base($"Ya existe un empleado con el email: {email}") { }
    }
}
