using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassroomPlatform.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EndUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    TotalScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupClassrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupClassrooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    GroupClassroomId = table.Column<Guid>(nullable: true),
                    GroupId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classrooms_EndUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "EndUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classrooms_GroupClassrooms_GroupClassroomId",
                        column: x => x.GroupClassroomId,
                        principalTable: "GroupClassrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classrooms_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    ClassroomId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Announcements_EndUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "EndUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assigments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    Deadline = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ClassroomId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assigments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assigments_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assigments_EndUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "EndUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EndUserClassrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClassroomId = table.Column<Guid>(nullable: true),
                    EndUserId = table.Column<Guid>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndUserClassrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EndUserClassrooms_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EndUserClassrooms_EndUsers_EndUserId",
                        column: x => x.EndUserId,
                        principalTable: "EndUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invitations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EndUserId = table.Column<Guid>(nullable: true),
                    ClassroomId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invitations_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invitations_EndUsers_EndUserId",
                        column: x => x.EndUserId,
                        principalTable: "EndUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EndUserGrades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EndUserId = table.Column<Guid>(nullable: true),
                    GradeId = table.Column<Guid>(nullable: true),
                    AssigmentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndUserGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EndUserGrades_Assigments_AssigmentId",
                        column: x => x.AssigmentId,
                        principalTable: "Assigments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EndUserGrades_EndUsers_EndUserId",
                        column: x => x.EndUserId,
                        principalTable: "EndUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EndUserGrades_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_ClassroomId",
                table: "Announcements",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_CreatorId",
                table: "Announcements",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Assigments_ClassroomId",
                table: "Assigments",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Assigments_CreatorId",
                table: "Assigments",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_CreatorId",
                table: "Classrooms",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_GroupClassroomId",
                table: "Classrooms",
                column: "GroupClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_GroupId",
                table: "Classrooms",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EndUserClassrooms_ClassroomId",
                table: "EndUserClassrooms",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_EndUserClassrooms_EndUserId",
                table: "EndUserClassrooms",
                column: "EndUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EndUserGrades_AssigmentId",
                table: "EndUserGrades",
                column: "AssigmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EndUserGrades_EndUserId",
                table: "EndUserGrades",
                column: "EndUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EndUserGrades_GradeId",
                table: "EndUserGrades",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_ClassroomId",
                table: "Invitations",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_EndUserId",
                table: "Invitations",
                column: "EndUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "EndUserClassrooms");

            migrationBuilder.DropTable(
                name: "EndUserGrades");

            migrationBuilder.DropTable(
                name: "Invitations");

            migrationBuilder.DropTable(
                name: "Assigments");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "EndUsers");

            migrationBuilder.DropTable(
                name: "GroupClassrooms");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
