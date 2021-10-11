using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShopSolution.Data.Migrations
{
    public partial class udorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 27, 22, 50, 30, 513, DateTimeKind.Local).AddTicks(2256),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 5, 22, 21, 21, 573, DateTimeKind.Local).AddTicks(595));

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "477e903b-f536-453d-baca-d29bb4e5be60");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "49c704dd-1813-4064-9fd0-3da759e6bbe9", "AQAAAAEAACcQAAAAEBVL8+srJVe+0J+ZbZ0kkqx7FKRRjcWtGrE5k/f/1qSVILkJz7N5nu2rzE09Az6fYQ==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2021, 9, 27, 22, 50, 30, 608, DateTimeKind.Local).AddTicks(2555));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "ViewCount" },
                values: new object[] { new DateTime(2021, 9, 27, 22, 50, 30, 608, DateTimeKind.Local).AddTicks(4558), 5 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "ViewCount" },
                values: new object[] { new DateTime(2021, 9, 27, 22, 50, 30, 608, DateTimeKind.Local).AddTicks(4602), 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 27, 22, 50, 30, 546, DateTimeKind.Local).AddTicks(8782));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 5, 22, 21, 21, 573, DateTimeKind.Local).AddTicks(595),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 9, 27, 22, 50, 30, 513, DateTimeKind.Local).AddTicks(2256));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "7e144630-2d34-4ea8-af25-d688266c3d72");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c0895fa3-b008-4430-a569-5f0e28a509bd", "AQAAAAEAACcQAAAAEECGUECx2FWBMpSIGIx3L/1mzHuGKxlKMYGR+HmRdXZG0FZ1JlvcgjY8GKs8GuSFjw==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2021, 9, 5, 22, 21, 21, 691, DateTimeKind.Local).AddTicks(165));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "ViewCount" },
                values: new object[] { new DateTime(2021, 9, 5, 22, 21, 21, 691, DateTimeKind.Local).AddTicks(2307), 5 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "ViewCount" },
                values: new object[] { new DateTime(2021, 9, 5, 22, 21, 21, 691, DateTimeKind.Local).AddTicks(2342), 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 5, 22, 21, 21, 619, DateTimeKind.Local).AddTicks(6281));
        }
    }
}
