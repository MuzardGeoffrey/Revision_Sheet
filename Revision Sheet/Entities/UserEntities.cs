using Revision_Sheet.BusinessObject;
using System;
using System.Collections.Generic;

namespace RevisionSheet.DataAccess.Entities
{
    public class UserEntities
    {
        public string FirstName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public UserEntities()
        {
        }

        public UserEntities(string firstName, string lastName, string login, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Login = login;
            this.Password = password;
        }

        public UserEntities(int id, string firstName, string lastName, string login, string password)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Login = login;
            this.Password = password;
        }

        public UserEntities(User user)
        {
            this.Id = user.Id;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Login = user.Login;
            this.Password = user.Password;
        }

    }
}