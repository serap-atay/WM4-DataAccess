using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KuzeyApp.Migrations
{
    public partial class CalisanTablosu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Tedarikciler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Tedarikciler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tedarikciler",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Tedarikciler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CalisanId",
                table: "Siparisler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Calisan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    AmirId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calisan_Calisan_AmirId",
                        column: x => x.AmirId,
                        principalTable: "Calisan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_CalisanId",
                table: "Siparisler",
                column: "CalisanId");

            migrationBuilder.CreateIndex(
                name: "IX_Calisan_AmirId",
                table: "Calisan",
                column: "AmirId");

            migrationBuilder.AddForeignKey(
                name: "FK_Siparisler_Calisan_CalisanId",
                table: "Siparisler",
                column: "CalisanId",
                principalTable: "Calisan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siparisler_Calisan_CalisanId",
                table: "Siparisler");

            migrationBuilder.DropTable(
                name: "Calisan");

            migrationBuilder.DropIndex(
                name: "IX_Siparisler_CalisanId",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tedarikciler");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Tedarikciler");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tedarikciler");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Tedarikciler");

            migrationBuilder.DropColumn(
                name: "CalisanId",
                table: "Siparisler");
        }
    }
}
