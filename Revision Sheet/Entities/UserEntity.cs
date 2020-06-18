using Revision_Sheet.BusinessObject;

namespace RevisionSheet.DataAccess.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {
        }

        public UserEntity(string firstName, string lastName, string login, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Login = login;
            this.Password = password;
        }

        public UserEntity(int id, string firstName, string lastName, string login, string password)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Login = login;
            this.Password = password;
        }

        public string FirstName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public User UserConvertion()
        {
            return new User
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