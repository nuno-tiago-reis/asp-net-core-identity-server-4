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

namespace Memento.Identity.Models.Identity.Repositories.Users
{
	/// <summary>
	/// Implements the interface for a 'User' repository.
	/// Provides methods to interact with the users (CRUD and more).
	/// </summary>
	///
	/// <seealso cref="User" />
	/// <seealso cref="UserFilter" />
	/// <seealso cref="UserFilterOrderBy" />
	/// <seealso cref="UserFilterOrderDirection" />
	public sealed class UserRepository : ModelRepository<User, UserFilter, UserFilterOrderBy, UserFilterOrderDirection>, IUserRepository
	{
		#region [Constructors]
		/// <summary>
		/// Initializes a new instance of the <see cref="UserRepository"/> class.
		/// </summary>
		/// 
		/// <param name="context">The context</param>
		/// <param name="localizer">The localizer.</param>
		/// <param name="lookupNormalizer">The lookup normalizer.</param>
		/// <param name="logger">The logger.</param>
		public UserRepository
		(
			IdentityContext context,
			ILocalizerService localizer,
			ILookupNormalizer lookupNormalizer,
			ILogger<UserRepository> logger
		)
		: base(context, localizer, lookupNormalizer, logger)
		{
			// Nothing to do here.
		}
		#endregion

		#region [Methods] IModelRepository
		/// <inheritdoc />
		public override async Task<User> CreateAsync(User user)
		{
			return await base.CreateAsync(user);
		}

		/// <inheritdoc />
		public override async Task<User> UpdateAsync(User user)
		{
			return await base.UpdateAsync(user);
		}

		/// <inheritdoc />
		public override async Task DeleteAsync(long userId)
		{
			await base.DeleteAsync(userId);
		}

		/// <inheritdoc />
		public override async Task<User> GetAsync(long userId)
		{
			return await base.GetAsync(userId);
		}

		/// <inheritdoc />
		public override async Task<IPage<User>> GetAllAsync(UserFilter userFilter = null)
		{
			return await base.GetAllAsync(userFilter);
		}

		/// <inheritdoc />
		public override async Task<bool> ExistsAsync(long userId)
		{
			return await base.ExistsAsync(userId);
		}
		#endregion

		#region [Methods] IUserRepository
		#endregion

		#region [Methods] Model
		/// <inheritdoc />
		protected override void NormalizeModel(User sourceUser)
		{
			sourceUser.NormalizedUserName = this.LookupNormalizer.NormalizeName(sourceUser.UserName ?? string.Empty);
			sourceUser.NormalizedEmail = this.LookupNormalizer.NormalizeName(sourceUser.Email ?? string.Empty);
			sourceUser.NormalizedPhoneNumber = this.LookupNormalizer.NormalizeName(sourceUser.PhoneNumber ?? string.Empty);
		}

		/// <inheritdoc />
		protected override void ValidateModel(User sourceUser)
		{
			var errorMessages = new List<string>();

			// Required fields
			if (string.IsNullOrWhiteSpace(sourceUser.UserName))
			{
				errorMessages.Add(this.GetModelHasInvalidFieldMessage(user => user.UserName));
			}
			if (string.IsNullOrWhiteSpace(sourceUser.Email))
			{
				errorMessages.Add(this.GetModelHasInvalidFieldMessage(user => user.Email));
			}
			if (string.IsNullOrWhiteSpace(sourceUser.PhoneNumber))
			{
				errorMessages.Add(this.GetModelHasInvalidFieldMessage(user => user.PhoneNumber));
			}
			if (sourceUser.Enabled == default)
			{
				errorMessages.Add(this.GetModelHasInvalidFieldMessage(user => user.Enabled));
			}

			// Duplicate fields
			if (this.Models.Any(user => user.Id != sourceUser.Id && user.NormalizedUserName.Equals(sourceUser.NormalizedUserName)))
			{
				errorMessages.Add(this.GetModelHasDuplicateFieldMessage(user => user.UserName));
			}

			if (errorMessages.Count > 0)
			{
				throw new MementoException(errorMessages, MementoExceptionType.BadRequest);
			}
		}

		/// <inheritdoc />
		protected override void UpdateModel(User sourceUser, User targetUser)
		{
			// User
			targetUser.UserName = sourceUser.UserName;
			targetUser.NormalizedUserName = sourceUser.NormalizedUserName;
			targetUser.Email = sourceUser.Email;
			targetUser.NormalizedEmail = sourceUser.NormalizedEmail;
			targetUser.EmailConfirmed = sourceUser.EmailConfirmed;
			targetUser.PhoneNumber = sourceUser.PhoneNumber;
			targetUser.NormalizedPhoneNumber = sourceUser.NormalizedPhoneNumber;
			targetUser.PhoneNumberConfirmed = sourceUser.PhoneNumberConfirmed;
			targetUser.TwoFactorEnabled = sourceUser.TwoFactorEnabled;
			targetUser.LockoutEnabled = sourceUser.LockoutEnabled;
			targetUser.Enabled = sourceUser.Enabled;

			// Model
			targetUser.CreatedAt = sourceUser.CreatedAt;
			targetUser.CreatedBy = sourceUser.CreatedBy;
			targetUser.UpdatedAt = sourceUser.UpdatedAt;
			targetUser.UpdatedBy = sourceUser.UpdatedBy;
		}

		/// <inheritdoc />
		protected override void UpdateModelRelations(User sourceUser, User targetUser)
		{
			// Check which roles need to be added
			if (sourceUser.UserRoles != null)
			{
				// Clear duplicates
				sourceUser.UserRoles = sourceUser.UserRoles
					.GroupBy(role => new { role.RoleId }, (key, roles) => roles.FirstOrDefault())
					.ToList();

				// Cross check the source with the target
				foreach (var sourceRole in sourceUser.UserRoles)
				{
					if (targetUser.UserRoles == null || targetUser.UserRoles.All(role => role.RoleId != sourceRole.RoleId))
					{
						// Make sure the link is there
						sourceRole.UserId = targetUser.Id;

						// Add the connection to the context
						this.Context.Add(sourceRole);
						continue;
					}
				}
			}

			// Check which roles need to be removed
			if (targetUser.UserRoles != null)
			{
				// Cross check the source with the target
				foreach (var targetRole in targetUser.UserRoles)
				{
					if (sourceUser.UserRoles == null || sourceUser.UserRoles.All(role => role.RoleId != targetRole.RoleId))
					{
						// Remove the connection from the context
						this.Context.Remove(targetRole);
						continue;
					}
				}
			}

			// Update the claims
			targetUser.UserClaims = sourceUser.UserClaims;
		}
		#endregion

		#region [Methods] Queryable
		/// <inheritdoc />
		protected override IQueryable<User> GetCountQueryable()
		{
			return this.Models;
		}

		/// <inheritdoc />
		protected override IQueryable<User> GetSimpleQueryable()
		{
			return this.Models;
		}

		/// <inheritdoc />
		protected override IQueryable<User> GetDetailedQueryable()
		{
			return this.Models
				.Include(user => user.UserClaims)
				.Include(user => user.UserLogins)
				.Include(user => user.UserTokens)
				.Include(user => user.UserRoles)
				.ThenInclude(userMovies => userMovies.Role);
		}

		/// <inheritdoc />
		protected override IQueryable<User> FilterQueryable(IQueryable<User> userQueryable, UserFilter userFilter)
		{
			// Apply the filter
			if (string.IsNullOrWhiteSpace(userFilter.UserName) == false)
			{
				var userName = this.LookupNormalizer.NormalizeName(userFilter.UserName);

				userQueryable = userQueryable.Where(user => EF.Functions.Like(user.UserName, $"%{userName}%"));
			}

			if (string.IsNullOrWhiteSpace(userFilter.Email) == false)
			{
				var email = this.LookupNormalizer.NormalizeName(userFilter.Email);

				userQueryable = userQueryable.Where(user => EF.Functions.Like(user.Email, $"%{email}%"));
			}

			if (string.IsNullOrWhiteSpace(userFilter.PhoneNumber) == false)
			{
				var phoneNumber = this.LookupNormalizer.NormalizeName(userFilter.PhoneNumber);

				userQueryable = userQueryable.Where(user => EF.Functions.Like(user.PhoneNumber, $"%{phoneNumber}%"));
			}

			if (userFilter.Enabled != null)
			{
				switch (userFilter.Enabled)
				{
					case UserFilterEnabled.Checked:
					{
						userQueryable = userQueryable.Where(user => user.Enabled == true);
						break;
					}

					case UserFilterEnabled.Unchecked:
					{
						userQueryable = userQueryable.Where(user => user.Enabled == false);
						break;
					}
				}
			}

			// Apply the order
			switch (userFilter.OrderBy)
			{
				case UserFilterOrderBy.Id:
				{
					userQueryable = this.OrderQueryable(userQueryable, userFilter, user => user.Id);
					break;
				}

				case UserFilterOrderBy.UserName:
				{
					userQueryable = this.OrderQueryable(userQueryable, userFilter, user => user.UserName);
					break;
				}

				case UserFilterOrderBy.CreatedAt:
				{
					userQueryable = this.OrderQueryable(userQueryable, userFilter, user => user.CreatedAt);
					break;
				}

				case UserFilterOrderBy.UpdatedAt:
				{
					userQueryable = this.OrderQueryable(userQueryable, userFilter, user => user.UpdatedAt);
					break;
				}

				default:
				{
					throw new ArgumentOutOfRangeException(nameof(userFilter.OrderBy));
				}
			}

			return userQueryable;
		}

		/// <summary>
		/// Returns an ordered queryable according to the filters OrderDirection and expressions Property.
		/// </summary>
		///
		/// <typeparam name="TProperty">The property's type.</typeparam>
		///
		/// <param name="userQueryable">The user queryable.</param>
		/// <param name="userFilter">The user filter.</param>
		/// <param name="userExpression">The user expression</param>
		private IQueryable<User> OrderQueryable<TProperty>(IQueryable<User> userQueryable, UserFilter userFilter, Expression<Func<User, TProperty>> userExpression)
		{
			switch (userFilter.OrderDirection)
			{
				case UserFilterOrderDirection.Ascending:
				{
					return userQueryable.OrderBy(userExpression);
				}
				case UserFilterOrderDirection.Descending:
				{
					return userQueryable.OrderByDescending(userExpression);
				}
				default:
				{
					throw new ArgumentOutOfRangeException(nameof(userFilter.OrderDirection));
				}
			}
		}
		#endregion

		#region [Methods] Messages
		/// <inheritdoc />
		protected override string GetModelDoesNotExistMessage()
		{
			// Get the name
			var name = this.Localizer.GetString(SharedResources.USER);

			return this.Localizer.GetString(SharedResources.ERROR_NOT_FOUND, name);
		}

		/// <inheritdoc />
		protected override string GetModelHasDuplicateFieldMessage<TProperty>(Expression<Func<User, TProperty>> expression)
		{
			// Get the name
			var name = expression.GetDisplayName();

			return this.Localizer.GetString(SharedResources.ERROR_DUPLICATE_FIELD, name);
		}

		/// <inheritdoc />
		protected override string GetModelHasInvalidFieldMessage<TProperty>(Expression<Func<User, TProperty>> expression)
		{
			// Get the name
			var name = expression.GetDisplayName();

			return this.Localizer.GetString(SharedResources.ERROR_INVALID_FIELD, name);
		}
		#endregion
	}
}