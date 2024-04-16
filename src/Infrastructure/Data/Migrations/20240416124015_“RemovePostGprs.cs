using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicantPortal.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovePostGprs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostGprs",
                table: "ApplicantModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostGprs",
                table: "ApplicantModel",
                type: "text",
                nullable: true);
        }
    }
}
