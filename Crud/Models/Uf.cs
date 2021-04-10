using Crud.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Crud.Models
{
    public class Uf : BaseEntity, IUf
    {
        public string Abbreviation { get; set; }

        public int Create(Uf uf)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = "INSERT INTO Uf (Name, Abbreviation) OUTPUT Inserted.Id VALUES (@Name, @Abbreviation)";

                    var sqlCommand = new SqlCommand(command, connection);

                    sqlCommand.Parameters.AddWithValue("@Id", uf.Id);
                    sqlCommand.Parameters.AddWithValue("@Name", uf.Name);
                    sqlCommand.Parameters.AddWithValue("@Abbreviation", uf.Abbreviation);
                    return (int)sqlCommand.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Uf> GetAll()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = "SELECT Id, Name, Abbreviation FROM Uf ORDER BY Name";

                    var sqlCommand = new SqlCommand(query, connection);

                    var reader = sqlCommand.ExecuteReader();

                    var ufs = new List<Uf>();

                    while (reader.Read())
                    {
                        var uf = new Uf
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Abbreviation = (string)reader["Abbreviation"]
                        };

                        ufs.Add(uf);
                    }

                    return ufs;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
