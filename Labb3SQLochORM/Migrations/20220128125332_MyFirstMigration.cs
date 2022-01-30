using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb3SQLochORM.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Befattning",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    befattning = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Befattning", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skola",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    SkolNamn = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skola", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    fNamn = table.Column<string>(maxLength: 50, nullable: false),
                    eNamn = table.Column<string>(maxLength: 50, nullable: false),
                    befattningsID = table.Column<int>(nullable: false),
                    skolId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personal_Befattning",
                        column: x => x.befattningsID,
                        principalTable: "Befattning",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Klass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Namn = table.Column<string>(maxLength: 50, nullable: false),
                    antalElever = table.Column<int>(nullable: true),
                    skolaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klass_Skola",
                        column: x => x.skolaId,
                        principalTable: "Skola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kurs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    kursNamn = table.Column<string>(maxLength: 50, nullable: false),
                    lärarID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kurs_Personal",
                        column: x => x.lärarID,
                        principalTable: "Personal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Elev",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    fNamn = table.Column<string>(maxLength: 50, nullable: false),
                    eNamn = table.Column<string>(maxLength: 50, nullable: false),
                    personNummer = table.Column<int>(nullable: false),
                    klassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elev", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elev_Klass",
                        column: x => x.klassId,
                        principalTable: "Klass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "elevKurser",
                columns: table => new
                {
                    fElevId = table.Column<int>(nullable: true),
                    fKursId = table.Column<int>(nullable: true),
                    fKursBetyg = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    betygDatum = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_elevKurser_Elev",
                        column: x => x.fElevId,
                        principalTable: "Elev",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_elevKurser_Kurs",
                        column: x => x.fKursId,
                        principalTable: "Kurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elev_klassId",
                table: "Elev",
                column: "klassId");

            migrationBuilder.CreateIndex(
                name: "IX_elevKurser_fElevId",
                table: "elevKurser",
                column: "fElevId");

            migrationBuilder.CreateIndex(
                name: "IX_elevKurser_fKursId",
                table: "elevKurser",
                column: "fKursId");

            migrationBuilder.CreateIndex(
                name: "IX_Klass_skolaId",
                table: "Klass",
                column: "skolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurs_lärarID",
                table: "Kurs",
                column: "lärarID");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_befattningsID",
                table: "Personal",
                column: "befattningsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "elevKurser");

            migrationBuilder.DropTable(
                name: "Elev");

            migrationBuilder.DropTable(
                name: "Kurs");

            migrationBuilder.DropTable(
                name: "Klass");

            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "Skola");

            migrationBuilder.DropTable(
                name: "Befattning");
        }
    }
}
