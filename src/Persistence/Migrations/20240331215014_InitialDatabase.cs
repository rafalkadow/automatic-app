using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AccountPassword = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AccountTypeId = table.Column<int>(type: "int", nullable: false),
                    AccountTypeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    OrderId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePictureDataUrl = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AffectedColumns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryOfParameterCategory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    OrderId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryOfParameterCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryOfParameterInterval",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    OrderId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryOfParameterInterval", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlcDriverGroup",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    OrderId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlcDriverGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlcDriver",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlcDriverGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeviceAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DevicePort = table.Column<int>(type: "int", nullable: false),
                    SlaveId = table.Column<int>(type: "int", nullable: false),
                    TimeOut = table.Column<int>(type: "int", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    OrderId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlcDriver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlcDriver_PlcDriverGroup_PlcDriverGroupId",
                        column: x => x.PlcDriverGroupId,
                        principalSchema: "dbo",
                        principalTable: "PlcDriverGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlcParameter",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlcDriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address = table.Column<int>(type: "int", nullable: false),
                    AccessModeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModbusTypeEnum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParameterType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModbusVisibility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordToDatabase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumValue = table.Column<int>(type: "int", nullable: false),
                    MaximumValue = table.Column<int>(type: "int", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    OrderId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlcParameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlcParameter_PlcDriver_PlcDriverId",
                        column: x => x.PlcDriverId,
                        principalSchema: "dbo",
                        principalTable: "PlcDriver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlcDriverAlarm",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlcDriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AlarmType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TriggerParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResetParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    OrderId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlcDriverAlarm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlcDriverAlarm_PlcDriver_PlcDriverId",
                        column: x => x.PlcDriverId,
                        principalSchema: "dbo",
                        principalTable: "PlcDriver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlcDriverAlarm_PlcParameter_ResetParameterId",
                        column: x => x.ResetParameterId,
                        principalSchema: "dbo",
                        principalTable: "PlcParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlcDriverAlarm_PlcParameter_TriggerParameterId",
                        column: x => x.TriggerParameterId,
                        principalSchema: "dbo",
                        principalTable: "PlcParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlcParameterHistory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlcParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    DateAddUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    OrderId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlcParameterHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlcParameterHistory_PlcParameter_PlcParameterId",
                        column: x => x.PlcParameterId,
                        principalSchema: "dbo",
                        principalTable: "PlcParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountEmail",
                schema: "dbo",
                table: "Account",
                column: "AccountEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_OrderId",
                schema: "dbo",
                table: "Account",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId1",
                table: "AspNetRoleClaims",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryOfParameterCategory_Name",
                schema: "dbo",
                table: "DictionaryOfParameterCategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryOfParameterCategory_OrderId",
                schema: "dbo",
                table: "DictionaryOfParameterCategory",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryOfParameterInterval_Name",
                schema: "dbo",
                table: "DictionaryOfParameterInterval",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryOfParameterInterval_OrderId",
                schema: "dbo",
                table: "DictionaryOfParameterInterval",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PlcDriver_Name",
                schema: "dbo",
                table: "PlcDriver",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlcDriver_OrderId",
                schema: "dbo",
                table: "PlcDriver",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PlcDriver_PlcDriverGroupId",
                schema: "dbo",
                table: "PlcDriver",
                column: "PlcDriverGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PlcDriverAlarm_Name",
                schema: "dbo",
                table: "PlcDriverAlarm",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlcDriverAlarm_OrderId",
                schema: "dbo",
                table: "PlcDriverAlarm",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PlcDriverAlarm_PlcDriverId",
                schema: "dbo",
                table: "PlcDriverAlarm",
                column: "PlcDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_PlcDriverAlarm_ResetParameterId",
                schema: "dbo",
                table: "PlcDriverAlarm",
                column: "ResetParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_PlcDriverAlarm_TriggerParameterId",
                schema: "dbo",
                table: "PlcDriverAlarm",
                column: "TriggerParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_PlcDriverGroup_Name",
                schema: "dbo",
                table: "PlcDriverGroup",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlcDriverGroup_OrderId",
                schema: "dbo",
                table: "PlcDriverGroup",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PlcParameter_Name",
                schema: "dbo",
                table: "PlcParameter",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlcParameter_OrderId",
                schema: "dbo",
                table: "PlcParameter",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PlcParameter_PlcDriverId",
                schema: "dbo",
                table: "PlcParameter",
                column: "PlcDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_PlcParameterHistory_OrderId",
                schema: "dbo",
                table: "PlcParameterHistory",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PlcParameterHistory_PlcParameterId",
                schema: "dbo",
                table: "PlcParameterHistory",
                column: "PlcParameterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "DictionaryOfParameterCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DictionaryOfParameterInterval",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlcDriverAlarm",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlcParameterHistory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PlcParameter",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlcDriver",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlcDriverGroup",
                schema: "dbo");
        }
    }
}
