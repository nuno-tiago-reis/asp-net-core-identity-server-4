using Memento.Identity.Resources;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Memento.Identity.Models.Identity.Contracts.Users
{
	/// <summary>
	/// Implements the 'UserClaimList' contract.
	/// </summary>
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public sealed class UserClaimListContract
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
		#endregion
	}
}