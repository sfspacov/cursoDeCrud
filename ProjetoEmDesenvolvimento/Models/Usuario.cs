using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SiteWeb.Models
{
    public class Usuario : ClasseBase
    {
        private string procName = "";
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
        public int IdUf { get; set; }
        #endregion

        #region Methods
        public void Salvar(Usuario usuario)
        {
            try
            {
                using (var conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    procName = @$"INSERT INTO usuario 
                                VALUES ('{usuario.CPF}', {usuario.IdCity}, '{usuario.Nome}')";

                    var comando = new SqlCommand(procName, conexao);
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

        internal void Editar(Usuario user)
        {
            try
            {
                using (var conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    procName = @$"
                                UPDATE Usuario
                                SET     
                                    IdCity = @idCity,
                                    Nome = @nome
                                WHERE CPF = @cpf";

                    var comando = new SqlCommand(procName, conexao);
                    comando.Parameters.AddWithValue("@idCity", user.IdCity);
                    comando.Parameters.AddWithValue("@nome", user.Nome);
                    comando.Parameters.AddWithValue("@cpf", user.CPF);

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

        internal void Deletar(string cpf)
        {
            try
            {
                using (var conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    procName = "DeleteUsuario";

                    var comando = new SqlCommand(procName, conexao);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@cpf", cpf);

                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel salvar o usuario, tente mais tarde");
            }
        }

        public List<Usuario> Listar()
        {
            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Open();
                procName = "ListarUsuario";
                var comando = new SqlCommand(procName, conexao);
                comando.CommandType = CommandType.StoredProcedure;
                var reader = comando.ExecuteReader();
                var users = new List<Usuario>();

                while (reader.Read())
                {
                    var usuario = new Usuario
                    {
                        Nome = (string)reader["Nome"],
                        CPF = (string)reader["CPF"],
                        Cidade = (string)reader["Cidade"],
                        IdCity = (int)reader["IdCity"],
                        IdUf = (int)reader["IdUf"]
                    };

                    users.Add(usuario);
                }

                return users;
            }
        }
        #endregion
    }
}