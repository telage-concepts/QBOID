using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBOID.Migrations
{
    /// <inheritdoc />
    public partial class NIN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MIMScheduleId",
                table: "PaymentSchedules");

            migrationBuilder.AddColumn<string>(
                name: "NationalIdentificationNumber",
                table: "Loans",
                type: "TEXT",
                maxLength: 11,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NationalIdentificationNumber",
                table: "Loans");

            migrationBuilder.AddColumn<Guid>(
                name: "MIMScheduleId",
                table: "PaymentSchedules",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
