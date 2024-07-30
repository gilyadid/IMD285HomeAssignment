using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IMD285WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class mssqlcontainer_migration_initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HebrewName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HebrewName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "HebrewName", "Name" },
                values: new object[,]
                {
                    { new Guid("358cc0eb-8cc9-460c-a790-b7911ddafae5"), "ירקות ופירות", "Fruit & Vegetable" },
                    { new Guid("4a82a87f-2903-42c1-95f1-ed8428b91a50"), "בשר", "Meat" },
                    { new Guid("515fd745-63b3-4e46-8bb4-4303cdb2a4ec"), "טואלטיקה", "Toiletries" },
                    { new Guid("baca1d06-6c48-42e9-90c8-f4ce0c092934"), "חלב וגבינות", "Milk & Cheese" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "HebrewName", "Name" },
                values: new object[,]
                {
                    { new Guid("51455015-f2a5-4087-8e81-1ba33c9ee4b6"), new Guid("baca1d06-6c48-42e9-90c8-f4ce0c092934"), "קוטג", "Cottage" },
                    { new Guid("532c8209-270d-41b4-a8af-80baf532823d"), new Guid("4a82a87f-2903-42c1-95f1-ed8428b91a50"), "נקניקיות", "Sausage" },
                    { new Guid("99a51df2-2f31-4637-92cc-4f6b9b51a761"), new Guid("4a82a87f-2903-42c1-95f1-ed8428b91a50"), "סלמון", "Salmon" },
                    { new Guid("bf0e7ef7-3ea6-4e68-800d-37d5883f4ed0"), new Guid("4a82a87f-2903-42c1-95f1-ed8428b91a50"), "שוקיים", "Calves" },
                    { new Guid("c00f7014-935d-42bb-b0a8-61ecc7fbed2f"), new Guid("baca1d06-6c48-42e9-90c8-f4ce0c092934"), "חלב 3%", "Milk 3 Percent" },
                    { new Guid("c6c21008-7b7f-41af-969e-efea00794b0d"), new Guid("baca1d06-6c48-42e9-90c8-f4ce0c092934"), "שמנת חמוצה", "Sour Cream" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
