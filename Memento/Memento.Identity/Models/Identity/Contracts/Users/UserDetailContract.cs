using Memento.Identity.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Memento.Identity.Models.Identity.Contracts.Users
{
	/// <summary>
	/// Implements the 'UserDetail' contract.
	/// </summary>
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public sealed class UserDetailContract
	{
		#region [Properties]
		/// <summary>
		/// The User's identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_ID), ResourceType = typeof(SharedResources))]
		public long Id { get; set; }

		/// <summary>
		/// The User's user name.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_USERNAME), ResourceType = typeof(SharedResources))]
		public string UserName { get; set; }

		/// <summary>
		/// The User's email.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_EMAIL), ResourceType = typeof(SharedResources))]
		public string Email { get; set; }

		/// <summary>
		/// The User's email confirmed flag.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_EMAILCONFIRMED), ResourceType = typeof(SharedResources))]
		public bool EmailConfirmed { get; set; }

		/// <summary>
		/// The User's phone number.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_PHONENUMBER), ResourceType = typeof(SharedResources))]
		public string PhoneNumber { get; set; }

		/// <summary>
		/// The User's phone number confirmed flag.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_PHONENUMBERCONFIRMED), ResourceType = typeof(SharedResources))]
		public bool PhoneNumberConfirmed { get; set; }

		/// <summary>
		/// The User's two factor enabled flag.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_TWOFACTORENABLED), ResourceType = typeof(SharedResources))]
		public bool TwoFactorEnabled { get; set; }

		/// <summary>
		/// The User's locked out end offset.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_LOCKOUTEND), ResourceType = typeof(SharedResources))]
		public DateTimeOffset? LockoutEnd { get; set; }

		/// <summary>
		/// The User's locked out enabled flag.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_LOCKOUTENABLED), ResourceType = typeof(SharedResources))]
		public bool LockoutEnabled { get; set; }

		/// <summary>
		/// The User's access failed count.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_ACCESSFAILEDCOUNT), ResourceType = typeof(SharedResources))]
		public int AccessFailedCount { get; set; }

		/// <summary>
		/// The User's enabled flag.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_ENABLED), ResourceType = typeof(SharedResources))]
		public bool? Enabled { get; set; }

		/// <summary>
		/// The User's claims
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_USERCLAIMS), ResourceType = typeof(SharedResources))]
		public ICollection<UserClaimDetailContract> Claims { get; set; }

		/// <summary>
		/// The User's roles.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_USERROLES), ResourceType = typeof(SharedResources))]
		public ICollection<UserRoleDetailContract> Roles { get; set; }

		/// <summary>
		/// The User's created by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_CREATEDBY), ResourceType = typeof(SharedResources))]
		public long CreatedBy { get; set; }

		/// <summary>
		/// The User's created at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_CREATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// The User's updated by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_UPDATEDBY), ResourceType = typeof(SharedResources))]
		public long? UpdatedBy { get; set; }

		/// <summary>
		/// The User's updated at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_UPDATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime? UpdatedAt { get; set; }
		#endregion
	}
}