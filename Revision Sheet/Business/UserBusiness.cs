using Revision_Sheet.BusinessObject;
using Revision_Sheet.IBusiness;
using RevisionSheet.DataAccess.DataAccess;
using RevisionSheet.DataAccess.Entities;
using RevisionSheet.DataAccess.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revision_Sheet.Business
{
    public class UserBusiness : IUserBusiness
    {
        private IUserDataAccess userDataAccess = new UserDataAccess();
        public User Create(User user)
        {
            if (user != null)
            {
                UserEntities userEntities = new UserEntities(user);
                User userReturn = new User( userDataAccess.Create(userEntities));
                return userReturn;
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
                User user = new User(userData);
                users.Add(user);
            }

            return users;
        }

        public User FindById(int id)
        {
            User user = new User(userDataAccess.FindById(id));
            return user;
        }

        public User Update(int id, User obj)
        {
            UserEntities userEntities = new UserEntities(obj);
            User user = new User(userDataAccess.Update(id, userEntities));
            return user;
        }
    }
}
