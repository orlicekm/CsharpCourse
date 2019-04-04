using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.Migrations
{
    public partial class Initialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Courses",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Courses", x => x.Id); });

            migrationBuilder.CreateTable(
                "Grades",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Section = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Grades", x => x.Id); });

            migrationBuilder.CreateTable(
                "Students",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    GradeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        "FK_Students_Grades_GradeId",
                        x => x.GradeId,
                        "Grades",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Addresses",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    StudentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        "FK_Addresses_Students_StudentId",
                        x => x.StudentId,
                        "Students",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "StudentCourseEntity",
                table => new
                {
                    StudentId = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseEntity", x => new {x.StudentId, x.CourseId});
                    table.ForeignKey(
                        "FK_StudentCourseEntity_Courses_CourseId",
                        x => x.CourseId,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_StudentCourseEntity_Students_StudentId",
                        x => x.StudentId,
                        "Students",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Addresses_StudentId",
                "Addresses",
                "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_StudentCourseEntity_CourseId",
                "StudentCourseEntity",
                "CourseId");

            migrationBuilder.CreateIndex(
                "IX_Students_GradeId",
                "Students",
                "GradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Addresses");

            migrationBuilder.DropTable(
                "StudentCourseEntity");

            migrationBuilder.DropTable(
                "Courses");

            migrationBuilder.DropTable(
                "Students");

            migrationBuilder.DropTable(
                "Grades");
        }
    }
}