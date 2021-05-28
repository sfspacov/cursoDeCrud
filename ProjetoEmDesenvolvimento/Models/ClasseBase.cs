using System.Configuration;

namespace SiteWeb.Models
{
    public class ClasseBase
    {
        protected static string connectionString;
        public ClasseBase()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = "Server=localhost;Database=AulaCrud;User Id=sa;Password=Abcd123!;";
            }
        }
        //ConfigurationManager.ConnectionStrings["AulaCrud"].ConnectionString;
        public string Nome { get; set; }
    }
}