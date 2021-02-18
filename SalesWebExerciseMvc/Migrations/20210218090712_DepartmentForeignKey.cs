using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebExerciseMvc.Migrations
{
    public partial class DepartmentForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_seller_department_DepartmentId",
                table: "seller");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "seller",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_seller_department_DepartmentId",
                table: "seller",
                column: "DepartmentId",
                principalTable: "department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_seller_department_DepartmentId",
                table: "seller");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "seller",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_seller_department_DepartmentId",
                table: "seller",
                column: "DepartmentId",
                principalTable: "department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
