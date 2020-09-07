using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EdenClinic.Server.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Center",
                schema: "dbo",
                columns: table => new
                {
                    CenterID = table.Column<Guid>(nullable: false),
                    CenterName = table.Column<string>(nullable: true),
                    CenterAddress = table.Column<string>(nullable: true),
                    CenterPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Center", x => x.CenterID);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                schema: "dbo",
                columns: table => new
                {
                    DiagnosisID = table.Column<Guid>(nullable: false),
                    DiagnosisCode = table.Column<string>(nullable: true),
                    DiagnosisDescription = table.Column<string>(nullable: true),
                    CategoryCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.DiagnosisID);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseCategory",
                schema: "dbo",
                columns: table => new
                {
                    DiseaseCategoryID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DiseaseCategoryName = table.Column<string>(maxLength: 50, nullable: true),
                    Notes = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseCategory", x => x.DiseaseCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Drug",
                schema: "dbo",
                columns: table => new
                {
                    DrugID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DrugName = table.Column<string>(maxLength: 50, nullable: true),
                    DrugCode = table.Column<string>(maxLength: 20, nullable: true),
                    DrugPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drug", x => x.DrugID);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistoryCaption",
                schema: "dbo",
                columns: table => new
                {
                    CaptionID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    CaptionDescription = table.Column<string>(maxLength: 250, nullable: true),
                    Notes = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistoryCaption", x => x.CaptionID);
                });

            migrationBuilder.CreateTable(
                name: "MedicalProcedure",
                schema: "dbo",
                columns: table => new
                {
                    MedicalProcedureID = table.Column<Guid>(nullable: false),
                    MedicalProcedureDescription = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalProcedure", x => x.MedicalProcedureID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "dbo",
                columns: table => new
                {
                    RoleID = table.Column<Guid>(nullable: false),
                    RoleName = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Specialist",
                schema: "dbo",
                columns: table => new
                {
                    SpecialistID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    SpecialistName = table.Column<string>(maxLength: 50, nullable: false),
                    Notes = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialist", x => x.SpecialistID);
                });

            migrationBuilder.CreateTable(
                name: "TestTemplate",
                schema: "dbo",
                columns: table => new
                {
                    TestTemplateID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    TestName = table.Column<string>(maxLength: 100, nullable: true),
                    Notes = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTemplate", x => x.TestTemplateID);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentCategory",
                schema: "dbo",
                columns: table => new
                {
                    TreatmentCategoryID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    TreatmentCategoryName = table.Column<string>(maxLength: 50, nullable: true),
                    Notes = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentCategory", x => x.TreatmentCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistory",
                schema: "dbo",
                columns: table => new
                {
                    MedicalHistoryID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    MedicalDescription = table.Column<string>(maxLength: 100, nullable: true),
                    Notes = table.Column<string>(maxLength: 500, nullable: true),
                    CaptionID = table.Column<Guid>(nullable: true),
                    MedicalHistoryCaptionsCaptionID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory", x => x.MedicalHistoryID);
                    table.ForeignKey(
                        name: "FK_MedicalHistory_MedicalHistoryCaption_MedicalHistoryCaptionsCaptionID",
                        column: x => x.MedicalHistoryCaptionsCaptionID,
                        principalSchema: "dbo",
                        principalTable: "MedicalHistoryCaption",
                        principalColumn: "CaptionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePage",
                schema: "dbo",
                columns: table => new
                {
                    RolePageID = table.Column<Guid>(nullable: false),
                    PageName = table.Column<string>(nullable: true),
                    RoleID = table.Column<Guid>(nullable: true),
                    CanAccess = table.Column<bool>(nullable: false),
                    CanCreate = table.Column<bool>(nullable: false),
                    CanEdit = table.Column<bool>(nullable: false),
                    CanDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePage", x => x.RolePageID);
                    table.ForeignKey(
                        name: "FK_RolePage_Role_RoleID",
                        column: x => x.RoleID,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clinic",
                schema: "dbo",
                columns: table => new
                {
                    ClinicID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ClinicName = table.Column<string>(maxLength: 50, nullable: false),
                    Notes = table.Column<string>(maxLength: 50, nullable: true),
                    ClinicPrice = table.Column<double>(nullable: false),
                    SpecialistID = table.Column<Guid>(nullable: false),
                    CenterID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic", x => x.ClinicID);
                    table.ForeignKey(
                        name: "FK_Clinic_Center_CenterID",
                        column: x => x.CenterID,
                        principalSchema: "dbo",
                        principalTable: "Center",
                        principalColumn: "CenterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clinic_Specialist_SpecialistID",
                        column: x => x.SpecialistID,
                        principalSchema: "dbo",
                        principalTable: "Specialist",
                        principalColumn: "SpecialistID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestTemplateDetail",
                schema: "dbo",
                columns: table => new
                {
                    TestTemplateDetailID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    TestTemplateID = table.Column<Guid>(nullable: true),
                    TestItemName = table.Column<string>(maxLength: 20, nullable: true),
                    TestItemNormal = table.Column<string>(maxLength: 20, nullable: true),
                    TestItemUnit = table.Column<string>(maxLength: 10, nullable: true),
                    Notes = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTemplateDetail", x => x.TestTemplateDetailID);
                    table.ForeignKey(
                        name: "FK_TestTemplateDetail_TestTemplate_TestTemplateID",
                        column: x => x.TestTemplateID,
                        principalSchema: "dbo",
                        principalTable: "TestTemplate",
                        principalColumn: "TestTemplateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                schema: "dbo",
                columns: table => new
                {
                    TreatmentID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    TreatmentCategoryID = table.Column<Guid>(nullable: true),
                    TreatmentName = table.Column<string>(maxLength: 20, nullable: true),
                    TreatmentPrice = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.TreatmentID);
                    table.ForeignKey(
                        name: "FK_Treatment_TreatmentCategory_TreatmentCategoryID",
                        column: x => x.TreatmentCategoryID,
                        principalSchema: "dbo",
                        principalTable: "TreatmentCategory",
                        principalColumn: "TreatmentCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Disease",
                schema: "dbo",
                columns: table => new
                {
                    DiseaseID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DiseaseName = table.Column<string>(maxLength: 50, nullable: true),
                    DiseaseCode = table.Column<string>(maxLength: 50, nullable: true),
                    DiseaseDanger = table.Column<byte>(nullable: true),
                    ClinicID = table.Column<Guid>(nullable: true),
                    DiseaseCategoryID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disease", x => x.DiseaseID);
                    table.ForeignKey(
                        name: "FK_Disease_Clinic_ClinicID",
                        column: x => x.ClinicID,
                        principalSchema: "dbo",
                        principalTable: "Clinic",
                        principalColumn: "ClinicID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disease_DiseaseCategory_DiseaseCategoryID",
                        column: x => x.DiseaseCategoryID,
                        principalSchema: "dbo",
                        principalTable: "DiseaseCategory",
                        principalColumn: "DiseaseCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "dbo",
                columns: table => new
                {
                    PersonID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ApplicationUserID = table.Column<string>(nullable: true),
                    PersonName = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    PersonAddress = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    RoleID = table.Column<Guid>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    StrBirthdate = table.Column<string>(nullable: true),
                    PersonState = table.Column<int>(nullable: false),
                    PersonJob = table.Column<int>(nullable: true),
                    Gander = table.Column<int>(nullable: false),
                    ClinicID = table.Column<Guid>(nullable: true),
                    CenterID = table.Column<Guid>(nullable: true),
                    IsPatient = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Person_Center_CenterID",
                        column: x => x.CenterID,
                        principalSchema: "dbo",
                        principalTable: "Center",
                        principalColumn: "CenterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Clinic_ClinicID",
                        column: x => x.ClinicID,
                        principalSchema: "dbo",
                        principalTable: "Clinic",
                        principalColumn: "ClinicID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Role_RoleID",
                        column: x => x.RoleID,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSetting",
                schema: "dbo",
                columns: table => new
                {
                    DoctorSettingID = table.Column<Guid>(nullable: false),
                    PrintingDescription = table.Column<bool>(nullable: true),
                    DetectingInfoStartup = table.Column<byte>(nullable: true),
                    DoctorID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSetting", x => x.DoctorSettingID);
                    table.ForeignKey(
                        name: "FK_DoctorSetting_Person_DoctorID",
                        column: x => x.DoctorID,
                        principalSchema: "dbo",
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalTest",
                schema: "dbo",
                columns: table => new
                {
                    MedicalTestID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    TestDate = table.Column<DateTime>(maxLength: 25, nullable: false),
                    LabName = table.Column<string>(maxLength: 50, nullable: true),
                    Notes = table.Column<string>(maxLength: 50, nullable: true),
                    PatientID = table.Column<Guid>(nullable: true),
                    TestTemplateID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalTest", x => x.MedicalTestID);
                    table.ForeignKey(
                        name: "FK_MedicalTest_Person_PatientID",
                        column: x => x.PatientID,
                        principalSchema: "dbo",
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalTest_TestTemplate_TestTemplateID",
                        column: x => x.TestTemplateID,
                        principalSchema: "dbo",
                        principalTable: "TestTemplate",
                        principalColumn: "TestTemplateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientInfo",
                schema: "dbo",
                columns: table => new
                {
                    PatientInfoID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    PersonID = table.Column<Guid>(nullable: true),
                    Job = table.Column<string>(maxLength: 50, nullable: true),
                    MaritalStatus = table.Column<int>(nullable: false),
                    PatientIdCard = table.Column<string>(maxLength: 20, nullable: false),
                    PatientHeight = table.Column<double>(nullable: true),
                    PatientWight = table.Column<double>(nullable: true),
                    PatientJob = table.Column<string>(maxLength: 100, nullable: true),
                    PaitentKidsCount = table.Column<short>(nullable: true),
                    HasCar = table.Column<bool>(nullable: true),
                    PatientHobbys = table.Column<string>(maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientInfo", x => x.PatientInfoID);
                    table.ForeignKey(
                        name: "FK_PatientInfo_Person_PersonID",
                        column: x => x.PersonID,
                        principalSchema: "dbo",
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicalHistory",
                schema: "dbo",
                columns: table => new
                {
                    PatientMedicalHistoryID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    PatientID = table.Column<Guid>(nullable: true),
                    MedicalHistoryID = table.Column<Guid>(nullable: true),
                    IsYes = table.Column<bool>(nullable: true),
                    YesDescription = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicalHistory", x => x.PatientMedicalHistoryID);
                    table.ForeignKey(
                        name: "FK_PatientMedicalHistory_MedicalHistory_MedicalHistoryID",
                        column: x => x.MedicalHistoryID,
                        principalSchema: "dbo",
                        principalTable: "MedicalHistory",
                        principalColumn: "MedicalHistoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientMedicalHistory_Person_PatientID",
                        column: x => x.PatientID,
                        principalSchema: "dbo",
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Remark",
                schema: "dbo",
                columns: table => new
                {
                    RemarkID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    RemarkDescription = table.Column<string>(nullable: true),
                    PersonID = table.Column<Guid>(nullable: true),
                    UserID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remark", x => x.RemarkID);
                    table.ForeignKey(
                        name: "FK_Remark_Person_UserID",
                        column: x => x.UserID,
                        principalSchema: "dbo",
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                schema: "dbo",
                columns: table => new
                {
                    ReservationID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    StrReservationDate = table.Column<string>(nullable: true),
                    IsConsulting = table.Column<bool>(nullable: false),
                    PatientDetectingState = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    ClinicID = table.Column<Guid>(nullable: true),
                    PatientID = table.Column<Guid>(nullable: false),
                    DoctorID = table.Column<Guid>(nullable: true),
                    SpecialistID = table.Column<Guid>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    DiscountRatio = table.Column<double>(nullable: false),
                    DiscountValue = table.Column<double>(nullable: false),
                    Vat = table.Column<double>(nullable: false),
                    Net = table.Column<double>(nullable: false),
                    Paied = table.Column<double>(nullable: false),
                    Rest = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK_Reservation_Clinic_ClinicID",
                        column: x => x.ClinicID,
                        principalSchema: "dbo",
                        principalTable: "Clinic",
                        principalColumn: "ClinicID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Person_DoctorID",
                        column: x => x.DoctorID,
                        principalSchema: "dbo",
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Person_PatientID",
                        column: x => x.PatientID,
                        principalSchema: "dbo",
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Specialist_SpecialistID",
                        column: x => x.SpecialistID,
                        principalSchema: "dbo",
                        principalTable: "Specialist",
                        principalColumn: "SpecialistID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemAction",
                schema: "dbo",
                columns: table => new
                {
                    ActionID = table.Column<Guid>(nullable: false),
                    PersonID = table.Column<Guid>(nullable: true),
                    ActionName = table.Column<string>(maxLength: 50, nullable: true),
                    TableName = table.Column<string>(maxLength: 50, nullable: true),
                    ActionDate = table.Column<DateTime>(nullable: false),
                    ActionJson = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemAction", x => x.ActionID);
                    table.ForeignKey(
                        name: "FK_SystemAction_Person_PersonID",
                        column: x => x.PersonID,
                        principalSchema: "dbo",
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Treasury",
                schema: "dbo",
                columns: table => new
                {
                    TreasuryID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Amount = table.Column<double>(nullable: true),
                    ClinicID = table.Column<Guid>(nullable: true),
                    ActionDate = table.Column<DateTime>(nullable: false),
                    PersonID = table.Column<Guid>(nullable: true),
                    ActionDescription = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treasury", x => x.TreasuryID);
                    table.ForeignKey(
                        name: "FK_Treasury_Clinic_ClinicID",
                        column: x => x.ClinicID,
                        principalSchema: "dbo",
                        principalTable: "Clinic",
                        principalColumn: "ClinicID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Treasury_Person_PersonID",
                        column: x => x.PersonID,
                        principalSchema: "dbo",
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkingSheet",
                schema: "dbo",
                columns: table => new
                {
                    SheetID = table.Column<Guid>(nullable: false),
                    SheetDate = table.Column<string>(maxLength: 20, nullable: true),
                    SheetDay = table.Column<string>(maxLength: 15, nullable: true),
                    PersonID = table.Column<Guid>(nullable: true),
                    StartTime = table.Column<DateTime>(maxLength: 10, nullable: false),
                    EndTime = table.Column<DateTime>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingSheet", x => x.SheetID);
                    table.ForeignKey(
                        name: "FK_WorkingSheet_Person_PersonID",
                        column: x => x.PersonID,
                        principalSchema: "dbo",
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalTestsDetail",
                schema: "dbo",
                columns: table => new
                {
                    MedicalTestDetailID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    MedicalTestID = table.Column<Guid>(nullable: true),
                    TestTemplateDetailID = table.Column<Guid>(nullable: true),
                    TestValue = table.Column<string>(maxLength: 10, nullable: true),
                    Notes = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalTestsDetail", x => x.MedicalTestDetailID);
                    table.ForeignKey(
                        name: "FK_MedicalTestsDetail_MedicalTest_MedicalTestID",
                        column: x => x.MedicalTestID,
                        principalSchema: "dbo",
                        principalTable: "MedicalTest",
                        principalColumn: "MedicalTestID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalTestsDetail_TestTemplateDetail_TestTemplateDetailID",
                        column: x => x.TestTemplateDetailID,
                        principalSchema: "dbo",
                        principalTable: "TestTemplateDetail",
                        principalColumn: "TestTemplateDetailID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClinicalHistory",
                schema: "dbo",
                columns: table => new
                {
                    ClinicalHistoryID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ReservationID = table.Column<Guid>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalHistory", x => x.ClinicalHistoryID);
                    table.ForeignKey(
                        name: "FK_ClinicalHistory_Reservation_ReservationID",
                        column: x => x.ReservationID,
                        principalSchema: "dbo",
                        principalTable: "Reservation",
                        principalColumn: "ReservationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                schema: "dbo",
                columns: table => new
                {
                    PrescriptionID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ReservationID = table.Column<Guid>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    DiagnosisID = table.Column<Guid>(nullable: true),
                    MedicalProcedureID = table.Column<Guid>(nullable: true),
                    ChiefComplaint = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.PrescriptionID);
                    table.ForeignKey(
                        name: "FK_Prescription_Diagnosis_DiagnosisID",
                        column: x => x.DiagnosisID,
                        principalSchema: "dbo",
                        principalTable: "Diagnosis",
                        principalColumn: "DiagnosisID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescription_MedicalProcedure_MedicalProcedureID",
                        column: x => x.MedicalProcedureID,
                        principalSchema: "dbo",
                        principalTable: "MedicalProcedure",
                        principalColumn: "MedicalProcedureID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescription_Reservation_ReservationID",
                        column: x => x.ReservationID,
                        principalSchema: "dbo",
                        principalTable: "Reservation",
                        principalColumn: "ReservationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionDetail",
                schema: "dbo",
                columns: table => new
                {
                    PrescriptionDetailID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    PrescriptionID = table.Column<Guid>(nullable: true),
                    DrugID = table.Column<Guid>(nullable: true),
                    Dosage = table.Column<double>(nullable: true),
                    Count = table.Column<byte>(nullable: true),
                    DaysCount = table.Column<byte>(nullable: true),
                    DiseaseID = table.Column<Guid>(nullable: true),
                    TreatmentID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionDetail", x => x.PrescriptionDetailID);
                    table.ForeignKey(
                        name: "FK_PrescriptionDetail_Disease_DiseaseID",
                        column: x => x.DiseaseID,
                        principalSchema: "dbo",
                        principalTable: "Disease",
                        principalColumn: "DiseaseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescriptionDetail_Drug_DrugID",
                        column: x => x.DrugID,
                        principalSchema: "dbo",
                        principalTable: "Drug",
                        principalColumn: "DrugID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescriptionDetail_Prescription_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalSchema: "dbo",
                        principalTable: "Prescription",
                        principalColumn: "PrescriptionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescriptionDetail_Treatment_TreatmentID",
                        column: x => x.TreatmentID,
                        principalSchema: "dbo",
                        principalTable: "Treatment",
                        principalColumn: "TreatmentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "dbo",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "dbo",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "dbo",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "dbo",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_CenterID",
                schema: "dbo",
                table: "Clinic",
                column: "CenterID");

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_SpecialistID",
                schema: "dbo",
                table: "Clinic",
                column: "SpecialistID");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalHistory_ReservationID",
                schema: "dbo",
                table: "ClinicalHistory",
                column: "ReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_Disease_ClinicID",
                schema: "dbo",
                table: "Disease",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_Disease_DiseaseCategoryID",
                schema: "dbo",
                table: "Disease",
                column: "DiseaseCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSetting_DoctorID",
                schema: "dbo",
                table: "DoctorSetting",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_MedicalHistoryCaptionsCaptionID",
                schema: "dbo",
                table: "MedicalHistory",
                column: "MedicalHistoryCaptionsCaptionID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalTest_PatientID",
                schema: "dbo",
                table: "MedicalTest",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalTest_TestTemplateID",
                schema: "dbo",
                table: "MedicalTest",
                column: "TestTemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalTestsDetail_MedicalTestID",
                schema: "dbo",
                table: "MedicalTestsDetail",
                column: "MedicalTestID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalTestsDetail_TestTemplateDetailID",
                schema: "dbo",
                table: "MedicalTestsDetail",
                column: "TestTemplateDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInfo_PersonID",
                schema: "dbo",
                table: "PatientInfo",
                column: "PersonID",
                unique: true,
                filter: "[PersonID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalHistory_MedicalHistoryID",
                schema: "dbo",
                table: "PatientMedicalHistory",
                column: "MedicalHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalHistory_PatientID",
                schema: "dbo",
                table: "PatientMedicalHistory",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CenterID",
                schema: "dbo",
                table: "Person",
                column: "CenterID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ClinicID",
                schema: "dbo",
                table: "Person",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_RoleID",
                schema: "dbo",
                table: "Person",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_DiagnosisID",
                schema: "dbo",
                table: "Prescription",
                column: "DiagnosisID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_MedicalProcedureID",
                schema: "dbo",
                table: "Prescription",
                column: "MedicalProcedureID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_ReservationID",
                schema: "dbo",
                table: "Prescription",
                column: "ReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDetail_DiseaseID",
                schema: "dbo",
                table: "PrescriptionDetail",
                column: "DiseaseID");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDetail_DrugID",
                schema: "dbo",
                table: "PrescriptionDetail",
                column: "DrugID");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDetail_PrescriptionID",
                schema: "dbo",
                table: "PrescriptionDetail",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDetail_TreatmentID",
                schema: "dbo",
                table: "PrescriptionDetail",
                column: "TreatmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Remark_UserID",
                schema: "dbo",
                table: "Remark",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ClinicID",
                schema: "dbo",
                table: "Reservation",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_DoctorID",
                schema: "dbo",
                table: "Reservation",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PatientID",
                schema: "dbo",
                table: "Reservation",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_SpecialistID",
                schema: "dbo",
                table: "Reservation",
                column: "SpecialistID");

            migrationBuilder.CreateIndex(
                name: "IX_RolePage_RoleID",
                schema: "dbo",
                table: "RolePage",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_SystemAction_PersonID",
                schema: "dbo",
                table: "SystemAction",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_TestTemplateDetail_TestTemplateID",
                schema: "dbo",
                table: "TestTemplateDetail",
                column: "TestTemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_Treasury_ClinicID",
                schema: "dbo",
                table: "Treasury",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_Treasury_PersonID",
                schema: "dbo",
                table: "Treasury",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_TreatmentCategoryID",
                schema: "dbo",
                table: "Treatment",
                column: "TreatmentCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSheet_PersonID",
                schema: "dbo",
                table: "WorkingSheet",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ClinicalHistory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DoctorSetting",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MedicalTestsDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PatientInfo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PatientMedicalHistory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PrescriptionDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Remark",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RolePage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SystemAction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Treasury",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WorkingSheet",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MedicalTest",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TestTemplateDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MedicalHistory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Disease",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Drug",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Prescription",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Treatment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TestTemplate",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MedicalHistoryCaption",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DiseaseCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Diagnosis",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MedicalProcedure",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Reservation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TreatmentCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Clinic",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Center",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Specialist",
                schema: "dbo");
        }
    }
}
