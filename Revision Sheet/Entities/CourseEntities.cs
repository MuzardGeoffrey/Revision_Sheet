using System;
using System.Collections.Generic;

namespace RevisionSheet.DataAccess.Entities
{
    public class CourseEntities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public CourseEntities()
        {
        }

        public CourseEntities(string name, int userId)
        {
            this.Name = name;
            this.UserId = userId;
        }

        public CourseEntities(int id, string name, int userId)
        {
            this.Id = id;
            this.Name = name;
            this.UserId = userId;
        }
    }
}