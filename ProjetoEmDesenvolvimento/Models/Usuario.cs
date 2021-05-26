using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SiteWeb.Models
{
    public class Usuario : ClasseBase
    {
        public Usuario()
        {

        }

        public Usuario(string nome)
        {
            Nome = nome;
        }

        #region Properties
        public string CPF { get; set; }
        public int IdCity { get; set; }
        public string Cidade { get; set; }
        #endregion

        #region Methods
        public void Salvar(Usuario usuario)
        {
            try
            {
                var connectionString = "Server=localhost;Database=AulaCrud;Trusted_Connection=True;";

                using (var conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    var scriptInsert = @$"INSERT INTO usuario 
                                VALUES ('{usuario.CPF}', {usuario.IdCity}, '{usuario.Nome}')";

                    var comando = new SqlCommand(scriptInsert, conexao);
                    comando.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232060)
                {
                    throw new Exception("CPF não pode ser nulo");
                }
                else
                {
                    throw new Exception("Não foi possivel salvar o usuario, tente mais tarde");
                }
            }
        }
        public List<Usuario> Listar()
        {
            var connectionString = "Server=localhost;Database=AulaCrud;Trusted_Connection=True;";

            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                var scriptSelect = @"
                                    SELECT
	                                    CPF    
                                        ,u.Nome
	                                    ,c.Nome Cidade
                                    FROM Usuario AS u
                                    JOIN Cidade AS c ON u.IdCity = c.Id
                                    ";

                var comando = new SqlCommand(scriptSelect, conexao);
                var reader = comando.ExecuteReader();
                var users = new List<Usuario>();

                while (reader.Read())
                {
                    var usuario = new Usuario
                    {
                        Nome = (string)reader["Nome"],
                        CPF = (string)reader["CPF"],
                        Cidade = (string)reader["Cidade"],
                    };

                    users.Add(usuario);
                }

                return users;
            }
        }
        private bool ValidarCpf(string CPF)
        {
            return true;
        }
        #endregion
    }
}