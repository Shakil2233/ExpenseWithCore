using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExcelAssignment.Migrations
{
    public partial class newmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseCategories",
                columns: table => new
                {
                    ExCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExCategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategories", x => x.ExCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExCategoryId_FK = table.Column<int>(type: "int", nullable: false),
                    ExDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExId);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseCategories_ExCategoryId_FK",
                        column: x => x.ExCategoryId_FK,
                        principalTable: "ExpenseCategories",
                        principalColumn: "ExCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExCategoryId_FK",
                table: "Expenses",
                column: "ExCategoryId_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "ExpenseCategories");
        }
    }
}
