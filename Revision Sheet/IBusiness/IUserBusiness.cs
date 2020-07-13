using Revision_Sheet.BusinessObject;

namespace Revision_Sheet.IBusiness
{
    internal interface IUserBusiness : IBaseBusiness<User>
    {
        public User Login(User user);
    }
}