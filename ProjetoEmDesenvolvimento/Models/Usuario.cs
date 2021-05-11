using System.Collections.Generic;

namespace SiteWeb.Models
{
    public class Usuario : ClasseBase
    {
        #region Properties
        public string CPF { get; set; }
        public int IdCity { get; set; }
        #endregion

        #region Methods
        public int Salvar(Usuario usuario)
        {
            if (ValidarCpf(usuario.CPF))
            {
                //Gravar no banco de dados
                return 3;
            }
            return 0;
        }
        public List<Usuario> Listar()
        {
            #region Instancias de objetos
            var usuario1 = new Usuario
            {
                CPF = "381.376.970-47",
                Nome = "João da Silva",
                IdCity = 1
            };

            var usuario2 = new Usuario
            {
                CPF = "833.697.670-15",
                Nome = "Maria da Penha",
                IdCity = 2
            };
            #endregion

            #region Lista de estados
            var usuarios = new List<Usuario> 
            { 
                usuario1,
                usuario2
            };
            #endregion

            return usuarios;
        }
        private bool ValidarCpf(string CPF)
        {
            return true;
        }
        #endregion
    }
}