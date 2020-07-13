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
            throw new NotImplementedException();
        }

        public List<Course> FindAll()
        {
            throw new NotImplementedException();
        }

        public Course FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Course Update(int id, Course obj)
        {
            throw new NotImplementedException();
        }
    }
}