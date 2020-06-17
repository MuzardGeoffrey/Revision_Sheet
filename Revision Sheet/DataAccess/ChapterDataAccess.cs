using RevisionSheet.DataAccess.DataAccess;
using RevisionSheet.DataAccess.Entities;
using RevisionSheet.DataAccess.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revision_Sheet.DataAccess
{
    public class ChapterDataAccess : DbConnexion, IChapterDataAccess
    {
        public ChapterEntities Create(ChapterEntities obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<SheetEntities> FindAllChapterByCourse(int ChapterId)
        {
            throw new NotImplementedException();
        }

        public ChapterEntities FindById(int id)
        {
            throw new NotImplementedException();
        }

        public ChapterEntities Update(int id, ChapterEntities obj)
        {
            throw new NotImplementedException();
        }
    }
}
