using RevisionSheet.DataAccess.Entities;
using System.Collections.Generic;

namespace RevisionSheet.DataAccess.IDataAccess
{
    internal interface IUserDataAccess : IBaseDataAccess<UserEntity>
    {
        public List<UserEntity> FindAllUser();
        public bool Login(UserEntity user);
    }
}