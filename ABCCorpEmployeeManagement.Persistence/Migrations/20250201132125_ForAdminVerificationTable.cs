using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABCCorp.EmployeeManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ForAdminVerificationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminVerificationRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeRecordId = table.Column<int>(type: "int", nullable: false),
                    AdminVerificationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminVerificationComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminVerificationRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminVerificationRecords_EmployeeRecords_EmployeeRecordId",
                        column: x => x.EmployeeRecordId,
                        principalTable: "EmployeeRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdminVerificationRecords",
                columns: new[] { "Id", "AdminVerificationComment", "AdminVerificationStatus", "DateCreated", "DateModified", "EmployeeRecordId" },
                values: new object[] { 1, "Approved by Admin", "Approved", new DateTime(2025, 2, 1, 18, 51, 24, 519, DateTimeKind.Local).AddTicks(9288), new DateTime(2025, 2, 1, 18, 51, 24, 519, DateTimeKind.Local).AddTicks(9268), 1 });

            migrationBuilder.UpdateData(
                table: "EmployeeRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 1, 18, 51, 24, 520, DateTimeKind.Local).AddTicks(382), new DateTime(2025, 2, 1, 18, 51, 24, 520, DateTimeKind.Local).AddTicks(379) });

            migrationBuilder.CreateIndex(
                name: "IX_AdminVerificationRecords_EmployeeRecordId",
                table: "AdminVerificationRecords",
                column: "EmployeeRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminVerificationRecords");

            migrationBuilder.UpdateData(
                table: "EmployeeRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 30, 12, 40, 28, 28, DateTimeKind.Local).AddTicks(3829), new DateTime(2025, 1, 30, 12, 40, 28, 28, DateTimeKind.Local).AddTicks(3812) });
        }
    }
}
