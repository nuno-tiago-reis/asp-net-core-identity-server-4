using Memento.Identity.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Memento.Identity.Models.Identity.Contracts.Roles
{
	/// <summary>
	/// Implements the 'RoleClaimDetail' contract.
	/// </summary>
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public sealed class RoleClaimDetailContract
	{
		#region [Properties]
		/// <summary>
		/// The RoleClaim's identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLECLAIM_ID), ResourceType = typeof(SharedResources))]
		public int Id { get; set; }

		/// <summary>
		/// The RoleClaim's claim type.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLECLAIM_CLAIMTYPE), ResourceType = typeof(SharedResources))]
		public string ClaimType { get; set; }

		/// <summary>
		/// The RoleClaim's claim value.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLECLAIM_CLAIMVALUE), ResourceType = typeof(SharedResources))]
		public string ClaimValue { get; set; }

		/// <summary>
		/// The RoleClaim's created by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLECLAIM_CREATEDBY), ResourceType = typeof(SharedResources))]
		public long CreatedBy { get; set; }

		/// <summary>
		/// The RoleClaim's created at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLECLAIM_CREATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// The RoleClaim's updated by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLECLAIM_UPDATEDBY), ResourceType = typeof(SharedResources))]
		public long? UpdatedBy { get; set; }

		/// <summary>
		/// The RoleClaim's updated at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLECLAIM_UPDATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime? UpdatedAt { get; set; }
		#endregion
	}
}