using System;
using Microsoft.EntityFrameworkCore;
using School.BL.Mappers;
using School.BL.Models;
using School.DAL;
using School.DAL.Entities;
using Xunit;

namespace School.BL.Tests
{
    public class IngredientFacadeTest
    {
        [Fact]
        public void InsertIngredient()
        {
            var model = new StudentModel
            {
                Name = "Fero"
            };
            var unit = new UnitOfWork(new SchoolDbContext());
            var facade = new CrudFacade<StudentEntity, StudentModel>(unit, new RepositoryBase<StudentEntity>(unit), new StudentMapper());

            facade.Save(model);
        }
    }
}