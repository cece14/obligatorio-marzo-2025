using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    public class Email
    {
        public string Valor { get; set; }

        public Email(string valor)
        {
            Valor = valor;
            // validación acá si querés
        }

        private Email() { } // requerido por EF
    }
}
