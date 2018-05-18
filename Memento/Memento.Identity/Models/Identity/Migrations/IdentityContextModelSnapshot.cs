﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace Memento.Identity.Models.Identity.Migrations
{
	[DbContext(typeof(IdentityContext))]
	internal partial class IdentityContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
			#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "3.1.4")
				.HasAnnotation("Relational:MaxIdentifierLength", 128)
				.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

			modelBuilder.Entity("Memento.Identity.Models.Identity.Repositories.RoleClaim", b =>
			{
				b.Property<int>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("int")
					.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

				b.Property<string>("ClaimType")
					.IsRequired()
					.HasColumnType("nvarchar(100)")
					.HasMaxLength(100);

				b.Property<string>("ClaimValue")
					.ValueGeneratedOnAdd()
					.HasColumnType("nvarchar(100)")
					.HasMaxLength(100)
					.HasDefaultValue("");

				b.Property<DateTime>("CreatedAt")
					.HasColumnType("datetime2");

				b.Property<long>("CreatedBy")
					.HasColumnType("bigint");

				b.Property<long>("RoleId")
					.HasColumnType("bigint");

				b.Property<DateTime?>("UpdatedAt")
					.HasColumnType("datetime2");

				b.Property<long?>("UpdatedBy")
					.HasColumnType("bigint");

				b.HasKey("Id");

				b.HasIndex("RoleId");

				b.ToTable("AspNetRoleClaims");
			});

			modelBuilder.Entity("Memento.Identity.Models.Identity.Repositories.Roles.Role", b =>
			{
				b.Property<long>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint")
					.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

				b.Property<string>("ConcurrencyStamp")
					.IsConcurrencyToken()
					.HasColumnType("nvarchar(max)");

				b.Property<DateTime>("CreatedAt")
					.HasColumnType("datetime2");

				b.Property<long>("CreatedBy")
					.HasColumnType("bigint");

				b.Property<bool?>("Enabled")
					.IsRequired()
					.ValueGeneratedOnAdd()
					.HasColumnType("bit")
					.HasDefaultValue(true);

				b.Property<string>("Name")
					.IsRequired()
					.HasColumnType("nvarchar(250)")
					.HasMaxLength(250);

				b.Property<string>("NormalizedName")
					.IsRequired()
					.HasColumnType("nvarchar(250)")
					.HasMaxLength(250);

				b.Property<DateTime?>("UpdatedAt")
					.HasColumnType("datetime2");

				b.Property<long?>("UpdatedBy")
					.HasColumnType("bigint");

				b.HasKey("Id");

				b.HasIndex("Name")
					.IsUnique();

				b.HasIndex("NormalizedName")
					.IsUnique()
					.HasName("RoleNameIndex");

				b.ToTable("AspNetRoles");
			});

			modelBuilder.Entity("Memento.Identity.Models.Identity.Repositories.UserClaim", b =>
			{
				b.Property<int>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("int")
					.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

				b.Property<string>("ClaimType")
					.IsRequired()
					.HasColumnType("nvarchar(100)")
					.HasMaxLength(100);

				b.Property<string>("ClaimValue")
					.ValueGeneratedOnAdd()
					.HasColumnType("nvarchar(100)")
					.HasMaxLength(100)
					.HasDefaultValue("");

				b.Property<DateTime>("CreatedAt")
					.HasColumnType("datetime2");

				b.Property<long>("CreatedBy")
					.HasColumnType("bigint");

				b.Property<DateTime?>("UpdatedAt")
					.HasColumnType("datetime2");

				b.Property<long?>("UpdatedBy")
					.HasColumnType("bigint");

				b.Property<long>("UserId")
					.HasColumnType("bigint");

				b.HasKey("Id");

				b.HasIndex("UserId");

				b.ToTable("AspNetUserClaims");
			});

			modelBuilder.Entity("Memento.Identity.Models.Identity.Repositories.UserLogin", b =>
			{
				b.Property<string>("LoginProvider")
					.HasColumnType("nvarchar(250)")
					.HasMaxLength(250);

				b.Property<string>("ProviderKey")
					.HasColumnType("nvarchar(250)")
					.HasMaxLength(250);

				b.Property<DateTime>("CreatedAt")
					.HasColumnType("datetime2");

				b.Property<long>("CreatedBy")
					.HasColumnType("bigint");

				b.Property<string>("ProviderDisplayName")
					.IsRequired()
					.HasColumnType("nvarchar(250)")
					.HasMaxLength(250);

				b.Property<DateTime?>("UpdatedAt")
					.HasColumnType("datetime2");

				b.Property<long?>("UpdatedBy")
					.HasColumnType("bigint");

				b.Property<long>("UserId")
					.HasColumnType("bigint");

				b.HasKey("LoginProvider", "ProviderKey");

				b.HasIndex("UserId");

				b.ToTable("AspNetUserLogins");
			});

			modelBuilder.Entity("Memento.Identity.Models.Identity.Repositories.UserRole", b =>
			{
				b.Property<long>("UserId")
					.HasColumnType("bigint");

				b.Property<long>("RoleId")
					.HasColumnType("bigint");

				b.Property<DateTime>("CreatedAt")
					.HasColumnType("datetime2");

				b.Property<long>("CreatedBy")
					.HasColumnType("bigint");

				b.Property<DateTime?>("UpdatedAt")
					.HasColumnType("datetime2");

				b.Property<long?>("UpdatedBy")
					.HasColumnType("bigint");

				b.HasKey("UserId", "RoleId");

				b.HasIndex("RoleId");

				b.HasIndex("UserId");

				b.ToTable("AspNetUserRoles");
			});

			modelBuilder.Entity("Memento.Identity.Models.Identity.Repositories.UserToken", b =>
			{
				b.Property<long>("UserId")
					.HasColumnType("bigint");

				b.Property<string>("LoginProvider")
					.HasColumnType("nvarchar(250)")
					.HasMaxLength(250);

				b.Property<string>("Name")
					.HasColumnType("nvarchar(250)")
					.HasMaxLength(250);

				b.Property<DateTime>("CreatedAt")
					.HasColumnType("datetime2");

				b.Property<long>("CreatedBy")
					.HasColumnType("bigint");

				b.Property<DateTime?>("UpdatedAt")
					.HasColumnType("datetime2");

				b.Property<long?>("UpdatedBy")
					.HasColumnType("bigint");

				b.Property<string>("Value")
					.IsRequired()
					.HasColumnType("nvarchar(250)")
					.HasMaxLength(250);

				b.HasKey("UserId", "LoginProvider", "Name");

				b.HasIndex("UserId");

				b.ToTable("AspNetUserTokens");
			});

			modelBuilder.Entity("Memento.Identity.Models.Identity.Repositories.Users.User", b =>
			{
				b.Property<long>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint")
					.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

				b.Property<int>("AccessFailedCount")
					.ValueGeneratedOnAdd()
					.HasColumnType("int")
					.HasDefaultValue(0);

				b.Property<string>("ConcurrencyStamp")
					.IsConcurrencyToken()
					.HasColumnType("nvarchar(max)");

				b.Property<DateTime>("CreatedAt")
					.HasColumnType("datetime2");

				b.Property<long>("CreatedBy")
					.HasColumnType("bigint");

				b.Property<string>("Email")
					.IsRequired()
					.HasColumnType("nvarchar(255)")
					.HasMaxLength(255);

				b.Property<bool>("EmailConfirmed")
					.ValueGeneratedOnAdd()
					.HasColumnType("bit")
					.HasDefaultValue(false);

				b.Property<bool?>("Enabled")
					.IsRequired()
					.ValueGeneratedOnAdd()
					.HasColumnType("bit")
					.HasDefaultValue(true);

				b.Property<bool>("LockoutEnabled")
					.ValueGeneratedOnAdd()
					.HasColumnType("bit")
					.HasDefaultValue(false);

				b.Property<DateTimeOffset?>("LockoutEnd")
					.HasColumnType("datetimeoffset");

				b.Property<string>("NormalizedEmail")
					.IsRequired()
					.HasColumnType("nvarchar(255)")
					.HasMaxLength(255);

				b.Property<string>("NormalizedPhoneNumber")
					.HasColumnType("nvarchar(25)")
					.HasMaxLength(25);

				b.Property<string>("NormalizedUserName")
					.IsRequired()
					.HasColumnType("nvarchar(255)")
					.HasMaxLength(255);

				b.Property<string>("PasswordHash")
					.HasColumnType("nvarchar(max)");

				b.Property<string>("PhoneNumber")
					.HasColumnType("nvarchar(25)")
					.HasMaxLength(25);

				b.Property<bool>("PhoneNumberConfirmed")
					.ValueGeneratedOnAdd()
					.HasColumnType("bit")
					.HasDefaultValue(false);

				b.Property<string>("SecurityStamp")
					.HasColumnType("nvarchar(max)");

				b.Property<bool>("TwoFactorEnabled")
					.ValueGeneratedOnAdd()
					.HasColumnType("bit")
					.HasDefaultValue(false);

				b.Property<DateTime?>("UpdatedAt")
					.HasColumnType("datetime2");

				b.Property<long?>("UpdatedBy")
					.HasColumnType("bigint");

				b.Property<string>("UserName")
					.IsRequired()
					.HasColumnType("nvarchar(255)")
					.HasMaxLength(255);

				b.HasKey("Id");

				b.HasIndex("Email")
					.IsUnique();

				b.HasIndex("NormalizedEmail")
					.IsUnique()
					.HasName("EmailIndex");

				b.HasIndex("NormalizedPhoneNumber")
					.IsUnique()
					.HasFilter("[NormalizedPhoneNumber] IS NOT NULL");

				b.HasIndex("NormalizedUserName")
					.IsUnique()
					.HasName("UserNameIndex");

				b.HasIndex("PhoneNumber")
					.IsUnique()
					.HasFilter("[PhoneNumber] IS NOT NULL");

				b.HasIndex("UserName")
					.IsUnique();

				b.ToTable("AspNetUsers");
			});

			modelBuilder.Entity("Memento.Identity.Models.Identity.Repositories.RoleClaim", b =>
			{
				b.HasOne("Memento.Identity.Models.Identity.Repositories.Roles.Role", "Role")
					.WithMany("RoleClaims")
					.HasForeignKey("RoleId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
			});

			modelBuilder.Entity("Memento.Identity.Models.Identity.Repositories.UserClaim", b =>
			{
				b.HasOne("Memento.Identity.Models.Identity.Repositories.Users.User", "User")
					.WithMany("UserClaims")
					.HasForeignKey("UserId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
			});

			modelBuilder.Entity("Memento.Identity.Models.Identity.Repositories.UserLogin", b =>
			{
				b.HasOne("Memento.Identity.Models.Identity.Repositories.Users.User", "User")
					.WithMany("UserLogins")
					.HasForeignKey("UserId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
			});

			modelBuilder.Entity("Memento.Identity.Models.Identity.Repositories.UserRole", b =>
			{
				b.HasOne("Memento.Identity.Models.Identity.Repositories.Roles.Role", "Role")
					.WithMany("RoleUsers")
					.HasForeignKey("RoleId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.HasOne("Memento.Identity.Models.Identity.Repositories.Users.User", "User")
					.WithMany("UserRoles")
					.HasForeignKey("UserId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
			});

			modelBuilder.Entity("Memento.Identity.Models.Identity.Repositories.UserToken", b =>
			{
				b.HasOne("Memento.Identity.Models.Identity.Repositories.Users.User", "User")
					.WithMany("UserTokens")
					.HasForeignKey("UserId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
			});
			#pragma warning restore 612, 618
		}
	}
}