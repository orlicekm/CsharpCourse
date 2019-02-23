using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace EntityFramework.DAL.Tests
{
    public class Test
    {
        [Fact]
        public void TestMethod()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appconfig.json");

            var configuration = builder.Build();
            var cs = configuration.GetConnectionString("SchoolContext");


            using (var db = new SchoolDbContext(cs))
            {
                var number = db.Students.Count();
                Assert.Equal(0, number);
            }
        }
    }
}