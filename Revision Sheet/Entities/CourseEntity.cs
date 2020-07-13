using Revision_Sheet.BusinessObject;
using Revision_Sheet.DataAccess;
using RevisionSheet.DataAccess.IDataAccess;
using System.Collections.Generic;

namespace RevisionSheet.DataAccess.Entities
{
    public class CourseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public CourseEntity()
        {
        }

        public CourseEntity(string name, int userId)
        {
            this.Name = name;
            this.UserId = userId;
        }

        public CourseEntity(int id, string name, int userId)
        {
            this.Id = id;
            this.Name = name;
            this.UserId = userId;
        }

        public Course CourseConversion()
        {
            IChapterDataAccess chapterDataAccess = new ChapterDataAccess();
            List<Chapter> chapters = new List<Chapter>();
            List<ChapterEntity> chapterEntities = new List<ChapterEntity>();

            chapterEntities = chapterDataAccess.FindAllChapterByCourse(this.Id);

            foreach (var chapterEntity in chapterEntities)
            {
                chapters.Add(chapterEntity.ChapterConversion());
            }
            return new Course
            {
                Id = this.Id,
                Name = this.Name,
                ChapterList = chapters,
                UserId = this.UserId
            };
        }
    }
}