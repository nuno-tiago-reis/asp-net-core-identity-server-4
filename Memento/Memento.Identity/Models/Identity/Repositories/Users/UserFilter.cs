using Memento.Identity.Resources;
using Memento.Shared.Models.Repositories;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Memento.Identity.Models.Identity.Repositories.Users
{
	/// <summary>
	/// Defines the fields over which 'Users' can be filtered.
	/// </summary>
	///
	/// <seealso cref="UserFilterOrderBy" />
	/// <seealso cref="UserFilterOrderDirection" />
	public sealed class UserFilter : ModelFilter<UserFilterOrderBy, UserFilterOrderDirection>
	{
		#region [Properties]
		/// <summary>
		///  The 'Username' filter.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_USERNAME), ResourceType = typeof(SharedResources))]
		public string UserName { get; set; }

		/// <summary>
		///  The 'Email' filter.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_EMAIL), ResourceType = typeof(SharedResources))]
		public string Email { get; set; }

		/// <summary>
		///  The 'PhoneNumber' filter.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_PHONENUMBER), ResourceType = typeof(SharedResources))]
		public string PhoneNumber { get; set; }

		/// <summary>
		///  The 'Enabled' filter.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_ENABLED), ResourceType = typeof(SharedResources))]
		public UserFilterEnabled? Enabled { get; set; }
		#endregion

		#region [Methods]
		/// <inheritdoc />
		protected override void ReadFilterFromQuery(Dictionary<string, StringValues> query)
		{
			// Username
			if (query.TryGetValue(nameof(this.UserName), out var username))
			{
				this.UserName = username;
			}

			// Email
			if (query.TryGetValue(nameof(this.Email), out var email))
			{
				this.Email = email;
			}

			// PhoneNumber
			if (query.TryGetValue(nameof(this.Email), out var phoneNumber))
			{
				this.PhoneNumber = phoneNumber;
			}

			// Enabled
			if (query.TryGetValue(nameof(this.Enabled), out var enabledQuery))
			{
				if (Enum.TryParse<UserFilterEnabled>(enabledQuery, out var enabled))
				{
					this.Enabled = enabled;
				}
			}
		}

		/// <inheritdoc />
		protected override void WriteFilterToQuery(Dictionary<string, string> query)
		{
			// Name
			if (!string.IsNullOrWhiteSpace(this.UserName))
			{
				query.Add(nameof(this.UserName), this.UserName);
			}

			// Email
			if (!string.IsNullOrWhiteSpace(this.Email))
			{
				query.Add(nameof(this.Email), this.Email);
			}

			// PhoneNumber
			if (!string.IsNullOrWhiteSpace(this.PhoneNumber))
			{
				query.Add(nameof(this.PhoneNumber), this.PhoneNumber);
			}

			// Enabled
			if (this.Enabled != null)
			{
				query.Add(nameof(this.Enabled), this.Enabled.ToString());
			}
		}
		#endregion
	}

	/// <summary>
	/// Defines the fields over which 'Users' can be ordered by.
	/// </summary>
	public enum UserFilterOrderBy
	{
		/// <summary>
		/// By 'Id'.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_ID), ResourceType = typeof(SharedResources))]
		Id = 0,
		/// <summary>
		/// By 'UserName'.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_USERNAME), ResourceType = typeof(SharedResources))]
		UserName = 1,
		/// <summary>
		/// By 'CreatedAt'.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_CREATEDAT), ResourceType = typeof(SharedResources))]
		CreatedAt = 2,
		/// <summary>
		/// By 'UpdatedAt'.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_UPDATEDAT), ResourceType = typeof(SharedResources))]
		UpdatedAt = 3
	}

	/// <summary>
	/// Defines the direction over which 'Users' can be ordered by.
	/// </summary>
	public enum UserFilterOrderDirection
	{
		/// <summary>
		/// In 'Ascending' order.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_ORDER_ASCENDING), ResourceType = typeof(SharedResources))]
		Ascending = 0,
		/// <summary>
		/// In 'Descending' order.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_ORDER_DESCENDING), ResourceType = typeof(SharedResources))]
		Descending = 1
	}

	/// <summary>
	/// Defines the options on which the 'Enabled' filter can be used.
	/// </summary>
	public enum UserFilterEnabled
	{
		/// <summary>
		/// In 'Checked' option.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_ENABLED_CHECKED), ResourceType = typeof(SharedResources))]
		Checked = 0,
		/// <summary>
		/// In 'Unchecked' option.
		/// </summary>
		[Display(Name = nameof(SharedResources.USER_ENABLED_UNCHECKED), ResourceType = typeof(SharedResources))]
		Unchecked = 1
	}
}