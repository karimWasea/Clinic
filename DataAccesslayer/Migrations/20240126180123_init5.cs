using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.DataAccesslayer.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Clinic_ClinicId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ClinicId",
                table: "Employees",
                newName: "clinicid");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ClinicId",
                table: "Employees",
                newName: "IX_Employees_clinicid");

            migrationBuilder.AlterColumn<Guid>(
                name: "clinicid",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Clinic_clinicid",
                table: "Employees",
                column: "clinicid",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Clinic_clinicid",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "clinicid",
                table: "Employees",
                newName: "ClinicId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_clinicid",
                table: "Employees",
                newName: "IX_Employees_ClinicId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClinicId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Clinic_ClinicId",
                table: "Employees",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
