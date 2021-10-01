using Crud.Dto;
using Crud.Interfaces;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Crud.Models
{
    public class Usuario : BaseEntity, IUsuario
    {
        public string Cpf { get; set; }
        public int IdUf { get; set; }
        public int IdCity { get; set; }
        public string City { get; private set; }

        public void Delete(string cpf)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = "DELETE FROM Usuario WHERE Cpf = @Cpf";
                    var sqlCommand = new SqlCommand(command, connection);
                    sqlCommand.Parameters.AddWithValue("@Cpf", cpf);
                    sqlCommand.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Usuario> Get(string cpf = null)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = "SELECT u.Name,u.Cpf,c.Name as City,c.Id as IdCity,c.IdUf FROM Usuario u JOIN Cidade c ON u.IdCity = c.Id WHERE cpf = ISNULL(@Cpf,cpf)";

                    var sqlCommand = new SqlCommand(query, connection);

                    sqlCommand.Parameters.AddWithValue("@Cpf", string.IsNullOrEmpty(cpf) ? DBNull.Value : cpf);

                    var reader = sqlCommand.ExecuteReader();

                    var users = new List<Usuario>();

                    while (reader.Read())
                    {
                        var city = new Usuario
                        {
                            Name = (string)reader["Name"],
                            Cpf = (string)reader["CPF"],
                            IdCity = (int)reader["IdCity"],
                            City = (string)reader["City"],
                            IdUf = (int)reader["IdUf"],
                        };

                        users.Add(city);
                    }

                    return users;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Save(UsuarioDto user)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = "INSERT INTO Usuario (Name, Cpf, IdCity) VALUES (@Name, @Cpf, @IdCity)";

                    var sqlCommand = new SqlCommand(command, connection);

                    sqlCommand.Parameters.AddWithValue("@Name", user.Name);
                    sqlCommand.Parameters.AddWithValue("@Cpf", user.Cpf);
                    sqlCommand.Parameters.AddWithValue("@IdCity", user.IdCity);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(UsuarioDto user)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var command = "UPDATE Usuario SET Name = @Name, CPF = @NewCpf, IdCity = @IdCity WHERE cpf=@Cpf";

                    var sqlCommand = new SqlCommand(command, connection);

                    sqlCommand.Parameters.AddWithValue("@NewCpf", user.NewCpf);
                    sqlCommand.Parameters.AddWithValue("@Name", user.Name);
                    sqlCommand.Parameters.AddWithValue("@Cpf", user.Cpf);
                    sqlCommand.Parameters.AddWithValue("@IdCity", user.IdCity);
                    sqlCommand.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}