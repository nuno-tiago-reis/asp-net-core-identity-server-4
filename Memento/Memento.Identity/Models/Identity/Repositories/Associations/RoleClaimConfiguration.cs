using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Memento.Identity.Models.Identity.Repositories
{
	/// <summary>
	/// Implements the 'RoleClaim' configurations.
	/// </summary>
	/// 
	/// <seealso cref="IEntityTypeConfiguration{RoleClaim}" />
	public sealed class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
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
		public void Configure(EntityTypeBuilder<RoleClaim> builder)
		{
			// Keys
			builder.HasKey(roleClaim => roleClaim.Id);

			// Indices
			builder.HasIndex(roleClaim => roleClaim.RoleId);

			// Properties (RoleClaim)
			builder.Property(roleClaim => roleClaim.ClaimType).IsRequired().HasMaxLength(CLAIM_TYPE_MAXIMUM_LENGTH);
			builder.Property(roleClaim => roleClaim.ClaimValue).HasDefaultValue(string.Empty).HasMaxLength(CLAIM_VALUE_MAXIMUM_LENGTH);

			// Properties (Model)
			builder.Property(roleClaim => roleClaim.CreatedBy).IsRequired();
			builder.Property(roleClaim => roleClaim.CreatedAt).IsRequired();
			builder.Property(roleClaim => roleClaim.UpdatedBy);
			builder.Property(roleClaim => roleClaim.UpdatedAt);

			// Relationships
			builder
				.HasOne(roleClaim => roleClaim.Role)
				.WithMany(role => role.RoleClaims)
				.HasForeignKey(roleClaim => roleClaim.RoleId)
				.OnDelete(DeleteBehavior.Cascade);
		}
		#endregion
	}
}