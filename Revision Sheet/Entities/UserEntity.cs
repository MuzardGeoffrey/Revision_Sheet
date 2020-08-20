using Revision_Sheet.BusinessObject;

namespace RevisionSheet.DataAccess.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {
        }

        public UserEntity(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }

        public UserEntity(int id, string login, string password)
        {
            this.Id = id;
            this.Login = login;
            this.Password = password;
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public User UserConvertion()
        {
            return new User
            {
                Id = this.Id,
                Login = this.Login,
                Password = this.Password
            };
        }
    }
}