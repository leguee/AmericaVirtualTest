using Microsoft.EntityFrameworkCore.Migrations;

namespace AmericaVirtualAPI.Migrations
{
    public partial class update_colum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Productos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Productos");
        }
    }
}
