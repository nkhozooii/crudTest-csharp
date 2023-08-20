using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mc2.CrudTest.Presentation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class emailAndBankExpression : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Customers_BankAccountNumber_RegularExpression",
                table: "Customers",
                sql: "BankAccountNumber LIKE '^[0-9]{9,18}$'");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Customers_Email_EmailAddress",
                table: "Customers",
                sql: "[Email] LIKE '^[^@]+@[^@]+$'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Customers_BankAccountNumber_RegularExpression",
                table: "Customers");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Customers_Email_EmailAddress",
                table: "Customers");
        }
    }
}
