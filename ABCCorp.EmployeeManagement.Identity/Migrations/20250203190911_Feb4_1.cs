using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABCCorp.EmployeeManagement.Identity.Migrations
{
    /// <inheritdoc />
    public partial class Feb4_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f93b9889-721d-482e-a442-0837d050a350",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "ActiveAppUser", "ACTIVEAPPUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc0f9913-ecd1-4b99-b7b1-c6989531af42", null, "InactiveAppUser", "INACTIVEAPPUSER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e09f3fe-8e73-4266-8d7f-fbf7738ff919",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4594c69-c550-4d28-9963-4d016218eb01", "AQAAAAIAAYagAAAAEJuqKIDz4ONFRT49dGdSvhkX6trbfAgLwQeYlN3asiEAzljO0benpPjjzP7IgC8Jtw==", "6bfca686-f004-4f0d-b143-d1f8973b0790" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g93b9889-721d-482e-a442-0837d050a350",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b35a182-18b7-4a43-bcb0-8e646f2332c1", "USER1", "AQAAAAIAAYagAAAAEFEtER6/Gr7KtcOrIUwu/j027Ue8IHl+cWa1DU/7fcr/4x6vavwSMRdhuFUtXThilQ==", "6ce9168c-a7f1-416b-a129-9696c35457ca" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c282ea7b-7ffc-45af-af9f-5720c594da86", 0, "92370eba-0d6f-4fb4-ba9f-bb2de0ed4b63", "user2@localhost.com", false, "User2", "noLast", false, null, null, "USER2", "AQAAAAIAAYagAAAAEKYCnFERohG8JUhMzq8FdnyWtUcYfxM14/JbJdBxBIC5kenBa8NQDlhAJetMFnfhRw==", null, false, "c215ca1c-bc67-439c-bdef-d33b8c58be44", false, "user2" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fc0f9913-ecd1-4b99-b7b1-c6989531af42", "c282ea7b-7ffc-45af-af9f-5720c594da86" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fc0f9913-ecd1-4b99-b7b1-c6989531af42", "c282ea7b-7ffc-45af-af9f-5720c594da86" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc0f9913-ecd1-4b99-b7b1-c6989531af42");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c282ea7b-7ffc-45af-af9f-5720c594da86");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f93b9889-721d-482e-a442-0837d050a350",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e09f3fe-8e73-4266-8d7f-fbf7738ff919",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e49cb245-ed3a-416a-9526-ef4163bdc70d", "AQAAAAIAAYagAAAAENDCHNs1heQRwhEb8Ts5TZpOCHYop31PF77WCktIkAdyl1ujUqoOipz8nfhURZjSEA==", "35ff7d8f-4b0d-454a-bf12-374bbd55f0b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g93b9889-721d-482e-a442-0837d050a350",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f5ac65f-0797-48fe-ae2a-ebcd6cb494cd", "USER", "AQAAAAIAAYagAAAAEJ3ZCLPErgOyLm/BJV85Qt18WlqMQJS7/nNsEY6ygXH/1U52u6sHPr9rpTOfSOhgbg==", "7a5aed86-8764-4b92-818b-472bee5cbbe3" });
        }
    }
}
