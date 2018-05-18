using Memento.Identity.Resources;
using Memento.Shared.Models.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Memento.Identity.Models.Identity.Repositories.Roles
{
	/// <summary>
	/// Implements the 'Role' model.
	/// </summary>
	public sealed class Role : IdentityRole<long>, IModel
	{
		#region [Properties]
		/// <summary>
		/// The identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_ID), ResourceType = typeof(SharedResources))]
		public override long Id { get; set; }

		/// <summary>
		/// The name.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_NAME), ResourceType = typeof(SharedResources))]
		public override string Name { get; set; }

		/// <summary>
		/// The normalized name.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_NAME), ResourceType = typeof(SharedResources))]
		public override string NormalizedName { get; set; }

		/// <summary>
		/// The concurrency stamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_CONCURRENCYSTAMP), ResourceType = typeof(SharedResources))]
		public override string ConcurrencyStamp { get; set; }

		/// <summary>
		/// The enabled flag.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_ENABLED), ResourceType = typeof(SharedResources))]
		public bool? Enabled { get; set; }

		/// <summary>
		/// The role claims.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_ROLECLAIMS), ResourceType = typeof(SharedResources))]
		public List<RoleClaim> RoleClaims { get; set; }

		/// <summary>
		/// The role users.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_ROLEUSERS), ResourceType = typeof(SharedResources))]
		public List<UserRole> RoleUsers { get; set; }

		/// <summary>
		/// The created by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_CREATEDBY), ResourceType = typeof(SharedResources))]
		public long CreatedBy { get; set; }

		/// <summary>
		/// The created at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_CREATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// The updated by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_UPDATEDBY), ResourceType = typeof(SharedResources))]
		public long? UpdatedBy { get; set; }

		/// <summary>
		/// The updated at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_UPDATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime? UpdatedAt { get; set; }
		#endregion

		#region [Methods]
		/// <inheritdoc />
		public override bool Equals(object @object)
		{
			if (@object is Role role)
			{
				return this.Id == role.Id;
			}
			return false;
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			return HashCode.Combine(this.Id);
		}
		#endregion
	}
}