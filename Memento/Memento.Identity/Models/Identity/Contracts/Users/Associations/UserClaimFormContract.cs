using Memento.Identity.Models.Identity.Repositories;
using Memento.Identity.Resources;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Memento.Identity.Models.Identity.Contracts.Users
{
	/// <summary>
	/// Implements the 'UserClaimForm' contract.
	/// </summary>
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public sealed class UserClaimFormContract
	{
		#region [Properties]
		/// <summary>
		/// The UserClaim's claim type.
		/// </summary>
		[Required]
		[MaxLength(UserClaimConfiguration.CLAIM_TYPE_MAXIMUM_LENGTH)]
		[Display(Name = nameof(SharedResources.USERCLAIM_CLAIMTYPE), ResourceType = typeof(SharedResources))]
		public string ClaimType { get; set; }

		/// <summary>
		/// The UserClaim's claim value.
		/// </summary>
		[Required]
		[MaxLength(UserClaimConfiguration.CLAIM_VALUE_MAXIMUM_LENGTH)]
		[Display(Name = nameof(SharedResources.USERCLAIM_CLAIMVALUE), ResourceType = typeof(SharedResources))]
		public string ClaimValue { get; set; }
		#endregion
	}
}