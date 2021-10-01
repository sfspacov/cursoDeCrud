using Crud.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Crud.Models
{
    public class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                var connectionName = "LocalConnection";
                connectionString = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json")
                .Build()
                .GetConnectionString(connectionName);
            }

        }
        protected static string connectionString;
        public int Id { get; set; }
        public string Name { get; set; }
    }
}