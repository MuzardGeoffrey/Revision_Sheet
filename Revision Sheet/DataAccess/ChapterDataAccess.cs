using RevisionSheet.DataAccess.DataAccess;
using RevisionSheet.DataAccess.Entities;
using RevisionSheet.DataAccess.IDataAccess;
using System;
using System.Collections.Generic;

namespace Revision_Sheet.DataAccess
{
    public class ChapterDataAccess : DbConnexion, IChapterDataAccess
    {
        public ChapterEntity Create(ChapterEntity obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<SheetEntity> FindAllChapterByCourse(int ChapterId)
        {
            throw new NotImplementedException();
        }

        public ChapterEntity FindById(int id)
        {
            throw new NotImplementedException();
        }

        public ChapterEntity Update(int id, ChapterEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}