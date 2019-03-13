using School.BL.Mappers;
using School.BL.Models;
using School.DAL.Entities;

namespace School.BL.Tests.SetupFixtures
{
    public class CourseFacadeTestsSetupFixture : FacadeTestsSetupFixture<CourseEntity, CourseModel>
    {
        public CourseFacadeTestsSetupFixture() : base(new CourseMapper())
        {
        }
    }
}