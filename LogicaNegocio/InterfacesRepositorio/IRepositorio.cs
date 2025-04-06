using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorio<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T? GetById(int id);
        IEnumerable<T> GetAll();
    }
}
