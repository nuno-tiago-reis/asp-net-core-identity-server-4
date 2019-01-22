using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Memento.Identity.Models.Identity.Repositories
{
	/// <summary>
	/// Implements the 'UserClaim' configurations.
	/// </summary>
	/// 
	/// <seealso cref="IEntityTypeConfiguration{UserClaim}" />
	public sealed class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
	{
		#region [Constants]
		/// <summary>
		/// The maximum length for the claim type column.
		/// </summary>
		public const int CLAIM_TYPE_MAXIMUM_LENGTH = 100;

		/// <summary>
		/// The maximum length for the claim value column.
		/// </summary>
		public const int CLAIM_VALUE_MAXIMUM_LENGTH = 100;
		#endregion

		#region [Methods]
		/// <inheritdoc />
		public void Configure(EntityTypeBuilder<UserClaim> builder)
		{
			// Keys
			builder.HasKey(userClaim => userClaim.Id);

			// Indices
			builder.HasIndex(userClaim => userClaim.UserId);

			// Properties (UserClaim)
			builder.Property(userClaim => userClaim.ClaimType).IsRequired().HasMaxLength(CLAIM_TYPE_MAXIMUM_LENGTH);
			builder.Property(userClaim => userClaim.ClaimValue).HasDefaultValue(string.Empty).HasMaxLength(CLAIM_VALUE_MAXIMUM_LENGTH);

			// Properties (Model)
			builder.Property(userClaim => userClaim.CreatedBy).IsRequired();
			builder.Property(userClaim => userClaim.CreatedAt).IsRequired();
			builder.Property(userClaim => userClaim.UpdatedBy);
			builder.Property(userClaim => userClaim.UpdatedAt);

			// Relationships
			builder
				.HasOne(userClaim => userClaim.User)
				.WithMany(user => user.UserClaims)
				.HasForeignKey(userClaim => userClaim.UserId)
				.OnDelete(DeleteBehavior.Cascade);
		}
		#endregion
	}
}