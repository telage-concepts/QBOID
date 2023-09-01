using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBOID.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployerRecord",
                columns: table => new
                {
                    EmployerRecordID = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmployerSector = table.Column<int>(type: "INTEGER", nullable: false),
                    EmploymentType = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployerName = table.Column<string>(type: "TEXT", nullable: false),
                    EmployerAddress = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    EmployerPhone = table.Column<string>(type: "TEXT", nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NetMonthlyIncome = table.Column<decimal>(type: "TEXT", nullable: false),
                    EmploymentDuration = table.Column<int>(type: "INTEGER", nullable: false),
                    NextPayDay = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ToleranceDays = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalMonthlyExpense = table.Column<decimal>(type: "TEXT", nullable: false),
                    SalaryFrequency = table.Column<int>(type: "INTEGER", nullable: false),
                    IncomeReceiptMode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerRecord", x => x.EmployerRecordID);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    BankVerificationNumber = table.Column<string>(type: "TEXT", nullable: false),
                    BankCode = table.Column<string>(type: "TEXT", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Activity = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployerRecordID = table.Column<Guid>(type: "TEXT", nullable: false),
                    MimLoanId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanID);
                    table.ForeignKey(
                        name: "FK_Loans_EmployerRecord_EmployerRecordID",
                        column: x => x.EmployerRecordID,
                        principalTable: "EmployerRecord",
                        principalColumn: "EmployerRecordID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_EmployerRecordID",
                table: "Loans",
                column: "EmployerRecordID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "EmployerRecord");
        }
    }
}
