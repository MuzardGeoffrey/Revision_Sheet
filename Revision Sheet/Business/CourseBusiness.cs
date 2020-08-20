using Revision_Sheet.BusinessObject;
using Revision_Sheet.DataAccess;
using Revision_Sheet.IBusiness;
using RevisionSheet.DataAccess.Entities;
using RevisionSheet.DataAccess.IDataAccess;
using System;
using System.Collections.Generic;

namespace Revision_Sheet.Business
{
    public class CourseBusiness : ICourseBusiness
    {
        ICourseDataAccess courseDataAcces = new CourseDataAccess();
        IChapterBusiness chapterBusiness = new ChapterBusiness();

        public Course Create(Course course)
        {
            CourseEntity courseReturn = new CourseEntity();
            courseReturn = courseDataAcces.Create(course.CourseEntityConversion());
            return courseReturn.CourseConversion();
        }

        public bool Delete(int id)
        {
            courseDataAcces.Delete(id);
            return true;
        }

        public List<Course> FindAllCourseByUser(int userId)
        {
            List<Course> courses = new List<Course>();
            List<CourseEntity> courseEntities = new List<CourseEntity>();
            courseEntities = courseDataAcces.FindAllCourseByUser(userId);
            foreach (var courseEntity in courseEntities)
            {
                Course course = new Course();
                course = completeCourse(courseEntity.CourseConversion());
                courses.Add(course);
                
            }
            return courses;
        }

        public Course FindById(int id)
        {
            Course course = new Course();
            course = courseDataAcces.FindById(id).CourseConversion();
            course = completeCourse(course);
            return course;
        }

        public Course Update(int id, Course obj)
        {
            return courseDataAcces.Update(id, obj.CourseEntityConversion()).CourseConversion();
        }

        private Course completeCourse(Course course)
        {
            course.ChapterList = chapterBusiness.FindAllChapterByCourse(course.Id);
            return course;
        }
    }
}