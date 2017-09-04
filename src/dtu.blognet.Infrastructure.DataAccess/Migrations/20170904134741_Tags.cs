using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dtu.blognet.Infrastructure.DataAccess.Migrations
{
    public partial class Tags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "BlogTags");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "BlogTags",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Blogs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogTags_TagId",
                table: "BlogTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_TagId",
                table: "Blogs",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Tags_TagId",
                table: "Blogs",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTags_Tags_TagId",
                table: "BlogTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Tags_TagId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogTags_Tags_TagId",
                table: "BlogTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_BlogTags_TagId",
                table: "BlogTags");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_TagId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BlogTags",
                nullable: true);
        }
    }
}
