using Crud.Models;
using System.Collections.Generic;

namespace Crud.Interfaces
{
    public interface ICity : IBaseEntity
    {
        int IdUf { get; set; }
        IEnumerable<City> GetByIdUf(int idUf);
    }
}