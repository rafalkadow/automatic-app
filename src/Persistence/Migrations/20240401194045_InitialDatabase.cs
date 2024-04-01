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

            migrationBuilder.EnsureSchema(
                name: "Identity");

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
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                name: "Roles",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePictureDataUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    OrderId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                name: "RoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
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
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                name: "PlcParameterHistory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlcParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    DateAddUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "RoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "PlcParameter",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "PlcDriver",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlcDriverGroup",
                schema: "dbo");
        }
    }
}
