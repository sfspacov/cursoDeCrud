using Microsoft.AspNetCore.Mvc;
using SiteWeb.Models;
using System;
using System.Collections.Generic;

namespace SiteWeb.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpPost]
        public bool CriarNovoUsuario([FromBody]Usuario user)
        {
            if (user.CPF == "" || user.Nome == "" || user.IdCity == 0)
            {
                throw new Exception("Dados inválidos");
            }
            else
            {
                user.Salvar(user);
                return true;
            }
        }

        public List<Usuario> Get()
        {
            var usuario = new Usuario();
            var usuarios = usuario.Listar();
            return usuarios;
        }
    }
}