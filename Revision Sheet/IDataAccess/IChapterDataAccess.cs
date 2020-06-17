using RevisionSheet.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevisionSheet.DataAccess.IDataAccess
{
    interface IChapterDataAccess : IBaseDataAccess<ChapterEntities>
    {
        public List<SheetEntities> FindAllChapterByCourse(int ChapterId);
    }
}
