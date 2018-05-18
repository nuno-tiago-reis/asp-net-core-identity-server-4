using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Memento.Identity.Models.Identity.Repositories
{
	/// <summary>
	/// Implements the 'UserLogin' configurations.
	/// </summary>
	/// 
	/// <seealso cref="IEntityTypeConfiguration{UserLogin}" />
	public sealed class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
	{
		#region [Constants]
		/// <summary>
		/// The maximum length for the login provider column.
		/// </summary>
		public const int LOGIN_PROVIDER_MAXIMUM_LENGTH = 250;

		/// <summary>
		/// The maximum length for the provider key column.
		/// </summary>
		public const int PROVIDER_KEY_MAXIMUM_LENGTH = 250;

		/// <summary>
		/// The maximum length for the provider display name column.
		/// </summary>
		public const int PROVIDER_DISPLAY_NAME_MAXIMUM_LENGTH = 250;
		#endregion

		#region [Methods]
		/// <inheritdoc />
		public void Configure(EntityTypeBuilder<UserLogin> builder)
		{
			// Keys
			builder.HasKey(userLogin => new { userLogin.LoginProvider, userLogin.ProviderKey });

			// Indices
			builder.HasIndex(userLogin => userLogin.UserId);

			// Properties (UserLogin)
			builder.Property(userLogin => userLogin.LoginProvider).HasMaxLength(LOGIN_PROVIDER_MAXIMUM_LENGTH).IsRequired();
			builder.Property(userLogin => userLogin.ProviderKey).HasMaxLength(PROVIDER_KEY_MAXIMUM_LENGTH).IsRequired();
			builder.Property(userLogin => userLogin.ProviderDisplayName).HasMaxLength(PROVIDER_DISPLAY_NAME_MAXIMUM_LENGTH).IsRequired();

			// Properties (Model)
			builder.Property(userLogin => userLogin.CreatedBy).IsRequired();
			builder.Property(userLogin => userLogin.CreatedAt).IsRequired();
			builder.Property(userLogin => userLogin.UpdatedBy);
			builder.Property(userLogin => userLogin.UpdatedAt);

			// Relations
			builder
				.HasOne(userLogin => userLogin.User)
				.WithMany(user => user.UserLogins)
				.HasForeignKey(userLogin => userLogin.UserId)
				.OnDelete(DeleteBehavior.Cascade);
		}
		#endregion
	}
}