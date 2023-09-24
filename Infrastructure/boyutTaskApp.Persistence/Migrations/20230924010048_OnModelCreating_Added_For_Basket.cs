using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boyutTaskAppAPI.Persistence.Migrations
{
    public partial class OnModelCreating_Added_For_Basket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                schema: "boyut_be",
                table: "Basket",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Basket_Id",
                schema: "boyut_be",
                table: "Order",
                column: "Id",
                principalSchema: "boyut_be",
                principalTable: "Basket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Basket_Id",
                schema: "boyut_be",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "boyut_be",
                table: "Basket");
        }
    }
}
