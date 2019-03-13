using School.BL.Mappers;
using School.BL.Models;
using School.DAL.Entities;

namespace School.BL.Tests.SetupFixtures
{
    public class StudentFacadeTestsSetupFixture : FacadeTestsSetupFixture<StudentEntity, StudentModel>
    {
        public StudentFacadeTestsSetupFixture() : base(new StudentMapper())
        {
        }
    }
}