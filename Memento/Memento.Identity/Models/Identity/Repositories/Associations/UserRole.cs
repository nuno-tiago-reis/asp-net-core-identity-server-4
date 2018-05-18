using Memento.Identity.Models.Identity.Repositories.Roles;
using Memento.Identity.Models.Identity.Repositories.Users;
using Memento.Identity.Resources;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Memento.Identity.Models.Identity.Repositories
{
	/// <summary>
	/// Implements the 'UserRole' model.
	/// </summary>
	public sealed class UserRole : IdentityUserRole<long>
	{
		#region [Properties]
		/// <summary>
		/// The user.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERROLE_USER), ResourceType = typeof(SharedResources))]
		public User User { get; set; }

		/// <summary>
		/// The user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERROLE_USERID), ResourceType = typeof(SharedResources))]
		public override long UserId { get; set; }

		/// <summary>
		/// The role.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERROLE_ROLE), ResourceType = typeof(SharedResources))]
		public Role Role { get; set; }

		/// <summary>
		/// The role identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERROLE_ROLEID), ResourceType = typeof(SharedResources))]
		public override long RoleId { get; set; }

		/// <summary>
		/// The created by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERROLE_CREATEDBY), ResourceType = typeof(SharedResources))]
		public long CreatedBy { get; set; }

		/// <summary>
		/// The created at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERROLE_CREATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// The updated by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERROLE_UPDATEDBY), ResourceType = typeof(SharedResources))]
		public long? UpdatedBy { get; set; }

		/// <summary>
		/// The updated at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERROLE_UPDATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime? UpdatedAt { get; set; }
		#endregion
	}
}