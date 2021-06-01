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
#if DEBUG
                connectionString = "Server=localhost;Database=AulaCrud;User Id=sa;Password=Abcd123!;";
#else
                connectionString = "Server=tcp:aulacrud2.database.windows.net,1433;Initial Catalog=AulaCrud;Persist Security Info=False;User ID=superadmin;Password=Abcd123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
#endif
            }
        }
        //ConfigurationManager.ConnectionStrings["AulaCrud"].ConnectionString;
        public string Nome { get; set; }
    }
}