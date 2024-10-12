using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataCenter.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderMealDetails_Shellah : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderMealDetailsId",
                table: "OrderMeals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderMealDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderMealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMealDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderMealDetails_OrderMeals_OrderMealId",
                        column: x => x.OrderMealId,
                        principalTable: "OrderMeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderMeals_OrderMealDetailsId",
                table: "OrderMeals",
                column: "OrderMealDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMealDetails_OrderMealId",
                table: "OrderMealDetails",
                column: "OrderMealId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMeals_OrderMealDetails_OrderMealDetailsId",
                table: "OrderMeals",
                column: "OrderMealDetailsId",
                principalTable: "OrderMealDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderMeals_OrderMealDetails_OrderMealDetailsId",
                table: "OrderMeals");

            migrationBuilder.DropTable(
                name: "OrderMealDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderMeals_OrderMealDetailsId",
                table: "OrderMeals");

            migrationBuilder.DropColumn(
                name: "OrderMealDetailsId",
                table: "OrderMeals");
        }
    }
}
