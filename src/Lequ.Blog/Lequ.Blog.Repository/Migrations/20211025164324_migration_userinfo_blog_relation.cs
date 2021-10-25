using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lequ.Blog.Repository.Migrations
{
    public partial class migration_userinfo_blog_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserInfoID",
                table: "Blogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserInfoID",
                table: "Blogs",
                column: "UserInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_UserInfos_UserInfoID",
                table: "Blogs",
                column: "UserInfoID",
                principalTable: "UserInfos",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_UserInfos_UserInfoID",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_UserInfoID",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "UserInfoID",
                table: "Blogs");
        }
    }
}
