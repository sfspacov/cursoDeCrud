namespace SiteWeb.Models
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int IdCity { get; set; }

        public int Salvar(Usuario usuario)
        {
            if (ValidarCpf(usuario.CPF))
            {
                //Gravar no banco de dados
                return 3;
            }
            return 0;
        }

        private bool ValidarCpf(string CPF)
        {
            return true;
        }
    }
}