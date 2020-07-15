using Revision_Sheet.BusinessObject;
using Revision_Sheet.DataAccess;
using Revision_Sheet.IBusiness;
using RevisionSheet.DataAccess.Entities;
using RevisionSheet.DataAccess.IDataAccess;
using System;
using System.Collections.Generic;

namespace Revision_Sheet.Business
{
    
    public class ChapterBusiness : IChapterBusiness
    {
        private IChapterDataAccess chapterDataAccess = new ChapterDataAccess();
        public Chapter Create(Chapter obj)
        {
            return chapterDataAccess.Create(obj.ChapterEntityConversion(1)).ChapterConversion();
        }

        public bool Delete(int id)
        {
            bool boolReturn = true;
            chapterDataAccess.Delete(id);
            return boolReturn;
        }

        public List<Chapter> FindAllChapterByCourse(int courseId)
        {
            List<Chapter> chapters = new List<Chapter>();
            List<ChapterEntity> chapterEntities = new List<ChapterEntity>();
            chapterEntities = chapterDataAccess.FindAllChapterByCourse(courseId);
            foreach (ChapterEntity chapterEntity in chapterEntities)
            {
                chapters.Add(chapterEntity.ChapterConversion());
            }
            return chapters;
        }

        public Chapter FindById(int id)
        {
            return chapterDataAccess.FindById(id).ChapterConversion();
        }

        public Chapter Update(int id, Chapter obj)
        {
            return chapterDataAccess.Update(id,obj.ChapterEntityConversion(1)).ChapterConversion();
        }
    }
}