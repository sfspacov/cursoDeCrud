using Microsoft.AspNetCore.Mvc;
using SiteWeb.Models;
using System.Collections.Generic;

namespace SiteWeb.Controllers
{
    public class EstadoController : Controller
    {
        public List<Estado> ObterEstados()
        {
            var estado = new Estado();
            return estado.Listar();
        }
    }
}