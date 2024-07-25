using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Repository.Data.Migrations
{
    public partial class UpdateDataInTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Patients_PatientID",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Patients_PatientID",
                table: "MedicalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_Doctors_DoctorID",
                table: "Nurses");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Doctors_Doctors_DoctorID",
                table: "Patients_Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Doctors_Patients_PatientID",
                table: "Patients_Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Nurses_Nurses_NurseID",
                table: "Patients_Nurses");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Nurses_Patients_PatientID",
                table: "Patients_Nurses");

            migrationBuilder.DropColumn(
                name: "Bloodgroup",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Hospitals");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Staff",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NurseID",
                table: "Patients_Nurses",
                newName: "NurseId");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "Patients_Nurses",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_Nurses_NurseID",
                table: "Patients_Nurses",
                newName: "IX_Patients_Nurses_NurseId");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "Patients_Doctors",
                newName: "DoctorId");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "Patients_Doctors",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_Doctors_DoctorID",
                table: "Patients_Doctors",
                newName: "IX_Patients_Doctors_DoctorId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Patients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "Nurses",
                newName: "DoctorId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Nurses",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Nurses_DoctorID",
                table: "Nurses",
                newName: "IX_Nurses_DoctorId");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "MedicalHistories",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "MedicalHistories",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalHistories_PatientID",
                table: "MedicalHistories",
                newName: "IX_MedicalHistories_PatientId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Hospitals",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Doctors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "Bills",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Bills",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_PatientID",
                table: "Bills",
                newName: "IX_Bills_PatientId");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "Appointments",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "Appointments",
                newName: "DoctorId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Appointments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments",
                newName: "IX_Appointments_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DoctorID",
                table: "Appointments",
                newName: "IX_Appointments_DoctorId");

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "History",
                table: "MedicalHistories",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "Hospitals",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Hospitals",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Major",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Patients_PatientId",
                table: "Bills",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Patients_PatientId",
                table: "MedicalHistories",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_Doctors_DoctorId",
                table: "Nurses",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Doctors_Doctors_DoctorId",
                table: "Patients_Doctors",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Doctors_Patients_PatientId",
                table: "Patients_Doctors",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Nurses_Nurses_NurseId",
                table: "Patients_Nurses",
                column: "NurseId",
                principalTable: "Nurses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Nurses_Patients_PatientId",
                table: "Patients_Nurses",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Patients_PatientId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Patients_PatientId",
                table: "MedicalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_Doctors_DoctorId",
                table: "Nurses");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Doctors_Doctors_DoctorId",
                table: "Patients_Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Doctors_Patients_PatientId",
                table: "Patients_Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Nurses_Nurses_NurseId",
                table: "Patients_Nurses");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Nurses_Patients_PatientId",
                table: "Patients_Nurses");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Staff",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "NurseId",
                table: "Patients_Nurses",
                newName: "NurseID");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Patients_Nurses",
                newName: "PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_Nurses_NurseId",
                table: "Patients_Nurses",
                newName: "IX_Patients_Nurses_NurseID");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Patients_Doctors",
                newName: "DoctorID");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Patients_Doctors",
                newName: "PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_Doctors_DoctorId",
                table: "Patients_Doctors",
                newName: "IX_Patients_Doctors_DoctorID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Patients",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Nurses",
                newName: "DoctorID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Nurses",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Nurses_DoctorId",
                table: "Nurses",
                newName: "IX_Nurses_DoctorID");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "MedicalHistories",
                newName: "PatientID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MedicalHistories",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalHistories_PatientId",
                table: "MedicalHistories",
                newName: "IX_MedicalHistories_PatientID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Hospitals",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Doctors",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Bills",
                newName: "PatientID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bills",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_PatientId",
                table: "Bills",
                newName: "IX_Bills_PatientID");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Appointments",
                newName: "PatientID");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Appointments",
                newName: "DoctorID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Appointments",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                newName: "IX_Appointments_PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                newName: "IX_Appointments_DoctorID");

            migrationBuilder.AddColumn<string>(
                name: "Bloodgroup",
                table: "Patients",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Patients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "History",
                table: "MedicalHistories",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "Hospitals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Hospitals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Hospitals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "Doctors",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Major",
                table: "Doctors",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorID",
                table: "Appointments",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientID",
                table: "Appointments",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Patients_PatientID",
                table: "Bills",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Patients_PatientID",
                table: "MedicalHistories",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_Doctors_DoctorID",
                table: "Nurses",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Doctors_Doctors_DoctorID",
                table: "Patients_Doctors",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Doctors_Patients_PatientID",
                table: "Patients_Doctors",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Nurses_Nurses_NurseID",
                table: "Patients_Nurses",
                column: "NurseID",
                principalTable: "Nurses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Nurses_Patients_PatientID",
                table: "Patients_Nurses",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
