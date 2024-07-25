using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Repository.Data.Migrations
{
    public partial class AddToTableBillMedDocID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "MedicalHistories",
                type: "int",
                nullable: true);  // Allow null for foreign key

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Bills",
                type: "int",
                nullable: true);  // Allow null for foreign key

            migrationBuilder.CreateIndex(
                name: "IX_Bills_DoctorId",
                table: "Bills",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_DoctorId",
                table: "MedicalHistories",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Doctors_DoctorId",
                table: "Bills",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);  // Set null on delete

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Doctors_DoctorId",
                table: "MedicalHistories",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);  // Set null on delete
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Doctors_DoctorId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Doctors_DoctorId",
                table: "MedicalHistories");

            migrationBuilder.DropIndex(
                name: "IX_Bills_DoctorId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistories_DoctorId",
                table: "MedicalHistories");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "MedicalHistories");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Bills");
        }
    }
}
