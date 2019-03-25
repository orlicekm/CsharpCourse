using System.Linq;
using School.BL.Mappers.Base;
using School.BL.Models.DetailModels;
using School.BL.Models.ListModels;
using School.DAL.Entities;

namespace School.BL.Mappers
{
    public class StudentMapper : MapperBase<StudentEntity, StudentListModel, StudentDetailModel>
    {
        public override StudentEntity MapEntity(StudentListModel model)
        {
            if (model == null) return null;
            return new StudentEntity
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public override StudentEntity MapEntity(StudentDetailModel model)
        {
            if (model == null) return null;
            var studentEntity = new StudentEntity
            {
                Id = model.Id,
                Name = model.Name,
                Grade = new GradeMapper().MapEntity(model.Grade),
                Address = new AddressMapper().MapEntity(model.Address),
                StudentCourses = model.Courses?.Select(c => new StudentCourseEntity
                {
                    StudentId = model.Id,
                    CourseId = c.Id,
                    Course = new CourseMapper().MapEntity(c)
                }).ToList()
            };

            if (studentEntity.StudentCourses != null)
                foreach (var studentCourseEntity in studentEntity.StudentCourses)
                    studentCourseEntity.Student = studentEntity;

            return studentEntity;
        }

        public override StudentListModel MapListModel(StudentEntity entity)
        {
            if (entity == null) return null;
            return new StudentListModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public override StudentDetailModel MapDetailModel(StudentEntity entity)
        {
            if (entity == null) return null;
            return new StudentDetailModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Grade = new GradeMapper().MapListModel(entity.Grade),
                Address = new AddressMapper().MapListModel(entity.Address),
                Courses = new CourseMapper().MapListModels(entity.StudentCourses?.Select(sc => sc.Course).ToList())
            };
        }
    }
}