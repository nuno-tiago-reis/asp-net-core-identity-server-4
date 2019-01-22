using Memento.Identity.Resources;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Memento.Identity.Models.Identity.Contracts.Users
{
	/// <summary>
	/// Implements the 'UserRoleForm' contract.
	/// </summary>
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public sealed class UserRoleFormContract
	{
		#region [Properties]
		/// <summary>
		/// The Role's identifier.
		/// </summary>
		[Required]
		[Display(Name = nameof(SharedResources.ROLE_ID), ResourceType = typeof(SharedResources))]
		public long? Id { get; set; }
		#endregion
	}
}