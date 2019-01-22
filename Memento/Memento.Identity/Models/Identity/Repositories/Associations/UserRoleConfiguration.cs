using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Memento.Identity.Models.Identity.Repositories
{
	/// <summary>
	/// Implements the 'UserRole' configurations.
	/// </summary>
	/// 
	/// <seealso cref="IEntityTypeConfiguration{UserRole}" />
	public sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
	{
		#region [Methods]
		/// <inheritdoc />
		public void Configure(EntityTypeBuilder<UserRole> builder)
		{
			// Keys
			builder.HasKey(userRole => new { userRole.UserId, userRole.RoleId });

			// Indices
			builder.HasIndex(userRole => userRole.UserId);
			builder.HasIndex(userRole => userRole.RoleId);

			// Properties (UserRole)
			builder.Property(userRole => userRole.UserId).IsRequired();
			builder.Property(userRole => userRole.RoleId).IsRequired();

			// Properties (Model)
			builder.Property(userRole => userRole.CreatedBy).IsRequired();
			builder.Property(userRole => userRole.CreatedAt).IsRequired();
			builder.Property(userRole => userRole.UpdatedBy);
			builder.Property(userRole => userRole.UpdatedAt);

			// Relations
			builder
				.HasOne(userRole => userRole.User)
				.WithMany(user => user.UserRoles)
				.HasForeignKey(userRole => userRole.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			builder
				.HasOne(userRole => userRole.Role)
				.WithMany(user => user.RoleUsers)
				.HasForeignKey(userRole => userRole.RoleId)
				.OnDelete(DeleteBehavior.Cascade);
		}
		#endregion
	}
}