using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class seperate_inv_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "deadLineTime",
                table: "toDoItems",
                newName: "DeadLineTime");

            migrationBuilder.RenameColumn(
                name: "creationTime",
                table: "toDoItems",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "completionTime",
                table: "toDoItems",
                newName: "CompletionTime");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "toDoItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_toDoItems_UserId",
                table: "toDoItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_toDoItems_Users_UserId",
                table: "toDoItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_toDoItems_Users_UserId",
                table: "toDoItems");

            migrationBuilder.DropIndex(
                name: "IX_toDoItems_UserId",
                table: "toDoItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "toDoItems");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "DeadLineTime",
                table: "toDoItems",
                newName: "deadLineTime");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "toDoItems",
                newName: "creationTime");

            migrationBuilder.RenameColumn(
                name: "CompletionTime",
                table: "toDoItems",
                newName: "completionTime");
        }
    }
}
