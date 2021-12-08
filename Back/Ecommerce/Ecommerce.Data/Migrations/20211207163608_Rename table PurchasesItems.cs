using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Data.Migrations
{
    public partial class RenametablePurchasesItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompraProdutos_Products_ProductId",
                table: "CompraProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_CompraProdutos_Purchases_PurchaseId",
                table: "CompraProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompraProdutos",
                table: "CompraProdutos");

            migrationBuilder.RenameTable(
                name: "CompraProdutos",
                newName: "PurchasesItems");

            migrationBuilder.RenameColumn(
                name: "TextSize",
                table: "SummariesPurchases",
                newName: "SizeText");

            migrationBuilder.RenameColumn(
                name: "TextColor",
                table: "SummariesPurchases",
                newName: "ColorText");

            migrationBuilder.RenameColumn(
                name: "TextCategory",
                table: "SummariesPurchases",
                newName: "CategoryText");

            migrationBuilder.RenameIndex(
                name: "IX_CompraProdutos_PurchaseId",
                table: "PurchasesItems",
                newName: "IX_PurchasesItems_PurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_CompraProdutos_ProductId",
                table: "PurchasesItems",
                newName: "IX_PurchasesItems_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasesItems",
                table: "PurchasesItems",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "State",
                value: "RJ");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasesItems_Products_ProductId",
                table: "PurchasesItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasesItems_Purchases_PurchaseId",
                table: "PurchasesItems",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasesItems_Products_ProductId",
                table: "PurchasesItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasesItems_Purchases_PurchaseId",
                table: "PurchasesItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasesItems",
                table: "PurchasesItems");

            migrationBuilder.RenameTable(
                name: "PurchasesItems",
                newName: "CompraProdutos");

            migrationBuilder.RenameColumn(
                name: "SizeText",
                table: "SummariesPurchases",
                newName: "TextSize");

            migrationBuilder.RenameColumn(
                name: "ColorText",
                table: "SummariesPurchases",
                newName: "TextColor");

            migrationBuilder.RenameColumn(
                name: "CategoryText",
                table: "SummariesPurchases",
                newName: "TextCategory");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasesItems_PurchaseId",
                table: "CompraProdutos",
                newName: "IX_CompraProdutos_PurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasesItems_ProductId",
                table: "CompraProdutos",
                newName: "IX_CompraProdutos_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompraProdutos",
                table: "CompraProdutos",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "State",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_CompraProdutos_Products_ProductId",
                table: "CompraProdutos",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompraProdutos_Purchases_PurchaseId",
                table: "CompraProdutos",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
