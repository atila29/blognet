using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dtu.blognet.Infrastructure.DataAccess.Migrations
{
    public partial class AddBlogOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Blogs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_OwnerId",
                table: "Blogs",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_OwnerId",
                table: "Blogs",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_OwnerId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_OwnerId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Blogs");
        }
    }
}
