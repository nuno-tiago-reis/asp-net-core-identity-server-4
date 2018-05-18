using Memento.Identity.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Memento.Identity.Models.Identity.Contracts.Roles
{
	/// <summary>
	/// Implements the 'RoleUserList' contract.
	/// </summary>
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public sealed class RoleUserListContract
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
		#endregion
	}
}