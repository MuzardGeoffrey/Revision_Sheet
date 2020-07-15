using Revision_Sheet.BusinessObject;
using System.Collections.Generic;

namespace Revision_Sheet.IBusiness
{
    internal interface ISheetBusiness : IBaseBusiness<Sheet>
    {
        public List<Sheet> FindAllSheetByChapter(int chapterId);
    }
}