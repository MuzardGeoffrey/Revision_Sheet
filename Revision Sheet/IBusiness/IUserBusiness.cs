using Revision_Sheet.BusinessObject;
using System.Collections.Generic;

namespace Revision_Sheet.IBusiness
{
    internal interface IUserBusiness : IBaseBusiness<User>
    {
        public List<User> FindAll();
        public User Login(User user);
    }
}