using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lequ.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Details2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Image1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    About = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Categories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SurName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Blogs_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogCategory",
                columns: table => new
                {
                    BlogsID = table.Column<int>(type: "int", nullable: false),
                    CategoriesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategory", x => new { x.BlogsID, x.CategoriesID });
                    table.ForeignKey(
                        name: "FK_BlogCategory_Blogs_BlogsID",
                        column: x => x.BlogsID,
                        principalTable: "Blogs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogCategory_Categories_CategoriesID",
                        column: x => x.CategoriesID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BlogID = table.Column<int>(type: "int", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Blogs_BlogID",
                        column: x => x.BlogID,
                        principalTable: "Blogs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Comments",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "ID", "CreateBy", "CreateDate", "Password", "Status", "UpdateBy", "UpdateDate", "UserName" },
                values: new object[] { 1, 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6349), "admin", true, null, null, "admin" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "About", "CreateBy", "CreateDate", "Image", "Name", "Status", "UpdateBy", "UpdateDate" },
                values: new object[] { 1, "Coder", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6478), null, "Lequ.CO", true, null, null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CreateBy", "CreateDate", "Name", "ParentID", "Status", "UpdateBy", "UpdateDate" },
                values: new object[] { 1, 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6493), "C#", null, true, null, null });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "ID", "AuthorID", "Content", "CreateBy", "CreateDate", "Image", "Status", "Title", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, "test content 0", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6534), null, true, "test title 0", null, null },
                    { 2, 1, "test content 1", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6538), null, true, "test title 1", null, null },
                    { 3, 1, "test content 2", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6546), null, true, "test title 2", null, null },
                    { 4, 1, "test content 3", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6549), null, true, "test title 3", null, null },
                    { 5, 1, "test content 4", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6551), null, true, "test title 4", null, null },
                    { 6, 1, "test content 5", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6555), null, true, "test title 5", null, null },
                    { 7, 1, "test content 6", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6557), null, true, "test title 6", null, null },
                    { 8, 1, "test content 7", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6559), null, true, "test title 7", null, null },
                    { 9, 1, "test content 8", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6561), null, true, "test title 8", null, null },
                    { 10, 1, "test content 9", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6564), null, true, "test title 9", null, null },
                    { 11, 1, "test content 10", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6566), null, true, "test title 10", null, null },
                    { 12, 1, "test content 11", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6568), null, true, "test title 11", null, null },
                    { 13, 1, "test content 12", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6570), null, true, "test title 12", null, null },
                    { 14, 1, "test content 13", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6572), null, true, "test title 13", null, null },
                    { 15, 1, "test content 14", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6574), null, true, "test title 14", null, null },
                    { 16, 1, "test content 15", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6576), null, true, "test title 15", null, null },
                    { 17, 1, "test content 16", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6578), null, true, "test title 16", null, null },
                    { 18, 1, "test content 17", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6581), null, true, "test title 17", null, null },
                    { 19, 1, "test content 18", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6583), null, true, "test title 18", null, null },
                    { 20, 1, "test content 19", 1, new DateTime(2021, 10, 31, 10, 54, 35, 913, DateTimeKind.Local).AddTicks(6585), null, true, "test title 19", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategory_CategoriesID",
                table: "BlogCategory",
                column: "CategoriesID");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AuthorID",
                table: "Blogs",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentID",
                table: "Categories",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogID",
                table: "Comments",
                column: "BlogID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentID",
                table: "Comments",
                column: "ParentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "BlogCategory");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
