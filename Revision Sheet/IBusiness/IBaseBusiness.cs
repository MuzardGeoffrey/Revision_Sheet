using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revision_Sheet.IBusiness
{
    interface IBaseBusiness<T>
    {
        public T Create(T obj);
        public Boolean Delete(int id);
        public List<T> FindAll();
        public T FindById(int id);
        public T Update(int id, T obj);
    }
}
