using System.Collections.Generic;

namespace RevisionSheet.DataAccess.Entities
{
    public class ChapterEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }

        public ChapterEntity()
        {
        }

        public ChapterEntity(string name, int courseId)
        {
            this.Name = name;
            this.CourseId = courseId;
        }

        public ChapterEntity(int id, string name, int courseId)
        {
            this.Id = id;
            this.Name = name;
            this.CourseId = courseId;
        }
    }
}