using School.BL.Mappers;
using School.BL.Models;
using School.BL.Models.DetailModels;
using School.BL.Models.ListModels;
using School.BL.Tests.SetupFixtures.Base;
using School.DAL.Entities;

namespace School.BL.Tests.SetupFixtures
{
    public class StudentFacadeTestsSetupFixture : FacadeTestsSetupFixture<StudentEntity, StudentListModel, StudentDetailModel>
    {
        public StudentFacadeTestsSetupFixture() : base(new StudentMapper())
        {
        }
    }
}