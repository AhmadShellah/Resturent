using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add_UnitPrice_in_Details : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderMeals_Meals_MealID",
                table: "OrderMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMeals_Orders_OrderID",
                table: "OrderMeals");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "OrderMeals",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "MealID",
                table: "OrderMeals",
                newName: "MealId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMeals_OrderID",
                table: "OrderMeals",
                newName: "IX_OrderMeals_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMeals_MealID",
                table: "OrderMeals",
                newName: "IX_OrderMeals_MealId");

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "OrderMealDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMeals_Meals_MealId",
                table: "OrderMeals",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMeals_Orders_OrderId",
                table: "OrderMeals",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderMeals_Meals_MealId",
                table: "OrderMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMeals_Orders_OrderId",
                table: "OrderMeals");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "OrderMealDetails");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderMeals",
                newName: "OrderID");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "OrderMeals",
                newName: "MealID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMeals_OrderId",
                table: "OrderMeals",
                newName: "IX_OrderMeals_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMeals_MealId",
                table: "OrderMeals",
                newName: "IX_OrderMeals_MealID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMeals_Meals_MealID",
                table: "OrderMeals",
                column: "MealID",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMeals_Orders_OrderID",
                table: "OrderMeals",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
