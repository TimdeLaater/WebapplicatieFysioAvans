using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainServices
{
    public interface IRepo<T>
    {
        public List<T> Get();
        public T Get(T entity);
        public void Create(T entity);
    }
}
