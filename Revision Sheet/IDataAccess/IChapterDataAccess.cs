using RevisionSheet.DataAccess.Entities;
using System.Collections.Generic;

namespace RevisionSheet.DataAccess.IDataAccess
{
    internal interface IChapterDataAccess : IBaseDataAccess<ChapterEntity>
    {
        public List<ChapterEntity> FindAllChapterByCourse(int courseId);
    }
}