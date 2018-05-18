using Memento.Identity.Models.Identity.Repositories.Users;
using Memento.Identity.Resources;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Memento.Identity.Models.Identity.Repositories
{
	/// <summary>
	/// Implements the 'UserClaim' model.
	/// </summary>
	public sealed class UserClaim : IdentityUserClaim<long>
	{
		#region [Properties]
		/// <summary>
		/// The identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERCLAIM_ID), ResourceType = typeof(SharedResources))]
		public override int Id { get; set; }

		/// <summary>
		/// The claim type.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERCLAIM_CLAIMTYPE), ResourceType = typeof(SharedResources))]
		public override string ClaimType { get; set; }

		/// <summary>
		/// The claim value.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERCLAIM_CLAIMVALUE), ResourceType = typeof(SharedResources))]
		public override string ClaimValue { get; set; }

		/// <summary>
		/// The user.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERCLAIM_USER), ResourceType = typeof(SharedResources))]
		public User User { get; set; }

		/// <summary>
		/// The user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERCLAIM_USERID), ResourceType = typeof(SharedResources))]
		public override long UserId { get; set; }

		/// <summary>
		/// The created by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERCLAIM_CREATEDBY), ResourceType = typeof(SharedResources))]
		public long CreatedBy { get; set; }

		/// <summary>
		/// The created at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERCLAIM_CREATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// The updated by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERCLAIM_UPDATEDBY), ResourceType = typeof(SharedResources))]
		public long? UpdatedBy { get; set; }

		/// <summary>
		/// The updated at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERCLAIM_UPDATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime? UpdatedAt { get; set; }
		#endregion
	}
}