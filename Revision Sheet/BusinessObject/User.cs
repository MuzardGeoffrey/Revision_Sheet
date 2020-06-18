using RevisionSheet.DataAccess.Entities;

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

        public User()
        {
        }

        public UserEntity UserEntityConvertion()
        {
            return new UserEntity
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Login = this.Login,
                Password = this.Password
            };
        }
    }
}