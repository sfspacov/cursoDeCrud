using System.Collections.Generic;

namespace SiteWeb.Models
{
    public class Estado : ClasseBase
    {
        public int Id { get; set; }
        public string Abbreviation { get; set; }

        public List<Estado> Listar()
        {
            #region Instancias de objetos
            var estado1 = new Estado();
            estado1.Id = 1;
            estado1.Abbreviation = "SP";
            estado1.Nome = "São Paulo";

            var estado2 = new Estado
            {
                Id = 2,
                Abbreviation = "BA",
                Nome = "Bahia"
            };

            var estado3 = new Estado
            {
                Id = 3,
                Abbreviation = "RJ",
                Nome = "Rio de Janeiro"
            };
            #endregion

            #region Lista de estados
            var estados = new List<Estado>();

            estados.Add(estado1);
            estados.Add(estado2);
            estados.Add(estado3);
            #endregion

            return estados;
        }
    }
}