using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookBook.DAL.Migrations
{
    public partial class Addednavigationproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "IngredientAmoutEntity",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Unit = table.Column<int>(nullable: false),
                    RecipeId = table.Column<Guid>(nullable: true),
                    IngredientId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientAmoutEntity", x => x.Id);
                    table.ForeignKey(
                        "FK_IngredientAmoutEntity_Ingredients_IngredientId",
                        x => x.IngredientId,
                        "Ingredients",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_IngredientAmoutEntity_Recipes_RecipeId",
                        x => x.RecipeId,
                        "Recipes",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_IngredientAmoutEntity_IngredientId",
                "IngredientAmoutEntity",
                "IngredientId");

            migrationBuilder.CreateIndex(
                "IX_IngredientAmoutEntity_RecipeId",
                "IngredientAmoutEntity",
                "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "IngredientAmoutEntity");
        }
    }
}