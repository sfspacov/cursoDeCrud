using System.Collections.Generic;
using System.Linq;

namespace SiteWeb.Models
{
    public class Cidade : ClasseBase
    {
        #region Propriedades
        public int Id { get; set; }
        public int IdUf { get; set; }
        #endregion

        #region Métodos
        public void Salvar(Cidade cidade)
        {

        }

        public List<Cidade> Listar(int idUf)
        {
            #region Criação de objetos
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

            var cidade3 = new Cidade
            {
                Id = 3,
                IdUf = 2,
                Nome = "Salvador"
            };

            var cidade4 = new Cidade
            {
                Id = 4,
                IdUf = 2,
                Nome = "Ilhéus"
            };

            var cidade5 = new Cidade
            {
                Id = 5,
                IdUf = 3,
                Nome = "Buzios"
            };

            var cidade6 = new Cidade
            {
                Id = 5,
                IdUf = 3,
                Nome = "Rio de Janeiro"
            };

            #endregion

            #region Lista de cidades
            var cidades = new List<Cidade>();

            cidades.Add(cidade1);
            cidades.Add(cidade2);
            cidades.Add(cidade3);
            cidades.Add(cidade4);
            cidades.Add(cidade5);
            cidades.Add(cidade6);
            #endregion

            var cidadesFiltradas = 
                cidades
                .Where(cidade => (cidade.IdUf == idUf))
                .ToList();

            return cidadesFiltradas;
        }
        #endregion

    }
}
