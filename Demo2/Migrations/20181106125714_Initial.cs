using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mark_Student_StudentRollNumber",
                table: "Mark");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mark",
                table: "Mark");

            migrationBuilder.RenameTable(
                name: "Mark",
                newName: "Marks");

            migrationBuilder.RenameIndex(
                name: "IX_Mark_StudentRollNumber",
                table: "Marks",
                newName: "IX_Marks_StudentRollNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marks",
                table: "Marks",
                column: "ID");

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "RollNumber", "CreatedAt", "Email", "FirstName", "LastName", "Status", "UpdatedAt" },
                values: new object[] { "A001", new DateTime(2018, 11, 6, 19, 57, 14, 403, DateTimeKind.Local), "tinhgiang9898@gmail.com", "Giang", "Tinh", 1, new DateTime(2018, 11, 6, 19, 57, 14, 404, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "RollNumber", "CreatedAt", "Email", "FirstName", "LastName", "Status", "UpdatedAt" },
                values: new object[] { "A002", new DateTime(2018, 11, 6, 19, 57, 14, 404, DateTimeKind.Local), "ly@gmail.com", "Huong", "Ly", 1, new DateTime(2018, 11, 6, 19, 57, 14, 404, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "RollNumber", "CreatedAt", "Email", "FirstName", "LastName", "Status", "UpdatedAt" },
                values: new object[] { "A003", new DateTime(2018, 11, 6, 19, 57, 14, 404, DateTimeKind.Local), "thanhtung@gmail.com", "Thanh", "Tung", 1, new DateTime(2018, 11, 6, 19, 57, 14, 404, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "ID", "StudentRollNumber", "SubjectMark", "SubjectName" },
                values: new object[] { 1, "A001", 20, "Java" });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "ID", "StudentRollNumber", "SubjectMark", "SubjectName" },
                values: new object[] { 2, "A002", 20, "C#" });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "ID", "StudentRollNumber", "SubjectMark", "SubjectName" },
                values: new object[] { 3, "A003", 20, "PHP" });

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Student_StudentRollNumber",
                table: "Marks",
                column: "StudentRollNumber",
                principalTable: "Student",
                principalColumn: "RollNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Student_StudentRollNumber",
                table: "Marks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marks",
                table: "Marks");

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "RollNumber",
                keyValue: "A001");

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "RollNumber",
                keyValue: "A002");

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "RollNumber",
                keyValue: "A003");

            migrationBuilder.RenameTable(
                name: "Marks",
                newName: "Mark");

            migrationBuilder.RenameIndex(
                name: "IX_Marks_StudentRollNumber",
                table: "Mark",
                newName: "IX_Mark_StudentRollNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mark",
                table: "Mark",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mark_Student_StudentRollNumber",
                table: "Mark",
                column: "StudentRollNumber",
                principalTable: "Student",
                principalColumn: "RollNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
