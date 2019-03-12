using System.Linq;
using School.BL.Mappers.Base;
using School.BL.Models;
using School.DAL.Entities;

namespace School.BL.Mappers
{
    public class CourseMapper : MapperBase<CourseEntity, CourseModel>
    {
        public override CourseEntity Map(CourseModel model)
        {
            if (model == null) return null;
            var courseEntity = new CourseEntity
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                StudentCourses = model.Students?.Select(s => new StudentCourseEntity
                {
                    StudentId = model.Id,
                    Student = new StudentMapper().Map(s),
                    CourseId = s.Id
                }).ToList()
            };

            foreach (var studentCourseEntity in courseEntity.StudentCourses)
                studentCourseEntity.Course = courseEntity;

            return courseEntity;
        }

        public override CourseModel Map(CourseEntity entity)
        {
            if (entity == null) return null;
            return new CourseModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Students = new StudentMapper().Map(entity.StudentCourses?.Select(sc => sc.Student).ToList())
            };
        }
    }
}