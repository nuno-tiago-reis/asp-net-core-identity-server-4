using Memento.Identity.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Memento.Identity.Models.Identity.Contracts.Roles
{
	/// <summary>
	/// Implements the 'RoleList' contract.
	/// </summary>
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public sealed class RoleListContract
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

		/// <summary>
		/// The Role's claims
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_ROLECLAIMS), ResourceType = typeof(SharedResources))]
		public List<RoleClaimListContract> Claims { get; set; }

		/// <summary>
		/// The Role's users.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_ROLEUSERS), ResourceType = typeof(SharedResources))]
		public List<RoleUserListContract> Users { get; set; }

		/// <summary>
		/// The Role's created by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_CREATEDBY), ResourceType = typeof(SharedResources))]
		public long CreatedBy { get; set; }

		/// <summary>
		/// The Role's created at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_CREATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// The Role's updated by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_UPDATEDBY), ResourceType = typeof(SharedResources))]
		public long? UpdatedBy { get; set; }

		/// <summary>
		/// The Role's updated at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_UPDATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime? UpdatedAt { get; set; }
		#endregion
	}
}