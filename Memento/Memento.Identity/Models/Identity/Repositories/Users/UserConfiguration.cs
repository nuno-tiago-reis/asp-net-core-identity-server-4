using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Memento.Identity.Models.Identity.Repositories.Users
{
	/// <summary>
	/// Implements the 'User' configurations.
	/// </summary>
	/// 
	/// <seealso cref="IEntityTypeConfiguration{User}" />
	public sealed class UserConfiguration : IEntityTypeConfiguration<User>
	{
		#region [Constants]
		/// <summary>
		/// The maximum length for the username column.
		/// </summary>
		public const int USERNAME_MAXIMUM_LENGTH = 255;

		/// <summary>
		/// The maximum length for the email column.
		/// </summary>
		public const int EMAIL_MAXIMUM_LENGTH = 255;

		/// <summary>
		/// The maximum length for the phone number column.
		/// </summary>
		public const int PHONE_NUMBER_MAXIMUM_LENGTH = 25;
		#endregion

		#region [Methods]
		/// <inheritdoc />
		public void Configure(EntityTypeBuilder<User> builder)
		{
			// Keys
			builder.HasKey(user => user.Id);

			// Indices
			builder.HasIndex(user => user.UserName).IsUnique();
			builder.HasIndex(user => user.NormalizedUserName).IsUnique();
			builder.HasIndex(user => user.Email).IsUnique();
			builder.HasIndex(user => user.NormalizedEmail).IsUnique();
			builder.HasIndex(user => user.PhoneNumber).IsUnique();
			builder.HasIndex(user => user.NormalizedPhoneNumber).IsUnique();

			// Properties (User)
			builder.Property(user => user.UserName).IsRequired().HasMaxLength(USERNAME_MAXIMUM_LENGTH);
			builder.Property(user => user.NormalizedUserName).IsRequired().HasMaxLength(USERNAME_MAXIMUM_LENGTH);
			builder.Property(user => user.Email).IsRequired().HasMaxLength(EMAIL_MAXIMUM_LENGTH);
			builder.Property(user => user.NormalizedEmail).IsRequired().HasMaxLength(EMAIL_MAXIMUM_LENGTH);
			builder.Property(user => user.EmailConfirmed).IsRequired().HasDefaultValue(false);
			builder.Property(user => user.PhoneNumber).HasMaxLength(PHONE_NUMBER_MAXIMUM_LENGTH);
			builder.Property(user => user.NormalizedPhoneNumber).HasMaxLength(PHONE_NUMBER_MAXIMUM_LENGTH);
			builder.Property(user => user.PhoneNumberConfirmed).IsRequired().HasDefaultValue(false);
			builder.Property(user => user.ConcurrencyStamp);
			builder.Property(user => user.PasswordHash);
			builder.Property(user => user.SecurityStamp);
			builder.Property(user => user.TwoFactorEnabled).IsRequired().HasDefaultValue(false);
			builder.Property(user => user.LockoutEnd);
			builder.Property(user => user.LockoutEnabled).IsRequired().HasDefaultValue(false);
			builder.Property(user => user.AccessFailedCount).IsRequired().HasDefaultValue(0);
			builder.Property(user => user.Enabled).IsRequired().HasDefaultValue(true);

			// Properties (Model)
			builder.Property(user => user.CreatedBy).IsRequired();
			builder.Property(user => user.CreatedAt).IsRequired();
			builder.Property(user => user.UpdatedBy);
			builder.Property(user => user.UpdatedAt);
		}
		#endregion
	}
}