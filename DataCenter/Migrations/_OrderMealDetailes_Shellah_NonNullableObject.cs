using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataCenter.Migrations
{
    /// <inheritdoc />
    public partial class OrderMealDetailes_Shellah_NonNullableObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderMeals_OrderMealDetails_OrderMealDetailsId",
                table: "OrderMeals");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderMealDetailsId",
                table: "OrderMeals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMeals_OrderMealDetails_OrderMealDetailsId",
                table: "OrderMeals",
                column: "OrderMealDetailsId",
                principalTable: "OrderMealDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderMeals_OrderMealDetails_OrderMealDetailsId",
                table: "OrderMeals");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderMealDetailsId",
                table: "OrderMeals",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMeals_OrderMealDetails_OrderMealDetailsId",
                table: "OrderMeals",
                column: "OrderMealDetailsId",
                principalTable: "OrderMealDetails",
                principalColumn: "Id");
        }
    }
}
