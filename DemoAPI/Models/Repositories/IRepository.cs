using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.Models
{
    public interface IRepository<T> : IDisposable
    {
        List<T> GetAll();
        T Get(int id);
        void Post(T item);
        void Put(T item);
        void Delete(int id);
        void Save();
    }
}
