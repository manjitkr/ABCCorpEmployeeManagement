using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABCCorp.EmployeeManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalExperience = table.Column<int>(type: "int", nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousCompanyEmployerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRecords", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmployeeRecords",
                columns: new[] { "Id", "BloodGroup", "DateCreated", "DateModified", "Email", "EmergencyContact", "FirstName", "LastName", "ManagerEmail", "ManagerName", "Mobile", "PreviousCompanyEmployerName", "ProfilePicture", "Role", "Status", "TotalExperience" },
                values: new object[] { 1, null, new DateTime(2025, 1, 30, 12, 40, 28, 28, DateTimeKind.Local).AddTicks(3829), new DateTime(2025, 1, 30, 12, 40, 28, 28, DateTimeKind.Local).AddTicks(3812), "johndoe@email.com", null, "John", "Doe", null, null, "123-456-789", null, null, "Developer", "Active", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeRecords");
        }
    }
}
