using Microsoft.EntityFrameworkCore.Migrations;

namespace KuzeyApp.Migrations
{
    public partial class AddDevamColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DevamEtmiyorMu",
                table: "Urunler",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
        //migrationlar silinirse add-migration yap ve up/down kısmını sil.sonra update-database yap. 
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DevamEtmiyorMu",
                table: "Urunler");
        }
    }
}
