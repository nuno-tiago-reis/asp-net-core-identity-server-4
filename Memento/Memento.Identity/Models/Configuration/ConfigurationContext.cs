using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace Memento.Identity.Models.Configuration
{
	/// <summary>
	/// Implements the configuration database context.
	/// </summary>
	///
	/// <seealso cref="ConfigurationDbContext "/>
	public sealed class ConfigurationContext : ConfigurationDbContext<ConfigurationContext>
	{
		#region [Constructors]
		/// <summary>
		/// Initializes a new instance of the <see cref="ConfigurationContext"/> class.
		/// </summary>
		/// 
		/// <param name="contextOptions">The context options.</param>
		/// <param name="storeOptions">The store options.</param>
		public ConfigurationContext(DbContextOptions<ConfigurationContext> contextOptions, ConfigurationStoreOptions storeOptions)
		: base(contextOptions, storeOptions)
		{
			// Nothing to do here.
		}
		#endregion
	}
}