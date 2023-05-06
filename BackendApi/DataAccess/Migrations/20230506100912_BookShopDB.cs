using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class BookShopDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attribute",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Attribut__737584F7B7F801E8", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__737584F7CB1D4698", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Login = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    Last_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    First_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Middle_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Phone_number = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: false),
                    Zip_code = table.Column<int>(type: "int", nullable: true),
                    Region = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Street = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    House = table.Column<int>(type: "int", nullable: true),
                    Flat = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__5E55825A8DC76854", x => x.Login);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    ISBN = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Author = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Publishing_house = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Year_of_publishing = table.Column<int>(type: "int", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    Amount_in_stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Book__447D36EBAF1130BD", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK__Book__Category__2E1BDC42",
                        column: x => x.Category,
                        principalTable: "Category",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "Category_attribute",
                columns: table => new
                {
                    Category = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Attribute = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__743356A85D5E6B2E", x => new { x.Category, x.Attribute });
                    table.ForeignKey(
                        name: "FK__Category___Attri__32E0915F",
                        column: x => x.Attribute,
                        principalTable: "Attribute",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK__Category___Categ__31EC6D26",
                        column: x => x.Category,
                        principalTable: "Category",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Customer_login = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Cart__Customer_l__3B75D760",
                        column: x => x.Customer_login,
                        principalTable: "Customer",
                        principalColumn: "Login");
                });

            migrationBuilder.CreateTable(
                name: "Book_property",
                columns: table => new
                {
                    ISBN = table.Column<int>(type: "int", nullable: false),
                    Attribute = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Value = table.Column<object>(type: "sql_variant", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Book_pro__7BF95C7095C754B0", x => new { x.ISBN, x.Attribute });
                    table.ForeignKey(
                        name: "FK__Book_prop__Attri__37A5467C",
                        column: x => x.Attribute,
                        principalTable: "Attribute",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK__Book_prope__ISBN__36B12243",
                        column: x => x.ISBN,
                        principalTable: "Book",
                        principalColumn: "ISBN");
                });

            migrationBuilder.CreateTable(
                name: "Cart_item",
                columns: table => new
                {
                    Cart_id = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart_ite__72C1FCAF6CCEC9DA", x => new { x.Cart_id, x.ISBN });
                    table.ForeignKey(
                        name: "FK__Cart_item__Cart___3F466844",
                        column: x => x.Cart_id,
                        principalTable: "Cart",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Cart_item__ISBN__403A8C7D",
                        column: x => x.ISBN,
                        principalTable: "Book",
                        principalColumn: "ISBN");
                });

            migrationBuilder.CreateTable(
                name: "Order_details",
                columns: table => new
                {
                    Cart_id = table.Column<int>(type: "int", nullable: false),
                    Registration_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    Pickup = table.Column<bool>(type: "bit", nullable: false),
                    Delivery_zip_code = table.Column<int>(type: "int", nullable: true),
                    Delivery_region = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Delivery_city = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Delivery_street = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Delivery_house = table.Column<int>(type: "int", nullable: true),
                    Delivery_flat = table.Column<int>(type: "int", nullable: true),
                    Delivery_date = table.Column<DateTime>(type: "date", nullable: true),
                    Delivery_price = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    Completion_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    Payment_type = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Payed = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order_de__D6862FC1EF0FF920", x => x.Cart_id);
                    table.ForeignKey(
                        name: "FK__Order_det__Cart___440B1D61",
                        column: x => x.Cart_id,
                        principalTable: "Cart",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_Category",
                table: "Book",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Book_property_Attribute",
                table: "Book_property",
                column: "Attribute");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Customer_login",
                table: "Cart",
                column: "Customer_login");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_item_ISBN",
                table: "Cart_item",
                column: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Category_attribute_Attribute",
                table: "Category_attribute",
                column: "Attribute");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book_property");

            migrationBuilder.DropTable(
                name: "Cart_item");

            migrationBuilder.DropTable(
                name: "Category_attribute");

            migrationBuilder.DropTable(
                name: "Order_details");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Attribute");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
