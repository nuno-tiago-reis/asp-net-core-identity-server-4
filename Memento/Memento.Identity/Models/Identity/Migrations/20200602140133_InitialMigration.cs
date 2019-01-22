using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Memento.Identity.Models.Identity.Migrations
{
	/// <summary>
	/// Implements an entity framework migration.
	/// </summary>
	/// 
	/// <seealso cref="Migration" />
	internal partial class InitialMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable
			(
				name: "AspNetRoles",
				columns: table => new
				{
					Id = table.Column<long>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(maxLength: 250, nullable: false),
					NormalizedName = table.Column<string>(maxLength: 250, nullable: false),
					ConcurrencyStamp = table.Column<string>(nullable: true),
					Enabled = table.Column<bool>(nullable: false, defaultValue: true),
					CreatedBy = table.Column<long>(nullable: false),
					CreatedAt = table.Column<DateTime>(nullable: false),
					UpdatedBy = table.Column<long>(nullable: true),
					UpdatedAt = table.Column<DateTime>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetRoles", x => x.Id);
				}
			);

			migrationBuilder.CreateTable
			(
				name: "AspNetUsers",
				columns: table => new
				{
					Id = table.Column<long>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserName = table.Column<string>(maxLength: 255, nullable: false),
					NormalizedUserName = table.Column<string>(maxLength: 255, nullable: false),
					Email = table.Column<string>(maxLength: 255, nullable: false),
					NormalizedEmail = table.Column<string>(maxLength: 255, nullable: false),
					EmailConfirmed = table.Column<bool>(nullable: false, defaultValue: false),
					PhoneNumber = table.Column<string>(maxLength: 25, nullable: true),
					NormalizedPhoneNumber = table.Column<string>(maxLength: 25, nullable: true),
					PhoneNumberConfirmed = table.Column<bool>(nullable: false, defaultValue: false),
					ConcurrencyStamp = table.Column<string>(nullable: true),
					PasswordHash = table.Column<string>(nullable: true),
					SecurityStamp = table.Column<string>(nullable: true),
					TwoFactorEnabled = table.Column<bool>(nullable: false, defaultValue: false),
					LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
					LockoutEnabled = table.Column<bool>(nullable: false, defaultValue: false),
					AccessFailedCount = table.Column<int>(nullable: false, defaultValue: 0),
					Enabled = table.Column<bool>(nullable: false, defaultValue: true),
					CreatedBy = table.Column<long>(nullable: false),
					CreatedAt = table.Column<DateTime>(nullable: false),
					UpdatedBy = table.Column<long>(nullable: true),
					UpdatedAt = table.Column<DateTime>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUsers", x => x.Id);
				}
			);

			migrationBuilder.CreateTable
			(
				name: "AspNetRoleClaims",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ClaimType = table.Column<string>(maxLength: 100, nullable: false),
					ClaimValue = table.Column<string>(maxLength: 100, nullable: true, defaultValue: ""),
					RoleId = table.Column<long>(nullable: false),
					CreatedBy = table.Column<long>(nullable: false),
					CreatedAt = table.Column<DateTime>(nullable: false),
					UpdatedBy = table.Column<long>(nullable: true),
					UpdatedAt = table.Column<DateTime>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
					table.ForeignKey
					(
						name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade
					);
				}
			);

			migrationBuilder.CreateTable
			(
				name: "AspNetUserClaims",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ClaimType = table.Column<string>(maxLength: 100, nullable: false),
					ClaimValue = table.Column<string>(maxLength: 100, nullable: true, defaultValue: ""),
					UserId = table.Column<long>(nullable: false),
					CreatedBy = table.Column<long>(nullable: false),
					CreatedAt = table.Column<DateTime>(nullable: false),
					UpdatedBy = table.Column<long>(nullable: true),
					UpdatedAt = table.Column<DateTime>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
					table.ForeignKey
					(
						name: "FK_AspNetUserClaims_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade
					);
				}
			);

			migrationBuilder.CreateTable
			(
				name: "AspNetUserLogins",
				columns: table => new
				{
					LoginProvider = table.Column<string>(maxLength: 250, nullable: false),
					ProviderKey = table.Column<string>(maxLength: 250, nullable: false),
					ProviderDisplayName = table.Column<string>(maxLength: 250, nullable: false),
					UserId = table.Column<long>(nullable: false),
					CreatedBy = table.Column<long>(nullable: false),
					CreatedAt = table.Column<DateTime>(nullable: false),
					UpdatedBy = table.Column<long>(nullable: true),
					UpdatedAt = table.Column<DateTime>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
					table.ForeignKey
					(
						name: "FK_AspNetUserLogins_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade
					);
				}
			);

			migrationBuilder.CreateTable
			(
				name: "AspNetUserRoles",
				columns: table => new
				{
					UserId = table.Column<long>(nullable: false),
					RoleId = table.Column<long>(nullable: false),
					CreatedBy = table.Column<long>(nullable: false),
					CreatedAt = table.Column<DateTime>(nullable: false),
					UpdatedBy = table.Column<long>(nullable: true),
					UpdatedAt = table.Column<DateTime>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
					table.ForeignKey
					(
						name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade
					);
					table.ForeignKey
					(
						name: "FK_AspNetUserRoles_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade
					);
				}
			);

			migrationBuilder.CreateTable
			(
				name: "AspNetUserTokens",
				columns: table => new
				{
					LoginProvider = table.Column<string>(maxLength: 250, nullable: false),
					Name = table.Column<string>(maxLength: 250, nullable: false),
					UserId = table.Column<long>(nullable: false),
					Value = table.Column<string>(maxLength: 250, nullable: false),
					CreatedBy = table.Column<long>(nullable: false),
					CreatedAt = table.Column<DateTime>(nullable: false),
					UpdatedBy = table.Column<long>(nullable: true),
					UpdatedAt = table.Column<DateTime>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
					table.ForeignKey
					(
						name: "FK_AspNetUserTokens_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade
					);
				}
			);

			migrationBuilder.CreateIndex
			(
				name: "IX_AspNetRoleClaims_RoleId",
				table: "AspNetRoleClaims",
				column: "RoleId"
			);

			migrationBuilder.CreateIndex
			(
				name: "IX_AspNetRoles_Name",
				table: "AspNetRoles",
				column: "Name",
				unique: true
			);

			migrationBuilder.CreateIndex
			(
				name: "RoleNameIndex",
				table: "AspNetRoles",
				column: "NormalizedName",
				unique: true
			);

			migrationBuilder.CreateIndex
			(
				name: "IX_AspNetUserClaims_UserId",
				table: "AspNetUserClaims",
				column: "UserId"
			);

			migrationBuilder.CreateIndex
			(
				name: "IX_AspNetUserLogins_UserId",
				table: "AspNetUserLogins",
				column: "UserId"
			);

			migrationBuilder.CreateIndex
			(
				name: "IX_AspNetUserRoles_RoleId",
				table: "AspNetUserRoles",
				column: "RoleId"
			);

			migrationBuilder.CreateIndex
			(
				name: "IX_AspNetUserRoles_UserId",
				table: "AspNetUserRoles",
				column: "UserId"
			);

			migrationBuilder.CreateIndex
			(
				name: "IX_AspNetUsers_Email",
				table: "AspNetUsers",
				column: "Email",
				unique: true
			);

			migrationBuilder.CreateIndex
			(
				name: "EmailIndex",
				table: "AspNetUsers",
				column: "NormalizedEmail",
				unique: true
			);

			migrationBuilder.CreateIndex
			(
				name: "IX_AspNetUsers_NormalizedPhoneNumber",
				table: "AspNetUsers",
				column: "NormalizedPhoneNumber",
				unique: true,
				filter: "[NormalizedPhoneNumber] IS NOT NULL"
			);

			migrationBuilder.CreateIndex
			(
				name: "UserNameIndex",
				table: "AspNetUsers",
				column: "NormalizedUserName",
				unique: true
			);

			migrationBuilder.CreateIndex
			(
				name: "IX_AspNetUsers_PhoneNumber",
				table: "AspNetUsers",
				column: "PhoneNumber",
				unique: true,
				filter: "[PhoneNumber] IS NOT NULL"
			);

			migrationBuilder.CreateIndex
			(
				name: "IX_AspNetUsers_UserName",
				table: "AspNetUsers",
				column: "UserName",
				unique: true
			);

			migrationBuilder.CreateIndex
			(
				name: "IX_AspNetUserTokens_UserId",
				table: "AspNetUserTokens",
				column: "UserId"
			);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable
			(
				name: "AspNetRoleClaims"
			);

			migrationBuilder.DropTable
			(
				name: "AspNetUserClaims"
			);

			migrationBuilder.DropTable
			(
				name: "AspNetUserLogins"
			);

			migrationBuilder.DropTable
			(
				name: "AspNetUserRoles"
			);

			migrationBuilder.DropTable
			(
				name: "AspNetUserTokens"
			);

			migrationBuilder.DropTable
			(
				name: "AspNetRoles"
			);

			migrationBuilder.DropTable
			(
				name: "AspNetUsers"
			);
		}
	}
}