using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boyutTaskAppAPI.Persistence.Migrations
{
    public partial class Customers_Table_Created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sg_be");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "boyut_be",
                newName: "User",
                newSchema: "sg_be");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "boyut_be",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ExternalId = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                schema: "boyut_be",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ExternalId = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "boyut_be",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Adress = table.Column<string>(type: "text", nullable: false),
                    ExternalId = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "boyut_be",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "boyut_be",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ProductGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalId = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductGroup_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalSchema: "boyut_be",
                        principalTable: "ProductGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerBasket",
                schema: "boyut_be",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalId = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerBasket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerBasket_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "boyut_be",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerBasket_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "sg_be",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_CustomerBasket_ProductId",
                schema: "boyut_be",
                table: "CustomerBasket",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBasket_UserId",
                schema: "boyut_be",
                table: "CustomerBasket",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                schema: "boyut_be",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsId",
                schema: "boyut_be",
                table: "OrderProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductGroupId",
                schema: "boyut_be",
                table: "Product",
                column: "ProductGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerBasket",
                schema: "boyut_be");

            migrationBuilder.DropTable(
                name: "OrderProduct",
                schema: "boyut_be");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "boyut_be");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "boyut_be");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "boyut_be");

            migrationBuilder.DropTable(
                name: "ProductGroup",
                schema: "boyut_be");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "sg_be",
                newName: "User",
                newSchema: "boyut_be");
        }
    }
}
