using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boyutTaskAppAPI.Persistence.Migrations
{
    public partial class Customer_Table_Revised : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                schema: "boyut_be",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                schema: "boyut_be",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "boyut_be",
                table: "Order");

            migrationBuilder.AddColumn<Guid>(
                name: "BasketId",
                schema: "boyut_be",
                table: "Order",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasketId",
                schema: "boyut_be",
                table: "Order");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                schema: "boyut_be",
                table: "Order",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                schema: "boyut_be",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                schema: "boyut_be",
                table: "Order",
                column: "CustomerId",
                principalSchema: "boyut_be",
                principalTable: "Customer",
                principalColumn: "Id");
        }
    }
}
