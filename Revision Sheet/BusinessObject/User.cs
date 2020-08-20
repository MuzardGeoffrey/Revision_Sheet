using RevisionSheet.DataAccess.Entities;

namespace Revision_Sheet.BusinessObject
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public User(User user)
        {
            this.Id = user.Id;
            this.Login = user.Login;
            this.Password = user.Password;
        }

        public User(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }

        public User(int id, string login, string password)
        {
            this.Id = id;
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
                Login = this.Login,
                Password = this.Password
            };
        }
    }
}