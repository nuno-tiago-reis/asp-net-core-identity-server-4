using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace Memento.Identity.Models.Operation
{
	/// <summary>
	/// Implements the operation database context.
	/// </summary>
	///
	/// <seealso cref="PersistedGrantDbContext"/>
	public sealed class OperationContext : PersistedGrantDbContext<OperationContext>
	{
		#region [Constructors]
		/// <summary>
		/// Initializes a new instance of the <see cref="OperationContext"/> class.
		/// </summary>
		/// 
		/// <param name="contextOptions">The context options.</param>
		/// <param name="storeOptions">The store options.</param>
		public OperationContext(DbContextOptions<OperationContext> contextOptions, OperationalStoreOptions storeOptions)
		: base(contextOptions, storeOptions)
		{
			// Nothing to do here.
		}
		#endregion
	}
}