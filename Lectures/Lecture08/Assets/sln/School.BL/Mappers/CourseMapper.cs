using System.Linq;
using School.BL.Mappers.Base;
using School.BL.Models.DetailModels;
using School.BL.Models.ListModels;
using School.DAL.Entities;

namespace School.BL.Mappers
{
    public class CourseMapper : MapperBase<CourseEntity, CourseListModel, CourseDetailModel>
    {
        public override CourseEntity MapEntity(CourseListModel model)
        {
            if (model == null) return null;
            return new CourseEntity
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public override CourseEntity MapEntity(CourseDetailModel model)
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
                    Student = new StudentMapper().MapEntity(s),
                    CourseId = s.Id
                }).ToList()
            };

            if (courseEntity.StudentCourses != null)
                foreach (var studentCourseEntity in courseEntity.StudentCourses)
                    studentCourseEntity.Course = courseEntity;

            return courseEntity;
        }

        public override CourseListModel MapListModel(CourseEntity entity)
        {
            if (entity == null) return null;
            return new CourseListModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public override CourseDetailModel MapDetailModel(CourseEntity entity)
        {
            if (entity == null) return null;
            return new CourseDetailModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Students = new StudentMapper().MapDetailModels(entity.StudentCourses?.Select(sc => sc.Student).ToList())
            };
        }
    }
}