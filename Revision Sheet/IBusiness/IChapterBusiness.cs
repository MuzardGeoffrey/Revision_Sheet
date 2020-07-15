using Revision_Sheet.BusinessObject;
using System.Collections.Generic;

namespace Revision_Sheet.IBusiness
{
    internal interface IChapterBusiness : IBaseBusiness<Chapter>
    {
        public List<Chapter> FindAllChapterByCourse(int courseId);
    }
}