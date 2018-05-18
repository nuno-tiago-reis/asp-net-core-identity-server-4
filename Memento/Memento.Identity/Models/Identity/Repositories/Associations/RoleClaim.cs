using Memento.Identity.Models.Identity.Repositories.Roles;
using Memento.Identity.Resources;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Memento.Identity.Models.Identity.Repositories
{
	/// <summary>
	/// Implements the 'RoleClaim' model.
	/// </summary>
	public sealed class RoleClaim : IdentityRoleClaim<long>
	{
		#region [Properties]
		/// <summary>
		/// The identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLECLAIM_ID), ResourceType = typeof(SharedResources))]
		public override int Id { get; set; }

		/// <summary>
		/// The claim type.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLECLAIM_CLAIMTYPE), ResourceType = typeof(SharedResources))]
		public override string ClaimType { get; set; }

		/// <summary>
		/// The claim value.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLECLAIM_CLAIMVALUE), ResourceType = typeof(SharedResources))]
		public override string ClaimValue { get; set; }

		/// <summary>
		/// The role.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLECLAIM_ROLE), ResourceType = typeof(SharedResources))]
		public Role Role { get; set; }

		/// <summary>
		/// The role identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLECLAIM_ROLEID), ResourceType = typeof(SharedResources))]
		public override long RoleId { get; set; }

		/// <summary>
		/// The created by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLECLAIM_CREATEDBY), ResourceType = typeof(SharedResources))]
		public long CreatedBy { get; set; }

		/// <summary>
		/// The created at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLECLAIM_CREATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// The updated by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLECLAIM_UPDATEDBY), ResourceType = typeof(SharedResources))]
		public long? UpdatedBy { get; set; }

		/// <summary>
		/// The updated at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLECLAIM_UPDATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime? UpdatedAt { get; set; }
		#endregion
	}
}