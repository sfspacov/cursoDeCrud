using Microsoft.AspNetCore.Mvc;
using SiteWeb.Models;
using System.Collections.Generic;

namespace SiteWeb.Controllers
{
    public class EstadoController : Controller
    {
        public List<Estado> Listar()
        {
            return new Estado().Listar();
        }
    }
}