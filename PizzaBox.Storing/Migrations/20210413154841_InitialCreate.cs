using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DBCrusts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CRUST = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBCrusts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DBCustomers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBCustomers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DBSizes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SIZE = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBSizes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DBStores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STORE = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBStores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DBOrders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DBStoreID = table.Column<int>(type: "int", nullable: true),
                    DBCustomerID = table.Column<int>(type: "int", nullable: true),
                    PriceTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBOrders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DBOrders_DBCustomers_DBCustomerID",
                        column: x => x.DBCustomerID,
                        principalTable: "DBCustomers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DBOrders_DBStores_DBStoreID",
                        column: x => x.DBStoreID,
                        principalTable: "DBStores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DBPizzas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PIZZA = table.Column<int>(type: "int", nullable: false),
                    DBCrustID = table.Column<int>(type: "int", nullable: true),
                    DBSizeID = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DBOrderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBPizzas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DBPizzas_DBCrusts_DBCrustID",
                        column: x => x.DBCrustID,
                        principalTable: "DBCrusts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DBPizzas_DBOrders_DBOrderID",
                        column: x => x.DBOrderID,
                        principalTable: "DBOrders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DBPizzas_DBSizes_DBSizeID",
                        column: x => x.DBSizeID,
                        principalTable: "DBSizes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DBToppings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TOPPING = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DBPizzaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBToppings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DBToppings_DBPizzas_DBPizzaID",
                        column: x => x.DBPizzaID,
                        principalTable: "DBPizzas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DBOrders_DBCustomerID",
                table: "DBOrders",
                column: "DBCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_DBOrders_DBStoreID",
                table: "DBOrders",
                column: "DBStoreID");

            migrationBuilder.CreateIndex(
                name: "IX_DBPizzas_DBCrustID",
                table: "DBPizzas",
                column: "DBCrustID");

            migrationBuilder.CreateIndex(
                name: "IX_DBPizzas_DBOrderID",
                table: "DBPizzas",
                column: "DBOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_DBPizzas_DBSizeID",
                table: "DBPizzas",
                column: "DBSizeID");

            migrationBuilder.CreateIndex(
                name: "IX_DBToppings_DBPizzaID",
                table: "DBToppings",
                column: "DBPizzaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBToppings");

            migrationBuilder.DropTable(
                name: "DBPizzas");

            migrationBuilder.DropTable(
                name: "DBCrusts");

            migrationBuilder.DropTable(
                name: "DBOrders");

            migrationBuilder.DropTable(
                name: "DBSizes");

            migrationBuilder.DropTable(
                name: "DBCustomers");

            migrationBuilder.DropTable(
                name: "DBStores");
        }
    }
}
