using Memento.Identity.Resources;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Memento.Identity.Models.Identity.Contracts.Users
{
	/// <summary>
	/// Implements the 'UserRoleList' contract.
	/// </summary>
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public sealed class UserRoleListContract
	{
		#region [Properties]
		/// <summary>
		/// The Role's identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_ID), ResourceType = typeof(SharedResources))]
		public long Id { get; set; }

		/// <summary>
		/// The Role's name.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_NAME), ResourceType = typeof(SharedResources))]
		public string Name { get; set; }

		/// <summary>
		/// The Role's enabled flag.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_ENABLED), ResourceType = typeof(SharedResources))]
		public bool? Enabled { get; set; }
		#endregion
	}
}