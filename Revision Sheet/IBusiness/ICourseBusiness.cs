using Revision_Sheet.BusinessObject;
using System.Collections.Generic;

namespace Revision_Sheet.IBusiness
{
    internal interface ICourseBusiness : IBaseBusiness<Course>
    {
        public List<Course> FindAllCourseByUser(int userId);
    }
}