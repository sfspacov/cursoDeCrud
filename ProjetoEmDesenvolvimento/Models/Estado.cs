using System.Collections.Generic;
using System.Data.SqlClient;

namespace SiteWeb.Models
{
    public class Estado : ClasseBase
    {
        public int Id { get; set; }
        public string Abbreviation { get; set; }

        public List<Estado> Listar()
        {
            var connectionString = "Server=localhost;Database=AulaCrud;Trusted_Connection=True;";

            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                var query = "SELECT Id, Nome, Abbreviation FROM Uf ORDER BY Nome";

                var sqlCommand = new SqlCommand(query, conexao);

                var reader = sqlCommand.ExecuteReader();

                var ufs = new List<Estado>();

                while (reader.Read())
                {
                    var uf = new Estado
                    {
                        Id = (int)reader["Id"],
                        Nome = (string)reader["Nome"],
                        Abbreviation = (string)reader["Abbreviation"]
                    };

                    ufs.Add(uf);
                }

                return ufs;
            }
        }
    }
}