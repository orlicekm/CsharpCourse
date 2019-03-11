using System;
using School.BL.Mappers.Base;
using School.BL.Models;
using School.DAL.Entities;

namespace School.BL.Mappers
{
    public class CourseMapper : MapperBase<CourseEntity, CourseModel>
    {
        public override CourseEntity Map(CourseModel model)
        {
            throw new NotImplementedException();
        }

        public override CourseModel Map(CourseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}