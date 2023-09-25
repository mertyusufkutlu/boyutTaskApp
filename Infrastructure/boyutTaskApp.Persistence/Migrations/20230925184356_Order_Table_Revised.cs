using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boyutTaskAppAPI.Persistence.Migrations
{
    public partial class Order_Table_Revised : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                schema: "boyut_be",
                table: "Order");

            migrationBuilder.DropTable(
                name: "OrderProduct",
                schema: "boyut_be");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                schema: "boyut_be",
                table: "Order",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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
                name: "FK_Order_Customer_CustomerId",
                schema: "boyut_be",
                table: "Order",
                column: "CustomerId",
                principalSchema: "boyut_be",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product_ProductId",
                schema: "boyut_be",
                table: "Order",
                column: "ProductId",
                principalSchema: "boyut_be",
                principalTable: "Product",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                schema: "boyut_be",
                table: "Order");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                schema: "boyut_be",
                table: "Order",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                schema: "boyut_be",
                columns: table => new
                {
                    OrdersId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrdersId",
                        column: x => x.OrdersId,
                        principalSchema: "boyut_be",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalSchema: "boyut_be",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsId",
                schema: "boyut_be",
                table: "OrderProduct",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                schema: "boyut_be",
                table: "Order",
                column: "CustomerId",
                principalSchema: "boyut_be",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
