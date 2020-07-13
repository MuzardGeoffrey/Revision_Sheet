using Revision_Sheet.BusinessObject;
using Revision_Sheet.IBusiness;
using RevisionSheet.DataAccess.DataAccess;
using RevisionSheet.DataAccess.Entities;
using RevisionSheet.DataAccess.IDataAccess;
using System.Collections.Generic;

namespace Revision_Sheet.Business
{
    public class UserBusiness : IUserBusiness
    {
        private IUserDataAccess userDataAccess = new UserDataAccess();

        public User Create(User user)
        {
            if (user != null)
            {
                UserEntity userEntity = new UserEntity();
                userEntity = userDataAccess.Create(user.UserEntityConvertion());
                return userEntity.UserConvertion();
            }
            return null;
        }

        public bool Delete(int id)
        {
            userDataAccess.Delete(id);
            return true;
        }

        public List<User> FindAll()
        {
            List<User> users = new List<User>();

            foreach (var userData in userDataAccess.FindAllUser())
            {
                users.Add(userData.UserConvertion());
            }

            return users;
        }

        public User FindById(int id)
        {
            return userDataAccess.FindById(id).UserConvertion();
        }

        public User Login(User user)
        {
            if (userDataAccess.Login(user.UserEntityConvertion()))
            {
                return user;
            }
            return null;
        }

        public User Update(int id, User user)
        {
            UserEntity userEntities = new UserEntity();
            userEntities = userDataAccess.Update(id, user.UserEntityConvertion());
            return userEntities.UserConvertion();
        }
    }
}