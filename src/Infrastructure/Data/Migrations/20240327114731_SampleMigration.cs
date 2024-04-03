using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicantPortal.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SampleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentUploadModels_ApplicantModel_ApplicantModelId",
                table: "DocumentUploadModels");

            migrationBuilder.RenameColumn(
                name: "ApplicantModelId",
                table: "DocumentUploadModels",
                newName: "ApplicantId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentUploadModels_ApplicantModelId",
                table: "DocumentUploadModels",
                newName: "IX_DocumentUploadModels_ApplicantId");

            migrationBuilder.AddColumn<int>(
                name: "Applicant",
                table: "SmsModels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "GradeModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exam",
                table: "GradeModels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GradeModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "GradeModels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DocumentUploadModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "DocumentUploadModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviousIndexNumber",
                table: "ApplicantModel",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentUploadModels_ApplicantModel_ApplicantId",
                table: "DocumentUploadModels",
                column: "ApplicantId",
                principalTable: "ApplicantModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentUploadModels_ApplicantModel_ApplicantId",
                table: "DocumentUploadModels");

            migrationBuilder.DropColumn(
                name: "Applicant",
                table: "SmsModels");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "GradeModels");

            migrationBuilder.DropColumn(
                name: "Exam",
                table: "GradeModels");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "GradeModels");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "GradeModels");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DocumentUploadModels");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "DocumentUploadModels");

            migrationBuilder.DropColumn(
                name: "PreviousIndexNumber",
                table: "ApplicantModel");

            migrationBuilder.RenameColumn(
                name: "ApplicantId",
                table: "DocumentUploadModels",
                newName: "ApplicantModelId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentUploadModels_ApplicantId",
                table: "DocumentUploadModels",
                newName: "IX_DocumentUploadModels_ApplicantModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentUploadModels_ApplicantModel_ApplicantModelId",
                table: "DocumentUploadModels",
                column: "ApplicantModelId",
                principalTable: "ApplicantModel",
                principalColumn: "Id");
        }
    }
}
