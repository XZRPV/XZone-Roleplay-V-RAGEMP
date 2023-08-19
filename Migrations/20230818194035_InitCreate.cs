using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XZRPV.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PosX = table.Column<float>(nullable: false),
                    PosY = table.Column<float>(nullable: false),
                    PosZ = table.Column<float>(nullable: false),
                    Money = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValue: 0.00m),
                    BankBalance = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValue: 0.00m),
                    AdminRankId = table.Column<int>(nullable: false),
                    FactionId = table.Column<int>(nullable: false),
                    FactionRankId = table.Column<int>(nullable: false),
                    JobId = table.Column<int>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    IsDead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    HouseId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EntranceX = table.Column<float>(nullable: false),
                    EntranceY = table.Column<float>(nullable: false),
                    EntranceZ = table.Column<float>(nullable: false),
                    ExitX = table.Column<float>(nullable: false),
                    ExitY = table.Column<float>(nullable: false),
                    ExitZ = table.Column<float>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    InteriorId = table.Column<int>(nullable: false),
                    VirtualWorldId = table.Column<uint>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.HouseId);
                    table.ForeignKey(
                        name: "FK_Houses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCharacters",
                columns: table => new
                {
                    UserCharacterId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Torso = table.Column<int>(nullable: false),
                    Undershirt = table.Column<int>(nullable: false),
                    Top = table.Column<int>(nullable: false),
                    Legs = table.Column<int>(nullable: false),
                    Shoes = table.Column<int>(nullable: false),
                    Hair = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCharacters", x => x.UserCharacterId);
                    table.ForeignKey(
                        name: "FK_UserCharacters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Houses_UserId",
                table: "Houses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCharacters_UserId",
                table: "UserCharacters",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "UserCharacters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
