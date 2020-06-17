using RevisionSheet.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevisionSheet.DataAccess.IDataAccess
{
    interface ICourseDataAccess : IBaseDataAccess<CourseEntities>
    {
        public List<CourseEntities> FindAllCourseByUser(int courseId); 
    }
}
