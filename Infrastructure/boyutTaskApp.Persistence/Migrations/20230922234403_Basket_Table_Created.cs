using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boyutTaskAppAPI.Persistence.Migrations
{
    public partial class Basket_Table_Created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerBasket",
                schema: "boyut_be");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "sg_be",
                newName: "User",
                newSchema: "boyut_be");

            migrationBuilder.CreateTable(
                name: "Basket",
                schema: "boyut_be",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalId = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Basket_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "boyut_be",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketItem",
                schema: "boyut_be",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BasketId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItem_Basket_BasketId",
                        column: x => x.BasketId,
                        principalSchema: "boyut_be",
                        principalTable: "Basket",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BasketItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "boyut_be",
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Basket_UserId",
                schema: "boyut_be",
                table: "Basket",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_BasketId",
                schema: "boyut_be",
                table: "BasketItem",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_ProductId",
                schema: "boyut_be",
                table: "BasketItem",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItem",
                schema: "boyut_be");

            migrationBuilder.DropTable(
                name: "Basket",
                schema: "boyut_be");

            migrationBuilder.EnsureSchema(
                name: "sg_be");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "boyut_be",
                newName: "User",
                newSchema: "sg_be");

            migrationBuilder.CreateTable(
                name: "CustomerBasket",
                schema: "boyut_be",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
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
        }
    }
}
