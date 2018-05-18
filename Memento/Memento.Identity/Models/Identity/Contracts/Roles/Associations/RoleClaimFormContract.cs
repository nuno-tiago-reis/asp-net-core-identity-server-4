using Memento.Identity.Models.Identity.Repositories;
using Memento.Identity.Resources;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Memento.Identity.Models.Identity.Contracts.Roles
{
	/// <summary>
	/// Implements the 'RoleClaimForm' contract.
	/// </summary>
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public sealed class RoleClaimFormContract
	{
		#region [Properties]
		/// <summary>
		/// The RoleClaim's claim type.
		/// </summary>
		[Required]
		[MaxLength(RoleClaimConfiguration.CLAIM_TYPE_MAXIMUM_LENGTH)]
		[Display(Name = nameof(SharedResources.ROLECLAIM_CLAIMTYPE), ResourceType = typeof(SharedResources))]
		public string ClaimType { get; set; }

		/// <summary>
		/// The RoleClaim's claim value.
		/// </summary>
		[Required]
		[MaxLength(RoleClaimConfiguration.CLAIM_VALUE_MAXIMUM_LENGTH)]
		[Display(Name = nameof(SharedResources.ROLECLAIM_CLAIMVALUE), ResourceType = typeof(SharedResources))]
		public string ClaimValue { get; set; }
		#endregion
	}
}