using System.Linq;
using School.BL.Mappers.Base;
using School.BL.Models;
using School.DAL.Entities;

namespace School.BL.Mappers
{
    public class StudentMapper : MapperBase<StudentEntity, StudentModel>
    {
        public override StudentEntity Map(StudentModel model)
        {
            if (model == null) return null;
            var studentEntity = new StudentEntity
            {
                Id = model.Id,
                Name = model.Name,
                Grade = new GradeMapper().Map(model.Grade),
                Address = new AddressMapper().Map(model.Address),
                StudentCourses = model.Courses?.Select(c => new StudentCourseEntity
                {
                    StudentId = model.Id,
                    CourseId = c.Id,
                    Course = new CourseMapper().Map(c)
                }).ToList()
            };

            if (studentEntity.StudentCourses != null)
                foreach (var studentCourseEntity in studentEntity.StudentCourses)
                    studentCourseEntity.Student = studentEntity;

            return studentEntity;
        }

        public override StudentModel Map(StudentEntity entity)
        {
            if (entity == null) return null;
            return new StudentModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Grade = new GradeMapper().Map(entity.Grade),
                Address = new AddressMapper().Map(entity.Address),
                Courses = new CourseMapper().Map(entity.StudentCourses?.Select(sc => sc.Course).ToList())
            };
        }
    }
}