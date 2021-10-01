using Crud.Dto;
using Crud.Models;
using System.Collections.Generic;

namespace Crud.Interfaces
{
    public interface IUsuario : IBaseEntity
    {
        string Cpf { get; set; }
        int IdCity { get; set; }
        void Delete(string cpf);
        IEnumerable<Usuario> Get(string cpf = null);
        void Save(UsuarioDto user);
        void Update(UsuarioDto user);
    }
}