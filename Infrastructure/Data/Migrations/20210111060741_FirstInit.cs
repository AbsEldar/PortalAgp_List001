using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class FirstInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LstDefaults",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    KeyIndex = table.Column<string>(nullable: true),
                    LstTypeItem = table.Column<int>(nullable: false),
                    LstTypeClass = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LstDefaults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LstDefaults_LstDefaults_ParentId",
                        column: x => x.ParentId,
                        principalTable: "LstDefaults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LstDogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    KeyIndex = table.Column<string>(nullable: true),
                    LstTypeItem = table.Column<int>(nullable: false),
                    LstTypeClass = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DogAuthor = table.Column<string>(maxLength: 100, nullable: false),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LstDogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LstDogs_LstDogs_ParentId",
                        column: x => x.ParentId,
                        principalTable: "LstDogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LstOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    KeyIndex = table.Column<string>(nullable: true),
                    LstTypeItem = table.Column<int>(nullable: false),
                    LstTypeClass = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    OrderCode = table.Column<string>(maxLength: 100, nullable: false),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LstOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LstOrders_LstOrders_ParentId",
                        column: x => x.ParentId,
                        principalTable: "LstOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LstDefaults_ParentId",
                table: "LstDefaults",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_LstDogs_ParentId",
                table: "LstDogs",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_LstOrders_ParentId",
                table: "LstOrders",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LstDefaults");

            migrationBuilder.DropTable(
                name: "LstDogs");

            migrationBuilder.DropTable(
                name: "LstOrders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
