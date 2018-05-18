using Memento.Identity.Resources;
using Memento.Shared.Models.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Memento.Identity.Models.Identity.Repositories.Users
{
	/// <summary>
	/// Implements the 'User' model.
	/// </summary>
	public sealed class User : IdentityUser<long>, IModel
	{
		#region [Properties]
		/// <summary>
		/// The identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_ID), ResourceType = typeof(SharedResources))]
		public override long Id { get; set; }

		/// <summary>
		/// The name.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_USERNAME), ResourceType = typeof(SharedResources))]
		public override string UserName { get; set; }

		/// <summary>
		/// The normalized user name.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_USERNAME), ResourceType = typeof(SharedResources))]
		public override string NormalizedUserName { get; set; }

		/// <summary>
		/// The email.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_EMAIL), ResourceType = typeof(SharedResources))]
		public override string Email { get; set; }

		/// <summary>
		/// The normalized email.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_EMAIL), ResourceType = typeof(SharedResources))]
		public override string NormalizedEmail { get; set; }

		/// <summary>
		/// The email confirmed.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_EMAILCONFIRMED), ResourceType = typeof(SharedResources))]
		public override bool EmailConfirmed { get; set; }

		/// <summary>
		/// The phone number.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_PHONENUMBER), ResourceType = typeof(SharedResources))]
		public override string PhoneNumber { get; set; }

		/// <summary>
		/// The normalized phone number.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_PHONENUMBER), ResourceType = typeof(SharedResources))]
		public string NormalizedPhoneNumber { get; set; }

		/// <summary>
		/// The phone number confirmed.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_PHONENUMBERCONFIRMED), ResourceType = typeof(SharedResources))]
		public override bool PhoneNumberConfirmed { get; set; }

		/// <summary>
		/// The concurrency stamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_CONCURRENCYSTAMP), ResourceType = typeof(SharedResources))]
		public override string ConcurrencyStamp { get; set; }

		/// <summary>
		/// The password hash.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_PASSWORDHASH), ResourceType = typeof(SharedResources))]
		public override string PasswordHash { get; set; }

		/// <summary>
		/// The security stamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_SECURITYSTAMP), ResourceType = typeof(SharedResources))]
		public override string SecurityStamp { get; set; }

		/// <summary>
		/// The two factor enabled flag.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_TWOFACTORENABLED), ResourceType = typeof(SharedResources))]
		public override bool TwoFactorEnabled { get; set; }

		/// <summary>
		/// The locked out end offset.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_LOCKOUTEND), ResourceType = typeof(SharedResources))]
		public override DateTimeOffset? LockoutEnd { get; set; }

		/// <summary>
		/// The locked out enabled flag.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_LOCKOUTENABLED), ResourceType = typeof(SharedResources))]
		public override bool LockoutEnabled { get; set; }

		/// <summary>
		/// The access failed count.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_ACCESSFAILEDCOUNT), ResourceType = typeof(SharedResources))]
		public override int AccessFailedCount { get; set; }

		/// <summary>
		/// The enabled flag.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_ENABLED), ResourceType = typeof(SharedResources))]
		public bool? Enabled { get; set; }

		/// <summary>
		/// The user claims
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_USERCLAIMS), ResourceType = typeof(SharedResources))]
		public List<UserClaim> UserClaims { get; set; }

		/// <summary>
		/// The user logins
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_USERLOGINS), ResourceType = typeof(SharedResources))]
		public List<UserLogin> UserLogins { get; set; }

		/// <summary>
		/// The user roles.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_USERROLES), ResourceType = typeof(SharedResources))]
		public List<UserRole> UserRoles { get; set; }

		/// <summary>
		/// The user tokens.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_USERTOKENS), ResourceType = typeof(SharedResources))]
		public List<UserToken> UserTokens { get; set; }

		/// <summary>
		/// The created by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_CREATEDBY), ResourceType = typeof(SharedResources))]
		public long CreatedBy { get; set; }

		/// <summary>
		/// The created at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_CREATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// The updated by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_UPDATEDBY), ResourceType = typeof(SharedResources))]
		public long? UpdatedBy { get; set; }

		/// <summary>
		/// The updated at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_UPDATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime? UpdatedAt { get; set; }
		#endregion

		#region [Methods]
		/// <inheritdoc />
		public override bool Equals(object @object)
		{
			if (@object is User user)
			{
				return this.Id == user.Id;
			}
			return false;
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			return HashCode.Combine(this.Id);
		}
		#endregion
	}
}