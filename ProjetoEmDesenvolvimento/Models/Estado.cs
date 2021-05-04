using System.Collections.Generic;

namespace SiteWeb.Models
{
    public class Estado : ClasseBase
    {
        public int Id { get; set; }
        public string Abbreviation { get; set; }

        public List<Estado> Listar()
        {
            var estado1 = new Estado();
            estado1.Id = 1;
            estado1.Abbreviation = "SP";
            estado1.Nome = "São Paulo";

            var estado2 = new Estado
            {
                Id = 2,
                Abbreviation = "PR",
                Nome = "Paraná"
            };

            var estados = new List<Estado>();

            estados.Add(estado1);
            estados.Add(estado2);

            return estados;
        }
    }
}