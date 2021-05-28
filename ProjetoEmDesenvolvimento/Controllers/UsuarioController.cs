using Microsoft.AspNetCore.Mvc;
using SiteWeb.Models;
using System;
using System.Collections.Generic;

namespace SiteWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private Usuario usuario = new Usuario();

        [HttpPut]
        public void Editar([FromBody] Usuario user)
        {
            user.Editar(user);
        }

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

        [HttpGet]
        public List<Usuario> Get()
        {           
            var usuarios = usuario.Listar();
            return usuarios;
        }

        [HttpDelete]
        public void Delete(string cpf)
        {
            usuario.Deletar(cpf);
        }
    }
}