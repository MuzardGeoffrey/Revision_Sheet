namespace RevisionSheet.DataAccess.IDataAccess
{
    internal interface IBaseDataAccess<T>
    {
        public T Create(T obj);

        public T Update(int id, T obj);

        public int Delete(int id);

        public T FindById(int id);
    }
}