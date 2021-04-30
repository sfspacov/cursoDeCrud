using Microsoft.AspNetCore.Mvc;
using SiteWeb.Models;
using System;

namespace MeuCrud.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpPost]
        public bool CriarNovoUsuario([FromBody]Usuario user)
        {
            if (user.CPF == "" || user.Nome == "" || user.IdCity == 0)
            {
                throw new Exception("Preencha todos os campos");
            }
            else
            {
                user.Salvar(user);
                return true;
            }
            

            //NÃO TEM LÓGICA DE GRAVAR NO BANCO DE DADOS NA CONTROLLER
        }
    }
}