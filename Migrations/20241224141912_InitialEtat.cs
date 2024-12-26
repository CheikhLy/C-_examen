using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ges_commande.Migrations
{
    /// <inheritdoc />
    public partial class InitialEtat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "etat",
                table: "commande",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "etat",
                table: "commande");
        }
    }
}
