using Revision_Sheet.DataAccess;
using RevisionSheet.DataAccess.Entities;
using RevisionSheet.DataAccess.IDataAccess;
using System.Collections.Generic;

namespace Revision_Sheet.BusinessObject
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Sheet> SheetList { get; set; }

        public Chapter()
        {
        }

        public Chapter(string name, List<Sheet> sheetList)
        {
            Name = name;
            SheetList = sheetList;
        }

        public Chapter(int id, string name, List<Sheet> sheetList)
        {
            Id = id;
            Name = name;
            SheetList = sheetList;
        }

        public ChapterEntity ChapterEntityConversion(int courseId)
        {
            IChapterDataAccess chapterDataAccess = new ChapterDataAccess();
            return new ChapterEntity
            {
                Id = this.Id,
                Name = this.Name,
                CourseId = courseId
            };
        }
    }
}