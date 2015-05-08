using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System.Collections.Generic;
using System.Data;

namespace KuasCore.Dao.Impl
{

    public class CourseDao : GenericDao<Course>, ICourseDao
    {

        override protected IRowMapper<Course> GetRowMapper()
        {
            return new CourseRowMapper();
        }

        public void AddCourse(Course course)
        {
            string command = @"INSERT INTO Course (Id, Name, Description) VALUES (@Id, @Name, @Description);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = course.Id;
            parameters.Add("Name", DbType.String).Value = course.Name;
            parameters.Add("Age", DbType.Int32).Value = course.Description;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateCourse(Course course)
        {
            string command = @"UPDATE Course SET Name = @Name, Description = @Description WHERE Id = @Id;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = course.Id;
            parameters.Add("Name", DbType.String).Value = course.Name;
            parameters.Add("Age", DbType.Int32).Value = course.Description;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteEmployee(Course course)
        {
            string command = @"DELETE FROM Course WHERE Id = @Id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = course.Id;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Course> GetAllEmployees()
        {
            string command = @"SELECT * FROM Course ORDER BY Id ASC";
            IList<Course> course = ExecuteQueryWithRowMapper(command);
            return course;
        }

        public Course GetCourseById(string id)
        {
            string command = @"SELECT * FROM Course WHERE Id = @Id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = id;

            IList<Course> course = ExecuteQueryWithRowMapper(command, parameters);
            if (course.Count > 0)
            {
                return course[0];
            }

            return null;
        }

    }
}
