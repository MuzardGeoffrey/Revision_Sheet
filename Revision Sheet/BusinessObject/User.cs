using RevisionSheet.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revision_Sheet.BusinessObject
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public User(User user)
        {
            this.Id = user.Id;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Login = user.Login;
            this.Password = user.Password;
        }

        public User(string firstName, string lastName, string login, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Login = login;
            this.Password = password;
        }

        public User(int id, string firstName, string lastName, string login, string password)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Login = login;
            this.Password = password;
        }

        public User(UserEntity userEntities)
        {
            this.Id = userEntities.Id;
            this.FirstName = userEntities.FirstName;
            this.LastName = userEntities.LastName;
            this.Login = userEntities.Login;
            this.Password = userEntities.Password;

        }

        public User()
        {
        }
    }
}
