using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MICLifePortal.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BenefeciaryTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefeciaryTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContractorTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SName = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientSecret = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "EntityTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SName = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCodeInt = table.Column<int>(type: "int", nullable: false),
                    ProductCodeExt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectorId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReasonsCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmallName = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonsCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReasonsTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SName = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonsTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "TokenResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiresIn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenResponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalID = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ContactType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contacts_ContractorTypes_ContactType",
                        column: x => x.ContactType,
                        principalTable: "ContractorTypes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Reasons",
                columns: table => new
                {
                    ReasonsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonsCategoryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reasons", x => x.ReasonsID);
                    table.ForeignKey(
                        name: "FK_Reasons_ReasonsCategories_ReasonsCategoryID",
                        column: x => x.ReasonsCategoryID,
                        principalTable: "ReasonsCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RejectedEntities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefuseTID = table.Column<int>(type: "int", nullable: true),
                    RejectedEntityType = table.Column<int>(type: "int", nullable: true),
                    ContractorID = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    CustomerCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentNo = table.Column<int>(type: "int", nullable: true),
                    ProductCode = table.Column<int>(type: "int", nullable: true),
                    BeneficiaryType = table.Column<int>(type: "int", nullable: true),
                    BeneficiaryTID = table.Column<int>(type: "int", nullable: true),
                    RepaymentNo = table.Column<int>(type: "int", nullable: true),
                    PremiumValue = table.Column<double>(type: "float", nullable: true),
                    RefuseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReasonId = table.Column<int>(type: "int", nullable: true),
                    OtherReasons = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RejectedEntities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RejectedEntities_BenefeciaryTypes_BeneficiaryType",
                        column: x => x.BeneficiaryType,
                        principalTable: "BenefeciaryTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RejectedEntities_Contacts_BeneficiaryTID",
                        column: x => x.BeneficiaryTID,
                        principalTable: "Contacts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RejectedEntities_Contacts_ContractorID",
                        column: x => x.ContractorID,
                        principalTable: "Contacts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RejectedEntities_Contacts_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Contacts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RejectedEntities_EntityTypes_RejectedEntityType",
                        column: x => x.RejectedEntityType,
                        principalTable: "EntityTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RejectedEntities_ReasonsTypes_RefuseTID",
                        column: x => x.RefuseTID,
                        principalTable: "ReasonsTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RejectedEntities_Reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "Reasons",
                        principalColumn: "ReasonsID");
                });

            migrationBuilder.CreateTable(
                name: "RejectionBeneficiaries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RejectedEntityID = table.Column<int>(type: "int", nullable: true),
                    BeneficiaryID = table.Column<int>(type: "int", nullable: true),
                    BeneficiaryPrec = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RejectionBeneficiaries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RejectionBeneficiaries_Contacts_BeneficiaryID",
                        column: x => x.BeneficiaryID,
                        principalTable: "Contacts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RejectionBeneficiaries_RejectedEntities_RejectedEntityID",
                        column: x => x.RejectedEntityID,
                        principalTable: "RejectedEntities",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactType",
                table: "Contacts",
                column: "ContactType");

            migrationBuilder.CreateIndex(
                name: "IX_Reasons_ReasonsCategoryID",
                table: "Reasons",
                column: "ReasonsCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_RejectedEntities_BeneficiaryTID",
                table: "RejectedEntities",
                column: "BeneficiaryTID");

            migrationBuilder.CreateIndex(
                name: "IX_RejectedEntities_BeneficiaryType",
                table: "RejectedEntities",
                column: "BeneficiaryType");

            migrationBuilder.CreateIndex(
                name: "IX_RejectedEntities_ContractorID",
                table: "RejectedEntities",
                column: "ContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_RejectedEntities_CustomerID",
                table: "RejectedEntities",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_RejectedEntities_ReasonId",
                table: "RejectedEntities",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_RejectedEntities_RefuseTID",
                table: "RejectedEntities",
                column: "RefuseTID");

            migrationBuilder.CreateIndex(
                name: "IX_RejectedEntities_RejectedEntityType",
                table: "RejectedEntities",
                column: "RejectedEntityType");

            migrationBuilder.CreateIndex(
                name: "IX_RejectionBeneficiaries_BeneficiaryID",
                table: "RejectionBeneficiaries",
                column: "BeneficiaryID");

            migrationBuilder.CreateIndex(
                name: "IX_RejectionBeneficiaries_RejectedEntityID",
                table: "RejectionBeneficiaries",
                column: "RejectedEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RejectionBeneficiaries");

            migrationBuilder.DropTable(
                name: "TokenResponses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RejectedEntities");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "BenefeciaryTypes");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "EntityTypes");

            migrationBuilder.DropTable(
                name: "ReasonsTypes");

            migrationBuilder.DropTable(
                name: "Reasons");

            migrationBuilder.DropTable(
                name: "ContractorTypes");

            migrationBuilder.DropTable(
                name: "ReasonsCategories");
        }
    }
}
