using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dtu.blognet.Infrastructure.DataAccess.Migrations
{
    public partial class AddCreaterToBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreaterId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Comments",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreaterId",
                table: "Comments",
                column: "CreaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CreaterId",
                table: "Comments",
                column: "CreaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CreaterId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CreaterId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CreaterId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Comments");
        }
    }
}
