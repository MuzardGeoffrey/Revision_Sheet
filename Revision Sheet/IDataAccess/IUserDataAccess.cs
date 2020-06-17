using RevisionSheet.DataAccess.DataAccess;
using RevisionSheet.DataAccess.Entities;
using System.Collections.Generic;

namespace RevisionSheet.DataAccess.IDataAccess
{
    internal interface IUserDataAccess : IBaseDataAccess<UserEntities>
    {
        public List<UserEntities> FindAllUser();
    }
}