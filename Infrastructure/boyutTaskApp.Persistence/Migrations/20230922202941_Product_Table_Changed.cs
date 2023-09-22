using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boyutTaskAppAPI.Persistence.Migrations
{
    public partial class Product_Table_Changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductGroup_ProductGroupId",
                schema: "boyut_be",
                table: "Product");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductGroupId",
                schema: "boyut_be",
                table: "Product",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductGroup_ProductGroupId",
                schema: "boyut_be",
                table: "Product",
                column: "ProductGroupId",
                principalSchema: "boyut_be",
                principalTable: "ProductGroup",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductGroup_ProductGroupId",
                schema: "boyut_be",
                table: "Product");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductGroupId",
                schema: "boyut_be",
                table: "Product",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductGroup_ProductGroupId",
                schema: "boyut_be",
                table: "Product",
                column: "ProductGroupId",
                principalSchema: "boyut_be",
                principalTable: "ProductGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
