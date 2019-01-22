using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Memento.Identity.Models.Identity.Repositories
{
	/// <summary>
	/// Implements the 'UserToken' configurations.
	/// </summary>
	/// 
	/// <seealso cref="IEntityTypeConfiguration{UserToken}" />
	public sealed class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
	{
		#region [Constants]
		/// <summary>
		/// The maximum length for the login provider column.
		/// </summary>
		public const int LOGIN_PROVIDER_MAXIMUM_LENGTH = 250;

		/// <summary>
		/// The maximum length for the name column.
		/// </summary>
		public const int NAME_MAXIMUM_LENGTH = 250;

		/// <summary>
		/// The maximum length for the value column.
		/// </summary>
		public const int VALUE_MAXIMUM_LENGTH = 250;
		#endregion

		#region [Methods]
		/// <inheritdoc />
		public void Configure(EntityTypeBuilder<UserToken> builder)
		{
			// Keys
			builder.HasKey(userToken => new { userToken.UserId, userToken.LoginProvider, userToken.Name });

			// Indices
			builder.HasIndex(userToken => userToken.UserId);

			// Properties (UserToken)
			builder.Property(userToken => userToken.LoginProvider).HasMaxLength(LOGIN_PROVIDER_MAXIMUM_LENGTH).IsRequired();
			builder.Property(userToken => userToken.Name).HasMaxLength(NAME_MAXIMUM_LENGTH).IsRequired();
			builder.Property(userToken => userToken.Value).HasMaxLength(VALUE_MAXIMUM_LENGTH).IsRequired();

			// Properties (Model)
			builder.Property(userToken => userToken.CreatedBy).IsRequired();
			builder.Property(userToken => userToken.CreatedAt).IsRequired();
			builder.Property(userToken => userToken.UpdatedBy);
			builder.Property(userToken => userToken.UpdatedAt);

			// Relations
			builder
				.HasOne(userToken => userToken.User)
				.WithMany(user => user.UserTokens)
				.HasForeignKey(userToken => userToken.UserId)
				.OnDelete(DeleteBehavior.Cascade);
		}
		#endregion
	}
}