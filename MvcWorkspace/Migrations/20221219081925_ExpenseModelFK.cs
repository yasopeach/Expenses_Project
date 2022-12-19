using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcWorkspace.Migrations
{
    public partial class ExpenseModelFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpenseCategoryId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseCategoryId",
                table: "Expenses",
                column: "ExpenseCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Categories_ExpenseCategoryId",
                table: "Expenses",
                column: "ExpenseCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Categories_ExpenseCategoryId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ExpenseCategoryId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpenseCategoryId",
                table: "Expenses");
        }
    }
}
