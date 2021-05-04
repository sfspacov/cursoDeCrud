using System.Collections.Generic;

namespace SiteWeb.Models
{
    public class Cidade : ClasseBase
    {
        public int Id { get; set; }
        public int IdUf { get; set; }

        public void Salvar(Cidade cidade)
        {

        }

        public List<Cidade> Listar(int idUf)
        {
            var cidade1 = new Cidade();
            cidade1.Id = 1;
            cidade1.IdUf = 1;
            cidade1.Nome = "Santos";

            var cidade2 = new Cidade
            {
                Id = 2,
                IdUf = 1,
                Nome = "Guarulhos"
            };

            var cidades = new List<Cidade>();

            cidades.Add(cidade1);
            cidades.Add(cidade2);

            return cidades;
        }
    }
}