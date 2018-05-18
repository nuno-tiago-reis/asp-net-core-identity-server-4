using Memento.Identity.Models.Identity.Repositories.Roles;
using Memento.Identity.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Memento.Identity.Models.Identity.Contracts.Roles
{
	/// <summary>
	/// Implements the 'RoleForm' contract.
	/// </summary>
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public sealed class RoleFormContract
	{
		#region [Properties]
		/// <summary>
		/// The Role's name.
		/// </summary>
		[Required]
		[MaxLength(RoleConfiguration.NAME_MAXIMUM_LENGTH)]
		[Display(Name = nameof(SharedResources.ROLE_NAME), ResourceType = typeof(SharedResources))]
		public string Name { get; set; }

		/// <summary>
		/// The Role's enabled flag.
		/// </summary>
		[Required]
		[Display(Name = nameof(SharedResources.ROLE_ENABLED), ResourceType = typeof(SharedResources))]
		public bool? Enabled { get; set; }

		/// <summary>
		/// The Role's claims
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_ROLECLAIMS), ResourceType = typeof(SharedResources))]
		public List<RoleClaimFormContract> Claims { get; set; }

		/// <summary>
		/// The Role's users.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_ROLEUSERS), ResourceType = typeof(SharedResources))]
		public List<RoleUserFormContract> Users { get; set; }
		#endregion
	}
}