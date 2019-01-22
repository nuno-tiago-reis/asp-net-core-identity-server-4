using Memento.Identity.Models.Identity.Repositories.Users;
using Memento.Identity.Resources;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Memento.Identity.Models.Identity.Repositories
{
	/// <summary>
	/// Implements the 'UserLogin' model.
	/// </summary>
	public sealed class UserLogin : IdentityUserLogin<long>
	{
		#region [Properties]
		/// <summary>
		/// The login provider.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERLOGIN_LOGINPROVIDER), ResourceType = typeof(SharedResources))]
		public override string LoginProvider { get; set; }

		/// <summary>
		/// The provider key.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERLOGIN_PROVIDERKEY), ResourceType = typeof(SharedResources))]
		public override string ProviderKey { get; set; }

		/// <summary>
		/// The provider display name.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERLOGIN_PROVIDERDISPLAYNAME), ResourceType = typeof(SharedResources))]
		public override string ProviderDisplayName { get; set; }

		/// <summary>
		/// The user.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERLOGIN_USER), ResourceType = typeof(SharedResources))]
		public User User { get; set; }

		/// <summary>
		/// The user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERLOGIN_USERID), ResourceType = typeof(SharedResources))]
		public override long UserId { get; set; }

		/// <summary>
		/// The created by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERLOGIN_CREATEDBY), ResourceType = typeof(SharedResources))]
		public long CreatedBy { get; set; }

		/// <summary>
		/// The created at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERLOGIN_CREATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// The updated by user identifier.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERLOGIN_UPDATEDBY), ResourceType = typeof(SharedResources))]
		public long? UpdatedBy { get; set; }

		/// <summary>
		/// The updated at timestamp.
		/// </summary>
		[Display(Name = nameof(SharedResources.USERLOGIN_UPDATEDAT), ResourceType = typeof(SharedResources))]
		public DateTime? UpdatedAt { get; set; }
		#endregion
	}
}