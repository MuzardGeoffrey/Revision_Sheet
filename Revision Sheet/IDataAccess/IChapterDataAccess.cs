using RevisionSheet.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevisionSheet.DataAccess.IDataAccess
{
    interface IChapterDataAccess : IBaseDataAccess<ChapterEntity>
    {
        public List<SheetEntity> FindAllChapterByCourse(int ChapterId);
    }
}
