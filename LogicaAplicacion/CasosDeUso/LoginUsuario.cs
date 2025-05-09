using DTO.Mappers;
using DTO;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;

namespace LogicaAplicacion.CasosDeUso
{
    public class LoginUsuario : ILoginUsuario
    {
        public IRepositorioUsuarios RepoUsuarios { get; set; }

        public LoginUsuario(IRepositorioUsuarios repo)
        {
            RepoUsuarios = repo;
        }

        public ListadoUsuariosDTO Login(string email, string password)
        {
            Usuario usu = RepoUsuarios.Login(email, password);
            return UsuariosMapper.ToDTO(usu);
        }
    }
}

