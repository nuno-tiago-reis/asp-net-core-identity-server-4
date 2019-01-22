using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Memento.Identity.Models.Identity.Repositories.Roles
{
	/// <summary>
	/// Implements the 'Role' configurations.
	/// </summary>
	/// 
	/// <seealso cref="IEntityTypeConfiguration{User}" />
	public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
	{
		#region [Constants]
		/// <summary>
		/// The maximum length for the name column.
		/// </summary>
		public const int NAME_MAXIMUM_LENGTH = 250;
		#endregion

		#region [Methods]
		/// <inheritdoc />
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			// Keys
			builder.HasKey(role => role.Id);

			// Indices
			builder.HasIndex(role => role.Name).IsUnique();
			builder.HasIndex(role => role.NormalizedName).IsUnique();

			// Properties (Role)
			builder.Property(role => role.Name).IsRequired().HasMaxLength(NAME_MAXIMUM_LENGTH);
			builder.Property(role => role.NormalizedName).IsRequired().HasMaxLength(NAME_MAXIMUM_LENGTH);
			builder.Property(role => role.ConcurrencyStamp);
			builder.Property(role => role.Enabled).IsRequired().HasDefaultValue(true);

			// Properties (Model)
			builder.Property(role => role.CreatedBy).IsRequired();
			builder.Property(role => role.CreatedAt).IsRequired();
			builder.Property(role => role.UpdatedBy);
			builder.Property(role => role.UpdatedAt);
		}
		#endregion
	}
}