using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boyutTaskAppAPI.Persistence.Migrations
{
    public partial class Product_Table_Revised : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Product_ProductId",
                schema: "boyut_be",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ProductId",
                schema: "boyut_be",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "boyut_be",
                table: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                schema: "boyut_be",
                table: "Order",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                schema: "boyut_be",
                table: "Order",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product_ProductId",
                schema: "boyut_be",
                table: "Order",
                column: "ProductId",
                principalSchema: "boyut_be",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
