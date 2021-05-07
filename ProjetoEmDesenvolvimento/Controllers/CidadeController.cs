using Microsoft.AspNetCore.Mvc;
using SiteWeb.Models;
using System.Collections.Generic;

namespace SiteWeb.Controllers
{
    public class CidadeController : Controller
    {
        public List<Cidade> ObterCidades(int idUf)
        {
            var cidade = new Cidade();
            return cidade.Listar(idUf);
        }
    }
}