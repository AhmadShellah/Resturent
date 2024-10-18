using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataCenter.Migrations
{
    /// <inheritdoc />
    public partial class AlterOrderMealDetail2Mohammad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderMeals_OrderMealDetails_OrderMealDetailsId",
                table: "OrderMeals");

            migrationBuilder.DropIndex(
                name: "IX_OrderMeals_OrderMealDetailsId",
                table: "OrderMeals");

            migrationBuilder.DropColumn(
                name: "OrderMealDetailsId",
                table: "OrderMeals");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderMealId",
                table: "OrderMealDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OrderMealDetails_OrderMealId",
                table: "OrderMealDetails",
                column: "OrderMealId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMealDetails_OrderMeals_OrderMealId",
                table: "OrderMealDetails",
                column: "OrderMealId",
                principalTable: "OrderMeals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderMealDetails_OrderMeals_OrderMealId",
                table: "OrderMealDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderMealDetails_OrderMealId",
                table: "OrderMealDetails");

            migrationBuilder.DropColumn(
                name: "OrderMealId",
                table: "OrderMealDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderMealDetailsId",
                table: "OrderMeals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OrderMeals_OrderMealDetailsId",
                table: "OrderMeals",
                column: "OrderMealDetailsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMeals_OrderMealDetails_OrderMealDetailsId",
                table: "OrderMeals",
                column: "OrderMealDetailsId",
                principalTable: "OrderMealDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
