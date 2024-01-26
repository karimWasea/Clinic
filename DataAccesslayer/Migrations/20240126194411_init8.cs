using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.DataAccesslayer.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Patients_PatientId",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Visits",
                newName: "patientid");

            migrationBuilder.RenameIndex(
                name: "IX_Visits_PatientId",
                table: "Visits",
                newName: "IX_Visits_patientid");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Patients_patientid",
                table: "Visits",
                column: "patientid",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Patients_patientid",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "patientid",
                table: "Visits",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Visits_patientid",
                table: "Visits",
                newName: "IX_Visits_PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Patients_PatientId",
                table: "Visits",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
