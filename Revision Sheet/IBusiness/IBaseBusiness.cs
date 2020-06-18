using System;
using System.Collections.Generic;

namespace Revision_Sheet.IBusiness
{
    internal interface IBaseBusiness<T>
    {
        public T Create(T obj);

        public Boolean Delete(int id);

        public List<T> FindAll();

        public T FindById(int id);

        public T Update(int id, T obj);
    }
}