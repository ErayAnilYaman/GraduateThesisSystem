using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "Keywords",
                columns: table => new
                {
                    KeywordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeywordText = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.KeywordID);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTopics",
                columns: table => new
                {
                    SubjectTopicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTopics", x => x.SubjectTopicID);
                });

            migrationBuilder.CreateTable(
                name: "Supervisors",
                columns: table => new
                {
                    SupervisorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupervisorName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisors", x => x.SupervisorID);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    UniversityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.UniversityID);
                });

            migrationBuilder.CreateTable(
                name: "Institutes",
                columns: table => new
                {
                    InstituteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituteName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UniversityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutes", x => x.InstituteID);
                    table.ForeignKey(
                        name: "FK_Institutes_Universities_UniversityID",
                        column: x => x.UniversityID,
                        principalTable: "Universities",
                        principalColumn: "UniversityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Theses",
                columns: table => new
                {
                    ThesisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThesisNumber = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Abstract = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    ThesisYear = table.Column<int>(type: "int", nullable: false),
                    ThesisType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UniversityID = table.Column<int>(type: "int", nullable: false),
                    InstituteID = table.Column<int>(type: "int", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    ThesisLanguage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theses", x => x.ThesisID);
                    table.ForeignKey(
                        name: "FK_Theses_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Theses_Institutes_InstituteID",
                        column: x => x.InstituteID,
                        principalTable: "Institutes",
                        principalColumn: "InstituteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Theses_Universities_UniversityID",
                        column: x => x.UniversityID,
                        principalTable: "Universities",
                        principalColumn: "UniversityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoSupervisorTheses",
                columns: table => new
                {
                    CoSupervisorThesisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThesisID = table.Column<int>(type: "int", nullable: false),
                    SupervisorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoSupervisorTheses", x => x.CoSupervisorThesisID);
                    table.ForeignKey(
                        name: "FK_CoSupervisorTheses_Supervisors_SupervisorID",
                        column: x => x.SupervisorID,
                        principalTable: "Supervisors",
                        principalColumn: "SupervisorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoSupervisorTheses_Theses_ThesisID",
                        column: x => x.ThesisID,
                        principalTable: "Theses",
                        principalColumn: "ThesisID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThesisKeywords",
                columns: table => new
                {
                    ThesisKeywordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThesisID = table.Column<int>(type: "int", nullable: false),
                    KeywordID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesisKeywords", x => x.ThesisKeywordID);
                    table.ForeignKey(
                        name: "FK_ThesisKeywords_Keywords_KeywordID",
                        column: x => x.KeywordID,
                        principalTable: "Keywords",
                        principalColumn: "KeywordID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThesisKeywords_Theses_ThesisID",
                        column: x => x.ThesisID,
                        principalTable: "Theses",
                        principalColumn: "ThesisID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThesisSubjectTopics",
                columns: table => new
                {
                    ThesisSubjectTopicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThesisID = table.Column<int>(type: "int", nullable: false),
                    SubjectTopicID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesisSubjectTopics", x => x.ThesisSubjectTopicID);
                    table.ForeignKey(
                        name: "FK_ThesisSubjectTopics_SubjectTopics_SubjectTopicID",
                        column: x => x.SubjectTopicID,
                        principalTable: "SubjectTopics",
                        principalColumn: "SubjectTopicID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThesisSubjectTopics_Theses_ThesisID",
                        column: x => x.ThesisID,
                        principalTable: "Theses",
                        principalColumn: "ThesisID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThesisSupervisors",
                columns: table => new
                {
                    ThesisSupervisorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThesisID = table.Column<int>(type: "int", nullable: false),
                    SupervisorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesisSupervisors", x => x.ThesisSupervisorID);
                    table.ForeignKey(
                        name: "FK_ThesisSupervisors_Supervisors_SupervisorID",
                        column: x => x.SupervisorID,
                        principalTable: "Supervisors",
                        principalColumn: "SupervisorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThesisSupervisors_Theses_ThesisID",
                        column: x => x.ThesisID,
                        principalTable: "Theses",
                        principalColumn: "ThesisID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoSupervisorTheses_SupervisorID",
                table: "CoSupervisorTheses",
                column: "SupervisorID");

            migrationBuilder.CreateIndex(
                name: "IX_CoSupervisorTheses_ThesisID",
                table: "CoSupervisorTheses",
                column: "ThesisID");

            migrationBuilder.CreateIndex(
                name: "IX_Institutes_UniversityID",
                table: "Institutes",
                column: "UniversityID");

            migrationBuilder.CreateIndex(
                name: "IX_Theses_AuthorID",
                table: "Theses",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Theses_InstituteID",
                table: "Theses",
                column: "InstituteID");

            migrationBuilder.CreateIndex(
                name: "IX_Theses_UniversityID",
                table: "Theses",
                column: "UniversityID");

            migrationBuilder.CreateIndex(
                name: "IX_ThesisKeywords_KeywordID",
                table: "ThesisKeywords",
                column: "KeywordID");

            migrationBuilder.CreateIndex(
                name: "IX_ThesisKeywords_ThesisID",
                table: "ThesisKeywords",
                column: "ThesisID");

            migrationBuilder.CreateIndex(
                name: "IX_ThesisSubjectTopics_SubjectTopicID",
                table: "ThesisSubjectTopics",
                column: "SubjectTopicID");

            migrationBuilder.CreateIndex(
                name: "IX_ThesisSubjectTopics_ThesisID",
                table: "ThesisSubjectTopics",
                column: "ThesisID");

            migrationBuilder.CreateIndex(
                name: "IX_ThesisSupervisors_SupervisorID",
                table: "ThesisSupervisors",
                column: "SupervisorID");

            migrationBuilder.CreateIndex(
                name: "IX_ThesisSupervisors_ThesisID",
                table: "ThesisSupervisors",
                column: "ThesisID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoSupervisorTheses");

            migrationBuilder.DropTable(
                name: "ThesisKeywords");

            migrationBuilder.DropTable(
                name: "ThesisSubjectTopics");

            migrationBuilder.DropTable(
                name: "ThesisSupervisors");

            migrationBuilder.DropTable(
                name: "Keywords");

            migrationBuilder.DropTable(
                name: "SubjectTopics");

            migrationBuilder.DropTable(
                name: "Supervisors");

            migrationBuilder.DropTable(
                name: "Theses");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Institutes");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
