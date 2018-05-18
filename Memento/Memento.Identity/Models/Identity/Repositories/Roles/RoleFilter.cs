using Memento.Identity.Resources;
using Memento.Shared.Models.Repositories;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Memento.Identity.Models.Identity.Repositories.Roles
{
	/// <summary>
	/// Defines the fields over which 'Roles' can be filtered.
	/// </summary>
	///
	/// <seealso cref="RoleFilterOrderBy" />
	/// <seealso cref="RoleFilterOrderDirection" />
	public sealed class RoleFilter : ModelFilter<RoleFilterOrderBy, RoleFilterOrderDirection>
	{
		#region [Properties]
		/// <summary>
		///  The 'Name' filter.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_NAME), ResourceType = typeof(SharedResources))]
		public string Name { get; set; }

		/// <summary>
		///  The 'Enabled' filter.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_ENABLED), ResourceType = typeof(SharedResources))]
		public RoleFilterEnabled? Enabled { get; set; }
		#endregion

		#region [Methods]
		/// <inheritdoc />
		protected override void ReadFilterFromQuery(Dictionary<string, StringValues> query)
		{
			// Name
			if (query.TryGetValue(nameof(this.Name), out var name))
			{
				this.Name = name;
			}

			// Enabled
			if (query.TryGetValue(nameof(this.Enabled), out var enabledQuery))
			{
				if (Enum.TryParse<RoleFilterEnabled>(enabledQuery, out var enabled))
				{
					this.Enabled = enabled;
				}
			}
		}

		/// <inheritdoc />
		protected override void WriteFilterToQuery(Dictionary<string, string> query)
		{
			// Name
			if (!string.IsNullOrWhiteSpace(this.Name))
			{
				query.Add(nameof(this.Name), this.Name);
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
	/// Defines the fields over which 'Roles' can be ordered by.
	/// </summary>
	public enum RoleFilterOrderBy
	{
		/// <summary>
		/// By 'Id'.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_ID), ResourceType = typeof(SharedResources))]
		Id = 0,
		/// <summary>
		/// By 'Name'.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_NAME), ResourceType = typeof(SharedResources))]
		Name = 1,
		/// <summary>
		/// By 'CreatedAt'.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_CREATEDAT), ResourceType = typeof(SharedResources))]
		CreatedAt = 2,
		/// <summary>
		/// By 'UpdatedAt'.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_UPDATEDAT), ResourceType = typeof(SharedResources))]
		UpdatedAt = 3
	}

	/// <summary>
	/// Defines the direction over which 'Roles' can be ordered by.
	/// </summary>
	public enum RoleFilterOrderDirection
	{
		/// <summary>
		/// In 'Ascending' order.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_ORDER_ASCENDING), ResourceType = typeof(SharedResources))]
		Ascending = 0,
		/// <summary>
		/// In 'Descending' order.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_ORDER_DESCENDING), ResourceType = typeof(SharedResources))]
		Descending = 1
	}

	/// <summary>
	/// Defines the options on which the 'Enabled' filter can be used.
	/// </summary>
	public enum RoleFilterEnabled
	{
		/// <summary>
		/// In 'Checked' option.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_ENABLED_CHECKED), ResourceType = typeof(SharedResources))]
		Checked = 0,
		/// <summary>
		/// In 'Unchecked' option.
		/// </summary>
		[Display(Name = nameof(SharedResources.ROLE_ENABLED_UNCHECKED), ResourceType = typeof(SharedResources))]
		Unchecked = 1
	}
}