using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SiteWeb.Models
{
    public class Cidade : ClasseBase
    {
        public Cidade()
        {

        }
        public Cidade(string nomeDaCidade)
        {
            Nome = nomeDaCidade;
        }

        #region Propriedades
        public int Id { get; set; }
        public int IdUf { get; set; }
        public bool IsCapital { get; set; }
        #endregion

        #region Métodos

        public List<Cidade> Listar(int idUf)
        {
            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                var scriptSelect = @"SELECT 
                                        Id, 
                                        Nome, 
                                        IdUf, 
                                        IsCapital 
                                    FROM
                                        Cidade 
                                    WHERE 
                                        IdUF = @IdUf
                                    ORDER BY 
                                        Nome";
                
                var comando = new SqlCommand(scriptSelect, conexao);
                comando.Parameters.AddWithValue("@IdUf", idUf);

                var reader = comando.ExecuteReader();

                var cidades = new List<Cidade>();

                while (reader.Read())
                {
                    var city = new Cidade
                    {
                        Id = (int)reader["Id"],
                        Nome = (string)reader["Nome"],
                        IdUf = (int)reader["IdUf"],
                        IsCapital = (bool)reader["IsCapital"]
                    };

                    cidades.Add(city);
                }

                return cidades;
            }

        }
        #endregion

    }
}