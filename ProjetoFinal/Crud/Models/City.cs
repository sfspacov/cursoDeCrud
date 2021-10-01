using Crud.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Crud.Models
{
    public class City : BaseEntity, ICity
    {
        public int IdUf { get; set; }
        public bool IsCapital { get; set; }

        public int Create(City city)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                var command = "INSERT INTO Cidade (Name, IdUf, Capital) OUTPUT Inserted.Id VALUES (@Name, @IdUf, @Capital)";

                var sqlCommand = new SqlCommand(command, connection);

                sqlCommand.Parameters.AddWithValue("@Capital", city.IsCapital);
                sqlCommand.Parameters.AddWithValue("@Name", city.Name);
                sqlCommand.Parameters.AddWithValue("@IdUf", city.IdUf);
                return (int)sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<City> GetByIdUf(int idUf)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                var query = "SELECT Id, Name, IdUf, Capital FROM Cidade WHERE IdUF = @IdUf ORDER BY Name";

                var sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@IdUf", idUf);

                var reader = sqlCommand.ExecuteReader();

                var cidades = new List<City>();

                while (reader.Read())
                {
                    var city = new City
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        IdUf = (int)reader["IdUf"],
                        IsCapital = (bool)reader["Capital"]
                    };

                    cidades.Add(city);
                }

                return cidades;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
