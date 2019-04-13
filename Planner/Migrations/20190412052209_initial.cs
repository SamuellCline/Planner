using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Theme = table.Column<string>(nullable: true),
                    OpeningSong = table.Column<int>(nullable: false),
                    OpeningPrayer = table.Column<string>(nullable: true),
                    Conducting = table.Column<string>(nullable: true),
                    SacramentHymn = table.Column<int>(nullable: false),
                    Speaker1 = table.Column<string>(maxLength: 50, nullable: true),
                    TalkTopic1 = table.Column<string>(maxLength: 50, nullable: true),
                    Speaker2 = table.Column<string>(maxLength: 50, nullable: true),
                    TalkTopic2 = table.Column<string>(maxLength: 50, nullable: true),
                    ClosingSong = table.Column<int>(nullable: false),
                    ClosingPrayer = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plan");
        }
    }
}
