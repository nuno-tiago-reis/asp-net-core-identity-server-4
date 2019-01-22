using Memento.Identity.Models.Identity.Repositories;
using Memento.Identity.Models.Identity.Repositories.Roles;
using Memento.Identity.Models.Identity.Repositories.Users;
using Memento.Shared.Models.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Memento.Identity.Models.Identity
{
	/// <summary>
	/// Implements the identity database context.
	/// </summary>
	///
	/// <seealso cref="IdentityDbContext"/>
	public sealed class IdentityContext : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IModelContext
	{
		#region [Constructors]
		/// <summary>
		/// Initializes a new instance of the <see cref="IdentityContext"/> class.
		/// </summary>
		/// 
		/// <param name="options">The options.</param>
		public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
		{
			// Nothing to do here.
		}
		#endregion

		#region [Methods]
		/// <inheritdoc />
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Configurations (Models)
			builder.ApplyConfiguration(new RoleConfiguration());
			builder.ApplyConfiguration(new UserConfiguration());

			// Configurations (Model Associations)
			builder.ApplyConfiguration(new RoleClaimConfiguration());
			builder.ApplyConfiguration(new UserClaimConfiguration());
			builder.ApplyConfiguration(new UserLoginConfiguration());
			builder.ApplyConfiguration(new UserRoleConfiguration());
			builder.ApplyConfiguration(new UserTokenConfiguration());
		}
		#endregion
	}
}