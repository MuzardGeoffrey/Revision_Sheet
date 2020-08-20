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
            return chapterDataAccess.Create(obj.ChapterEntityConversion()).ChapterConversion();
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
            ISheetBusiness sheetBusiness = new SheetBusiness();

            foreach (ChapterEntity chapterEntity in chapterEntities)
            {
                Chapter chapter = new Chapter();
                chapter = chapterEntity.ChapterConversion();
                chapter.SheetList = sheetBusiness.FindAllSheetByChapter(chapter.Id);
                chapters.Add(chapter);
            }
            return chapters;
        }

        public Chapter FindById(int id)
        {
            return chapterDataAccess.FindById(id).ChapterConversion();
        }

        public Chapter Update(int id, Chapter obj)
        {
            return chapterDataAccess.Update(id,obj.ChapterEntityConversion()).ChapterConversion();
        }
    }
}