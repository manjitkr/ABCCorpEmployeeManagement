using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABCCorp.EmployeeManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RefactoringChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "EmployeeRecords");

            migrationBuilder.RenameColumn(
                name: "TotalExperience",
                table: "EmployeeRecords",
                newName: "ExperienceInYears");

            migrationBuilder.AddColumn<string>(
                name: "AdminVerificationComment",
                table: "EmployeeRecords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminVerificationStatus",
                table: "EmployeeRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "EmployeeRecords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AdminVerificationRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 3, 4, 2, 41, 38, DateTimeKind.Local).AddTicks(2775), new DateTime(2025, 2, 3, 4, 2, 41, 38, DateTimeKind.Local).AddTicks(2755) });

            migrationBuilder.UpdateData(
                table: "EmployeeRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AdminVerificationComment", "AdminVerificationStatus", "DateCreated", "DateModified", "ProfilePictureUrl" },
                values: new object[] { null, "PendingVerification", new DateTime(2025, 2, 3, 4, 2, 41, 38, DateTimeKind.Local).AddTicks(4594), new DateTime(2025, 2, 3, 4, 2, 41, 38, DateTimeKind.Local).AddTicks(4590), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminVerificationComment",
                table: "EmployeeRecords");

            migrationBuilder.DropColumn(
                name: "AdminVerificationStatus",
                table: "EmployeeRecords");

            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "EmployeeRecords");

            migrationBuilder.RenameColumn(
                name: "ExperienceInYears",
                table: "EmployeeRecords",
                newName: "TotalExperience");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "EmployeeRecords",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AdminVerificationRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 1, 18, 51, 24, 519, DateTimeKind.Local).AddTicks(9288), new DateTime(2025, 2, 1, 18, 51, 24, 519, DateTimeKind.Local).AddTicks(9268) });

            migrationBuilder.UpdateData(
                table: "EmployeeRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified", "ProfilePicture" },
                values: new object[] { new DateTime(2025, 2, 1, 18, 51, 24, 520, DateTimeKind.Local).AddTicks(382), new DateTime(2025, 2, 1, 18, 51, 24, 520, DateTimeKind.Local).AddTicks(379), null });
        }
    }
}
