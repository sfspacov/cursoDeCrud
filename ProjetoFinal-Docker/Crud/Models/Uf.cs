using Crud.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Crud.Models
{
    public class Uf : BaseEntity, IUf
    {
        public string Abbreviation { get; set; }

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
