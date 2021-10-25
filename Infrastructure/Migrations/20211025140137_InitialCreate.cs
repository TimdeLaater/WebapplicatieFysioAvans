using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentPlanModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountOfTreaments = table.Column<int>(type: "int", nullable: false),
                    TreatmentTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentPlanModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Therapist",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapist", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Therapist_Person_Email",
                        column: x => x.Email,
                        principalTable: "Person",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientFileModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueDiscription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaCodeAndDiscription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntakeDoneByEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IntakeSupervisionEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TherapistEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RegistrationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFileModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientFileModel_Person_IntakeDoneByEmail",
                        column: x => x.IntakeDoneByEmail,
                        principalTable: "Person",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientFileModel_Person_IntakeSupervisionEmail",
                        column: x => x.IntakeSupervisionEmail,
                        principalTable: "Person",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientFileModel_Person_TherapistEmail",
                        column: x => x.TherapistEmail,
                        principalTable: "Person",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientFileModel_TreatmentPlanModel_TreatmentPlanId",
                        column: x => x.TreatmentPlanId,
                        principalTable: "TreatmentPlanModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BigNr = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    PersonnelNr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Teacher_Therapist_Email",
                        column: x => x.Email,
                        principalTable: "Therapist",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentByEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CommentVisibleForPatient = table.Column<bool>(type: "bit", nullable: false),
                    PatientFileModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentModel_PatientFileModel_PatientFileModelId",
                        column: x => x.PatientFileModelId,
                        principalTable: "PatientFileModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentModel_Person_CommentByEmail",
                        column: x => x.CommentByEmail,
                        principalTable: "Person",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNr = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolNr = table.Column<int>(type: "int", nullable: false),
                    PatientNr = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientDossierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Patient_PatientFileModel_PatientDossierId",
                        column: x => x.PatientDossierId,
                        principalTable: "PatientFileModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_Person_Email",
                        column: x => x.Email,
                        principalTable: "Person",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VektisType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TreatmentOrTrainingRoom = table.Column<bool>(type: "bit", nullable: false),
                    Complications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentByEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TreatmentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TreatmentEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientFileModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentModel_PatientFileModel_PatientFileModelId",
                        column: x => x.PatientFileModelId,
                        principalTable: "PatientFileModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreatmentModel_Person_TreatmentByEmail",
                        column: x => x.TreatmentByEmail,
                        principalTable: "Person",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentNr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Student_Teacher_Email",
                        column: x => x.Email,
                        principalTable: "Teacher",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel_CommentByEmail",
                table: "CommentModel",
                column: "CommentByEmail");

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel_PatientFileModelId",
                table: "CommentModel",
                column: "PatientFileModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PatientDossierId",
                table: "Patient",
                column: "PatientDossierId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFileModel_IntakeDoneByEmail",
                table: "PatientFileModel",
                column: "IntakeDoneByEmail");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFileModel_IntakeSupervisionEmail",
                table: "PatientFileModel",
                column: "IntakeSupervisionEmail");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFileModel_TherapistEmail",
                table: "PatientFileModel",
                column: "TherapistEmail");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFileModel_TreatmentPlanId",
                table: "PatientFileModel",
                column: "TreatmentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentModel_PatientFileModelId",
                table: "TreatmentModel",
                column: "PatientFileModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentModel_TreatmentByEmail",
                table: "TreatmentModel",
                column: "TreatmentByEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentModel");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "TreatmentModel");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "PatientFileModel");

            migrationBuilder.DropTable(
                name: "Therapist");

            migrationBuilder.DropTable(
                name: "TreatmentPlanModel");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
