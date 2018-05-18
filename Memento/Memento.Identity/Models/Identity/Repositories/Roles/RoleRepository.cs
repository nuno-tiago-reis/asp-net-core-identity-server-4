using Memento.Identity.Resources;
using Memento.Shared.Exceptions;
using Memento.Shared.Extensions;
using Memento.Shared.Models.Pagination;
using Memento.Shared.Models.Repositories;
using Memento.Shared.Services.Localization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Memento.Identity.Models.Identity.Repositories.Roles
{
	/// <summary>
	/// Implements the interface for a 'Role' repository.
	/// Provides methods to interact with the users (CRUD and more).
	/// </summary>
	///
	/// <seealso cref="Role" />
	/// <seealso cref="RoleFilter" />
	/// <seealso cref="RoleFilterOrderBy" />
	/// <seealso cref="RoleFilterOrderDirection" />
	public sealed class RoleRepository : ModelRepository<Role, RoleFilter, RoleFilterOrderBy, RoleFilterOrderDirection>, IRoleRepository
	{
		#region [Constructors]
		/// <summary>
		/// Initializes a new instance of the <see cref="RoleRepository"/> class.
		/// </summary>
		/// 
		/// <param name="context">The context</param>
		/// <param name="localizer">The localizer.</param>
		/// <param name="lookupNormalizer">The lookup normalizer.</param>
		/// <param name="logger">The logger.</param>
		public RoleRepository
		(
			IdentityContext context,
			ILocalizerService localizer,
			ILookupNormalizer lookupNormalizer,
			ILogger<RoleRepository> logger
		)
		: base(context, localizer, lookupNormalizer, logger)
		{
			// Nothing to do here.
		}
		#endregion

		#region [Methods] IModelRepository
		/// <inheritdoc />
		public override async Task<Role> CreateAsync(Role user)
		{
			return await base.CreateAsync(user);
		}

		/// <inheritdoc />
		public override async Task<Role> UpdateAsync(Role user)
		{
			return await base.UpdateAsync(user);
		}

		/// <inheritdoc />
		public override async Task DeleteAsync(long userId)
		{
			await base.DeleteAsync(userId);
		}

		/// <inheritdoc />
		public override async Task<Role> GetAsync(long userId)
		{
			return await base.GetAsync(userId);
		}

		/// <inheritdoc />
		public override async Task<IPage<Role>> GetAllAsync(RoleFilter userFilter = null)
		{
			return await base.GetAllAsync(userFilter);
		}

		/// <inheritdoc />
		public override async Task<bool> ExistsAsync(long userId)
		{
			return await base.ExistsAsync(userId);
		}
		#endregion

		#region [Methods] IRoleRepository
		#endregion

		#region [Methods] Model
		/// <inheritdoc />
		protected override void NormalizeModel(Role sourceRole)
		{
			sourceRole.NormalizedName = this.LookupNormalizer.NormalizeName(sourceRole.Name ?? string.Empty);
		}

		/// <inheritdoc />
		protected override void ValidateModel(Role sourceRole)
		{
			var errorMessages = new List<string>();

			// Required fields
			if (string.IsNullOrWhiteSpace(sourceRole.Name))
			{
				errorMessages.Add(this.GetModelHasInvalidFieldMessage(role => role.Name));
			}
			if (sourceRole.Enabled == default)
			{
				errorMessages.Add(this.GetModelHasInvalidFieldMessage(role => role.Enabled));
			}

			// Duplicate fields
			if (this.Models.Any(role => role.Id != sourceRole.Id && role.NormalizedName.Equals(sourceRole.NormalizedName)))
			{
				errorMessages.Add(this.GetModelHasDuplicateFieldMessage(role => role.Name));
			}

			if (errorMessages.Count > 0)
			{
				throw new MementoException(errorMessages, MementoExceptionType.BadRequest);
			}
		}

		/// <inheritdoc />
		protected override void UpdateModel(Role sourceRole, Role targetRole)
		{
			// Role
			targetRole.Name = sourceRole.Name;
			targetRole.NormalizedName = sourceRole.NormalizedName;
			targetRole.Enabled = sourceRole.Enabled;

			// Model
			targetRole.CreatedAt = sourceRole.CreatedAt;
			targetRole.CreatedBy = sourceRole.CreatedBy;
			targetRole.UpdatedAt = sourceRole.UpdatedAt;
			targetRole.UpdatedBy = sourceRole.UpdatedBy;
		}

		/// <inheritdoc />
		protected override void UpdateModelRelations(Role sourceRole, Role targetRole)
		{
			// Check which users need to be added
			if (sourceRole.RoleUsers != null)
			{
				// Clear duplicates
				sourceRole.RoleUsers = sourceRole.RoleUsers
					.GroupBy(user => new { user.UserId }, (key, users) => users.FirstOrDefault())
					.ToList();

				// Cross check the source with the target
				foreach (var sourceUser in sourceRole.RoleUsers)
				{
					if (targetRole.RoleUsers == null || targetRole.RoleUsers.All(user => user.UserId != sourceUser.UserId))
					{
						// Make sure the link is there
						sourceUser.RoleId = targetRole.Id;

						// Add the connection to the context
						this.Context.Add(sourceUser);
						continue;
					}
				}
			}

			// Check which users need to be removed
			if (targetRole.RoleUsers != null)
			{
				// Cross check the source with the target
				foreach (var targetUser in targetRole.RoleUsers)
				{
					if (sourceRole.RoleUsers == null || sourceRole.RoleUsers.All(user => user.UserId != targetUser.UserId))
					{
						// Remove the connection from the context
						this.Context.Remove(targetUser);
						continue;
					}
				}
			}

			// Update the claims
			targetRole.RoleClaims = sourceRole.RoleClaims;
		}
		#endregion

		#region [Methods] Queryable
		/// <inheritdoc />
		protected override IQueryable<Role> GetCountQueryable()
		{
			return this.Models;
		}

		/// <inheritdoc />
		protected override IQueryable<Role> GetSimpleQueryable()
		{
			return this.Models;
		}

		/// <inheritdoc />
		protected override IQueryable<Role> GetDetailedQueryable()
		{
			return this.Models
				.Include(user => user.RoleClaims)
				.Include(user => user.RoleUsers)
				.ThenInclude(userMovies => userMovies.User);
		}

		/// <inheritdoc />
		protected override IQueryable<Role> FilterQueryable(IQueryable<Role> roleQueryable, RoleFilter roleFilter)
		{
			// Apply the filter
			if (string.IsNullOrWhiteSpace(roleFilter.Name) == false)
			{
				var name = this.LookupNormalizer.NormalizeName(roleFilter.Name);

				roleQueryable = roleQueryable.Where(user => EF.Functions.Like(user.Name, $"%{name}%"));
			}

			if (roleFilter.Enabled != null)
			{
				switch (roleFilter.Enabled)
				{
					case RoleFilterEnabled.Checked:
					{
						roleQueryable = roleQueryable.Where(role => role.Enabled == true);
						break;
					}

					case RoleFilterEnabled.Unchecked:
					{
						roleQueryable = roleQueryable.Where(role => role.Enabled == false);
						break;
					}
				}
			}

			// Apply the order
			switch (roleFilter.OrderBy)
			{
				case RoleFilterOrderBy.Id:
				{
					roleQueryable = this.OrderQueryable(roleQueryable, roleFilter, role => role.Id);
					break;
				}

				case RoleFilterOrderBy.Name:
				{
					roleQueryable = this.OrderQueryable(roleQueryable, roleFilter, role => role.Name);
					break;
				}

				case RoleFilterOrderBy.CreatedAt:
				{
					roleQueryable = this.OrderQueryable(roleQueryable, roleFilter, role => role.CreatedAt);
					break;
				}

				case RoleFilterOrderBy.UpdatedAt:
				{
					roleQueryable = this.OrderQueryable(roleQueryable, roleFilter, role => role.UpdatedAt);
					break;
				}

				default:
				{
					throw new ArgumentOutOfRangeException(nameof(roleFilter.OrderBy));
				}
			}

			return roleQueryable;
		}

		/// <summary>
		/// Returns an ordered queryable according to the filters OrderDirection and expressions Property.
		/// </summary>
		///
		/// <typeparam name="TProperty">The property's type.</typeparam>
		///
		/// <param name="roleQueryable">The role queryable.</param>
		/// <param name="roleFilter">The role filter.</param>
		/// <param name="roleExpression">The role expression</param>
		private IQueryable<Role> OrderQueryable<TProperty>(IQueryable<Role> roleQueryable, RoleFilter roleFilter, Expression<Func<Role, TProperty>> roleExpression)
		{
			switch (roleFilter.OrderDirection)
			{
				case RoleFilterOrderDirection.Ascending:
				{
					return roleQueryable.OrderBy(roleExpression);
				}
				case RoleFilterOrderDirection.Descending:
				{
					return roleQueryable.OrderByDescending(roleExpression);
				}
				default:
				{
					throw new ArgumentOutOfRangeException(nameof(roleFilter.OrderDirection));
				}
			}
		}
		#endregion

		#region [Methods] Messages
		/// <inheritdoc />
		protected override string GetModelDoesNotExistMessage()
		{
			// Get the name
			var name = this.Localizer.GetString(SharedResources.ROLE);

			return this.Localizer.GetString(SharedResources.ERROR_NOT_FOUND, name);
		}

		/// <inheritdoc />
		protected override string GetModelHasDuplicateFieldMessage<TProperty>(Expression<Func<Role, TProperty>> expression)
		{
			// Get the name
			var name = expression.GetDisplayName();

			return this.Localizer.GetString(SharedResources.ERROR_DUPLICATE_FIELD, name);
		}

		/// <inheritdoc />
		protected override string GetModelHasInvalidFieldMessage<TProperty>(Expression<Func<Role, TProperty>> expression)
		{
			// Get the name
			var name = expression.GetDisplayName();

			return this.Localizer.GetString(SharedResources.ERROR_INVALID_FIELD, name);
		}
		#endregion
	}
}