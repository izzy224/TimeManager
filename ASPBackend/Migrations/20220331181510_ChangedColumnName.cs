using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPBackend.Migrations
{
    public partial class ChangedColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdToDoStatus",
                table: "Todos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdToDoStatus",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
