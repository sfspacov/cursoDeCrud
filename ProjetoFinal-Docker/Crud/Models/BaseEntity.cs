using Crud.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace Crud.Models
{
    public class BaseEntity : IBaseEntity
    {

        public BaseEntity()
        {
            var envVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToLower();

            if (string.IsNullOrEmpty(connectionString))
            {
                var connectionName = "DockerConnection";
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