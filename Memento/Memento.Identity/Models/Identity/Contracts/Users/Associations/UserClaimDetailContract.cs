using Memento.Identity.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Memento.Identity.Models.Identity.Contracts.Users
{
	/// <summary>
	/// Implements the 'UserClaimDetail' contract.
	/// </summary>
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public sealed class UserClaimDetailContract
	{
		#region [Properties]
		/// <summary>
		/// The UserClaim's identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERCLAIM_ID), ResourceType = typeof(SharedResources))]
		public int Id { get; set; }

		/// <summary>
		/// The UserClaim's claim type.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERCLAIM_CLAIMTYPE), ResourceType = typeof(SharedResources))]
		public string ClaimType { get; set; }

		/// <summary>
		/// The UserClaim's claim value.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERCLAIM_CLAIMVALUE), ResourceType = typeof(SharedResources))]
		public string ClaimValue { get; set; }

		/// <summary>
		/// The UserClaim's created by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERCLAIM_CREATEDBY), ResourceType = typeof(SharedResources))]
		public long CreatedBy { get; set; }

		/// <summary>
		/// The UserClaim's created at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERCLAIM_CREATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// The UserClaim's updated by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERCLAIM_UPDATEDBY), ResourceType = typeof(SharedResources))]
		public long? UpdatedBy { get; set; }

		/// <summary>
		/// The UserClaim's updated at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERCLAIM_UPDATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime? UpdatedAt { get; set; }
		#endregion
	}
}