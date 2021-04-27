using Microsoft.AspNetCore.Mvc;
using SiteWeb.Models;

namespace MeuCrud.Controllers
{
    public class UsuarioController : Controller
    {
        public void CriarNovoUsuario(Usuario usuario)
        {           
            usuario.Salvar(usuario);

            //NÃO TEM LÓGICA DE GRAVAR NO BANCO DE DADOS NA CONTROLLER
        }
    }
}