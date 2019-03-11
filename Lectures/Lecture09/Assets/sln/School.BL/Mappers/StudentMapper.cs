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
            return new StudentEntity
            {
                Id = model.Id,
                Name = model.Name,
                //Grade = new GradeMapper().Map(model.Grade),
                //Address = new AddressMapper().Map(model.Address)
                //StudentCourses = new CourseMapper().Map(entity.Students) TODO
            };
        }

        public override StudentModel Map(StudentEntity entity)
        {
            return new StudentModel
            {
                Id = entity.Id,
                Name = entity.Name,
                //Grade = new GradeMapper().Map(entity.Grade),
                //Address = new AddressMapper().Map(entity.Address),
                //Courses = new CourseMapper().Map(entity.StudentCourses.Select(sc => sc.Course).ToList())
            };
        }
    }
}