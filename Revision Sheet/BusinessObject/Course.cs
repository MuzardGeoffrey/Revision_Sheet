using Revision_Sheet.DataAccess;
using RevisionSheet.DataAccess.Entities;
using RevisionSheet.DataAccess.IDataAccess;
using System.Collections.Generic;

namespace Revision_Sheet.BusinessObject
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Chapter> ChapterList { get; set; }

        public Course()
        {
        }

        public Course(string name, List<Chapter> chapterList)
        {
            Name = name;
            ChapterList = chapterList;
        }

        public Course(int id, string name, List<Chapter> chapterList)
        {
            Id = id;
            Name = name;
            ChapterList = chapterList;
        }

        public CourseEntity CourseEntityConversion()
        {
            ICourseDataAccess courseDataAccess = new CourseDataAccess();
            return new CourseEntity
            {
                Id = this.Id,
                Name = this.Name,
                UserId = courseDataAccess.FindById(this.Id).UserId
            };
        }
    }
}