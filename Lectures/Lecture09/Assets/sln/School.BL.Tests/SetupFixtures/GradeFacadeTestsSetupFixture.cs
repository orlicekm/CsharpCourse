using School.BL.Mappers;
using School.BL.Models;
using School.DAL.Entities;

namespace School.BL.Tests.SetupFixtures
{
    public class GradeFacadeTestsSetupFixture : FacadeTestsSetupFixture<GradeEntity, GradeModel>
    {
        public GradeFacadeTestsSetupFixture() : base(new GradeMapper())
        {
        }
    }
}