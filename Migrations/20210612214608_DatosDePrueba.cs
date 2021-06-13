using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pruebasEntityFramework.Migrations
{
    public partial class DatosDePrueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CATEGORIAS",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Remera" },
                    { 2, "Pantalon" },
                    { 3, "Campera" },
                    { 4, "Calzado" }
                });

            migrationBuilder.InsertData(
                table: "PRODUCTOS",
                columns: new[] { "Id", "Categoria_id", "FechaDeCreacion", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 6, 12, 18, 46, 7, 989, DateTimeKind.Local).AddTicks(9254), "Remera manga larga rallada", 1200.0, 13 },
                    { 2, 1, new DateTime(2021, 6, 12, 18, 46, 7, 991, DateTimeKind.Local).AddTicks(3335), "Remera manga corta estampada", 1450.0, 11 },
                    { 3, 2, new DateTime(2021, 6, 12, 18, 46, 7, 991, DateTimeKind.Local).AddTicks(3396), "Pantalon chino color mostaza", 4100.0, 11 },
                    { 4, 2, new DateTime(2021, 6, 12, 18, 46, 7, 991, DateTimeKind.Local).AddTicks(3400), "Pantalon Jean negro", 3800.0, 15 },
                    { 5, 2, new DateTime(2021, 6, 12, 18, 46, 7, 991, DateTimeKind.Local).AddTicks(3402), "Bermuda color azul", 1100.0, 13 },
                    { 6, 3, new DateTime(2021, 6, 12, 18, 46, 7, 991, DateTimeKind.Local).AddTicks(3405), "Campera parka", 12500.0, 4 },
                    { 7, 4, new DateTime(2021, 6, 12, 18, 46, 7, 991, DateTimeKind.Local).AddTicks(3407), "Zapatilla blanca", 5800.0, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CATEGORIAS",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CATEGORIAS",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CATEGORIAS",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CATEGORIAS",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PRODUCTOS",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PRODUCTOS",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PRODUCTOS",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PRODUCTOS",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PRODUCTOS",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PRODUCTOS",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PRODUCTOS",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
