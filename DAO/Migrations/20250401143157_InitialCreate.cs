using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VaccineCategories",
                columns: table => new
                {
                    VaccineCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineCategories", x => x.VaccineCategoryId);
                    table.ForeignKey(
                        name: "FK_VaccineCategories_VaccineCategories_FKParentCategoryId",
                        column: x => x.FKParentCategoryId,
                        principalTable: "VaccineCategories",
                        principalColumn: "VaccineCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "VaccineCenters",
                columns: table => new
                {
                    VacineCenterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineCenters", x => x.VacineCenterId);
                });

            migrationBuilder.CreateTable(
                name: "VaccinePackages",
                columns: table => new
                {
                    VaccinePackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackageDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackageStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinePackages", x => x.VaccinePackageId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKCenterId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_VaccineCenters_FKCenterId",
                        column: x => x.FKCenterId,
                        principalTable: "VaccineCenters",
                        principalColumn: "VacineCenterId");
                });

            migrationBuilder.CreateTable(
                name: "VaccineBatches",
                columns: table => new
                {
                    VaccineBatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKCenterId = table.Column<int>(type: "int", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineBatches", x => x.VaccineBatchId);
                    table.ForeignKey(
                        name: "FK_VaccineBatches_VaccineCenters_FKCenterId",
                        column: x => x.FKCenterId,
                        principalTable: "VaccineCenters",
                        principalColumn: "VacineCenterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChildrenProfiles",
                columns: table => new
                {
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildrenProfiles", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_ChildrenProfiles_Accounts_FKAccountId",
                        column: x => x.FKAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    VaccineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKCategoryId = table.Column<int>(type: "int", nullable: false),
                    FKBatchId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitOfVolume = table.Column<int>(type: "int", nullable: false),
                    IngredientsDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinAge = table.Column<int>(type: "int", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: false),
                    BetweenPeriod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.VaccineId);
                    table.ForeignKey(
                        name: "FK_Vaccines_VaccineBatches_FKBatchId",
                        column: x => x.FKBatchId,
                        principalTable: "VaccineBatches",
                        principalColumn: "VaccineBatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vaccines_VaccineCategories_FKCategoryId",
                        column: x => x.FKCategoryId,
                        principalTable: "VaccineCategories",
                        principalColumn: "VaccineCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalAmountPrice = table.Column<int>(type: "int", nullable: false),
                    TotalPaidPrice = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_ChildrenProfiles_FKProfileId",
                        column: x => x.FKProfileId,
                        principalTable: "ChildrenProfiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaccineHistories",
                columns: table => new
                {
                    VacineHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKVaccineId = table.Column<int>(type: "int", nullable: false),
                    FKProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdministeredBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FKCenterId = table.Column<int>(type: "int", nullable: false),
                    AdministeredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DosedNumber = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerifiedStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineHistories", x => x.VacineHistoryId);
                    table.ForeignKey(
                        name: "FK_VaccineHistories_ChildrenProfiles_FKProfileId",
                        column: x => x.FKProfileId,
                        principalTable: "ChildrenProfiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VaccineHistories_VaccineCenters_FKCenterId",
                        column: x => x.FKCenterId,
                        principalTable: "VaccineCenters",
                        principalColumn: "VacineCenterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VaccineHistories_Vaccines_FKVaccineId",
                        column: x => x.FKVaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "VaccineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VaccinePackageDetails",
                columns: table => new
                {
                    VaccinePackageDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKVaccineId = table.Column<int>(type: "int", nullable: false),
                    FKVaccinePackageId = table.Column<int>(type: "int", nullable: false),
                    PackagePrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinePackageDetails", x => x.VaccinePackageDetailId);
                    table.ForeignKey(
                        name: "FK_VaccinePackageDetails_VaccinePackages_FKVaccinePackageId",
                        column: x => x.FKVaccinePackageId,
                        principalTable: "VaccinePackages",
                        principalColumn: "VaccinePackageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinePackageDetails_Vaccines_FKVaccineId",
                        column: x => x.FKVaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "VaccineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKVaccineId = table.Column<int>(type: "int", nullable: true),
                    FKVaccinePackageId = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_FKOrderId",
                        column: x => x.FKOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_VaccinePackages_FKVaccinePackageId",
                        column: x => x.FKVaccinePackageId,
                        principalTable: "VaccinePackages",
                        principalColumn: "VaccinePackageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Vaccines_FKVaccineId",
                        column: x => x.FKVaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "VaccineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationSchedules",
                columns: table => new
                {
                    VaccinationScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKCenterId = table.Column<int>(type: "int", nullable: false),
                    FKOrderDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoseNumber = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdministeredBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationSchedules", x => x.VaccinationScheduleId);
                    table.ForeignKey(
                        name: "FK_VaccinationSchedules_ChildrenProfiles_FKProfileId",
                        column: x => x.FKProfileId,
                        principalTable: "ChildrenProfiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinationSchedules_OrderDetails_FKOrderDetailsId",
                        column: x => x.FKOrderDetailsId,
                        principalTable: "OrderDetails",
                        principalColumn: "OrderDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VaccinationSchedules_VaccineCenters_FKCenterId",
                        column: x => x.FKCenterId,
                        principalTable: "VaccineCenters",
                        principalColumn: "VacineCenterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_FKCenterId",
                table: "Accounts",
                column: "FKCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildrenProfiles_FKAccountId",
                table: "ChildrenProfiles",
                column: "FKAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_FKOrderId",
                table: "OrderDetails",
                column: "FKOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_FKVaccineId",
                table: "OrderDetails",
                column: "FKVaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_FKVaccinePackageId",
                table: "OrderDetails",
                column: "FKVaccinePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FKProfileId",
                table: "Orders",
                column: "FKProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationSchedules_FKCenterId",
                table: "VaccinationSchedules",
                column: "FKCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationSchedules_FKOrderDetailsId",
                table: "VaccinationSchedules",
                column: "FKOrderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationSchedules_FKProfileId",
                table: "VaccinationSchedules",
                column: "FKProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineBatches_FKCenterId",
                table: "VaccineBatches",
                column: "FKCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineCategories_FKParentCategoryId",
                table: "VaccineCategories",
                column: "FKParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineHistories_FKCenterId",
                table: "VaccineHistories",
                column: "FKCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineHistories_FKProfileId",
                table: "VaccineHistories",
                column: "FKProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineHistories_FKVaccineId",
                table: "VaccineHistories",
                column: "FKVaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinePackageDetails_FKVaccineId",
                table: "VaccinePackageDetails",
                column: "FKVaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinePackageDetails_FKVaccinePackageId",
                table: "VaccinePackageDetails",
                column: "FKVaccinePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_FKBatchId",
                table: "Vaccines",
                column: "FKBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_FKCategoryId",
                table: "Vaccines",
                column: "FKCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaccinationSchedules");

            migrationBuilder.DropTable(
                name: "VaccineHistories");

            migrationBuilder.DropTable(
                name: "VaccinePackageDetails");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "VaccinePackages");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "ChildrenProfiles");

            migrationBuilder.DropTable(
                name: "VaccineBatches");

            migrationBuilder.DropTable(
                name: "VaccineCategories");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "VaccineCenters");
        }
    }
}
