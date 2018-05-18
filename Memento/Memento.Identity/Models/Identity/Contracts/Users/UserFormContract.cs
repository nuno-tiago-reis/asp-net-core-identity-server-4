using Memento.Identity.Models.Identity.Repositories.Users;
using Memento.Identity.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Memento.Identity.Models.Identity.Contracts.Users
{
	/// <summary>
	/// Implements the 'UserForm' contract.
	/// </summary>
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public sealed class UserFormContract
	{
		#region [Properties]
		/// <summary>
		/// The User's user name.
		/// </summary>
		[Required]
		[MaxLength(UserConfiguration.USERNAME_MAXIMUM_LENGTH)]
		[Display(Name = nameof(SharedResources.USER_USERNAME), ResourceType = typeof(SharedResources))]
		public string UserName { get; set; }

		/// <summary>
		/// The User's email.
		/// </summary>
		[Required]
		[MaxLength(UserConfiguration.EMAIL_MAXIMUM_LENGTH)]
		[Display(Name = nameof(SharedResources.USER_EMAIL), ResourceType = typeof(SharedResources))]
		public string Email { get; set; }

		/// <summary>
		/// The User's email confirmed flag.
		/// </summary>
		[Required]
		[Display(Name = nameof(SharedResources.USER_EMAILCONFIRMED), ResourceType = typeof(SharedResources))]
		public bool? EmailConfirmed { get; set; }

		/// <summary>
		/// The User's phone number.
		/// </summary>
		[Required]
		[MaxLength(UserConfiguration.PHONE_NUMBER_MAXIMUM_LENGTH)]
		[Display(Name = nameof(SharedResources.USER_PHONENUMBER), ResourceType = typeof(SharedResources))]
		public string PhoneNumber { get; set; }

		/// <summary>
		/// The User's phone number confirmed flag.
		/// </summary>
		[Required]
		[Display(Name = nameof(SharedResources.USER_PHONENUMBERCONFIRMED), ResourceType = typeof(SharedResources))]
		public bool? PhoneNumberConfirmed { get; set; }

		/// <summary>
		/// The User's two factor enabled flag.
		/// </summary>
		[Required]
		[Display(Name = nameof(SharedResources.USER_TWOFACTORENABLED), ResourceType = typeof(SharedResources))]
		public bool? TwoFactorEnabled { get; set; }

		/// <summary>
		/// The User's locked out end offset.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_LOCKOUTEND), ResourceType = typeof(SharedResources))]
		public DateTimeOffset? LockoutEnd { get; set; }

		/// <summary>
		/// The User's locked out enabled flag.
		/// </summary>
		[Required]
		[Display(Name = nameof(SharedResources.USER_LOCKOUTENABLED), ResourceType = typeof(SharedResources))]
		public bool? LockoutEnabled { get; set; }

		/// <summary>
		/// The User's access failed count.
		/// </summary>
		[Required]
		[Display(Name = nameof(SharedResources.USER_ACCESSFAILEDCOUNT), ResourceType = typeof(SharedResources))]
		public int? AccessFailedCount { get; set; }

		/// <summary>
		/// The User's enabled flag.
		/// </summary>
		[Required]
		[Display(Name = nameof(SharedResources.USER_ENABLED), ResourceType = typeof(SharedResources))]
		public bool? Enabled { get; set; }

		/// <summary>
		/// The User's claims
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_USERCLAIMS), ResourceType = typeof(SharedResources))]
		public ICollection<UserClaimFormContract> Claims { get; set; }

		/// <summary>
		/// The User's roles.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_USERROLES), ResourceType = typeof(SharedResources))]
		public ICollection<UserRoleFormContract> Roles { get; set; }
		#endregion
	}
}