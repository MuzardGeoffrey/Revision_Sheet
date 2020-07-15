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
                courses.Add(courseEntity.CourseConversion());
            }
            return courses;

        }

        public Course FindById(int id)
        {
            return courseDataAcces.FindById(id).CourseConversion();
        }

        public Course Update(int id, Course obj)
        {
            return courseDataAcces.Update(id, obj.CourseEntityConversion()).CourseConversion();
        }
    }
}