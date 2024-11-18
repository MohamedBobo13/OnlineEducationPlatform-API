using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEducationPlatform.DAL.Migrations
{
    /// <inheritdoc />
    public partial class swapmarksawarded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarksAwarded",
                table: "AnswerResult");

            migrationBuilder.AddColumn<decimal>(
                name: "MarksAwarded",
                table: "Answer",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarksAwarded",
                table: "Answer");

            migrationBuilder.AddColumn<decimal>(
                name: "MarksAwarded",
                table: "AnswerResult",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
