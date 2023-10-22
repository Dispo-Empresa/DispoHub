using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DispoHub.Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateCoreContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CorporateName = table.Column<string>(type: "VARCHAR(220)", maxLength: 220, nullable: false),
                    ResponsibleName = table.Column<string>(type: "VARCHAR(220)", maxLength: 220, nullable: false),
                    ResponsiblePhone = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Cnpj = table.Column<string>(type: "VARCHAR(18)", maxLength: 18, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(220)", maxLength: 220, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
