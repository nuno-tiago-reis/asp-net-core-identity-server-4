using Memento.Identity.Resources;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Memento.Identity.Models.Identity.Contracts.Roles
{
	/// <summary>
	/// Implements the 'RoleClaimList' contract.
	/// </summary>
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public sealed class RoleClaimListContract
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
		#endregion
	}
}