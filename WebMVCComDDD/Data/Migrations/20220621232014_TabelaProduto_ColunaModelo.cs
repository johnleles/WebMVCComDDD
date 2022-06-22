using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMVCComDDD.Data.Migrations
{
    public partial class TabelaProduto_ColunaModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Produtos");
        }
    }
}
