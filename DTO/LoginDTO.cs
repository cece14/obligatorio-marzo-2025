using LogicaNegocio.EntidadesDominio;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
        public class LoginDTO
        {
            public string Email { get; set; }

            [Display(Name = "Contraseña")]
            public string Password { get; set; }
            public Rol Rol { get; set; }    
        }

    }
