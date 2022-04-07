using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobWebApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FirmAddresses",
                columns: table => new
                {
                    FirmAddressId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    AddressFirst = table.Column<string>(type: "text", nullable: false),
                    AddressSecond = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmAddresses", x => x.FirmAddressId);
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    UserAddressId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    AddressFirst = table.Column<string>(type: "text", nullable: false),
                    AddressSecond = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.UserAddressId);
                });

            migrationBuilder.CreateTable(
                name: "Firms",
                columns: table => new
                {
                    FirmId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FirmAddressId = table.Column<int>(type: "integer", nullable: false),
                    FirmAddressId1 = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Desciption = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firms", x => x.FirmId);
                    table.ForeignKey(
                        name: "FK_Firms_FirmAddresses_FirmAddressId1",
                        column: x => x.FirmAddressId1,
                        principalTable: "FirmAddresses",
                        principalColumn: "FirmAddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    BirthdayDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ContactNumber = table.Column<string>(type: "text", nullable: false),
                    UserAddressId = table.Column<int>(type: "integer", nullable: false),
                    UserAddressId1 = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Experience = table.Column<float>(type: "real", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Desciption = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_UserAddresses_UserAddressId1",
                        column: x => x.UserAddressId1,
                        principalTable: "UserAddresses",
                        principalColumn: "UserAddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    VacancyId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    FirmId = table.Column<int>(type: "integer", nullable: false),
                    FirmId1 = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Requirements = table.Column<string>(type: "text", nullable: false),
                    Responsibilities = table.Column<string>(type: "text", nullable: false),
                    Salary = table.Column<decimal>(type: "numeric", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.VacancyId);
                    table.ForeignKey(
                        name: "FK_Vacancies_Firms_FirmId1",
                        column: x => x.FirmId1,
                        principalTable: "Firms",
                        principalColumn: "FirmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidtates",
                columns: table => new
                {
                    CandidateId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    VacancyId = table.Column<int>(type: "integer", nullable: false),
                    VacancyId1 = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UserId1 = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidtates", x => x.CandidateId);
                    table.ForeignKey(
                        name: "FK_Candidtates_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidtates_Vacancies_VacancyId1",
                        column: x => x.VacancyId1,
                        principalTable: "Vacancies",
                        principalColumn: "VacancyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidtates_UserId1",
                table: "Candidtates",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Candidtates_VacancyId1",
                table: "Candidtates",
                column: "VacancyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Firms_FirmAddressId1",
                table: "Firms",
                column: "FirmAddressId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserAddressId1",
                table: "Users",
                column: "UserAddressId1");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_FirmId1",
                table: "Vacancies",
                column: "FirmId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidtates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "Firms");

            migrationBuilder.DropTable(
                name: "FirmAddresses");
        }
    }
}
