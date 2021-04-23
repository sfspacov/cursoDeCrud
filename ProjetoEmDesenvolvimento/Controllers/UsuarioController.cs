using Microsoft.AspNetCore.Mvc;
using SiteWeb.Models;

namespace MeuCrud.Controllers
{
    public class UsuarioController : Controller
    {
        public void CriarNovoUsuario(Usuario usuario)
        {
            usuario.Salvar(usuario);

            //NÃO VAI TER A LÓGICA de Gravar os dados no Banco de Dados
        }

    }
}