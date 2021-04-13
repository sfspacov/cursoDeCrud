using Crud.Models;
using System.Collections.Generic;

namespace Crud.Interfaces
{
    public interface IUf
    {
        string Abbreviation { get; set; }
        IEnumerable<Uf> GetAll();
    }
}