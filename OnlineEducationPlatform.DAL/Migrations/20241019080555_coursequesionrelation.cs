using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEducationPlatform.DAL.Migrations
{
    /// <inheritdoc />
    public partial class coursequesionrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QuizResult_StudentId",
                table: "QuizResult");

            migrationBuilder.DropIndex(
                name: "IX_ExamResult_StudentId",
                table: "ExamResult");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Question",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizResult_StudentId_QuizId",
                table: "QuizResult",
                columns: new[] { "StudentId", "QuizId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_CourseId",
                table: "Question",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResult_StudentId_ExamId",
                table: "ExamResult",
                columns: new[] { "StudentId", "ExamId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Course_CourseId",
                table: "Question",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Course_CourseId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_QuizResult_StudentId_QuizId",
                table: "QuizResult");

            migrationBuilder.DropIndex(
                name: "IX_Question_CourseId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_ExamResult_StudentId_ExamId",
                table: "ExamResult");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Question");

            migrationBuilder.CreateIndex(
                name: "IX_QuizResult_StudentId",
                table: "QuizResult",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResult_StudentId",
                table: "ExamResult",
                column: "StudentId");
        }
    }
}
