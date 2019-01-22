using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace Memento.Identity.Models.Operation
{
	/// <summary>
	/// Implements the operation database seeder.
	/// </summary>
	///
	/// <seealso cref="OperationContext"/>
	public sealed class OperationSeeder
	{
		#region [Properties]
		/// <summary>
		/// The context.
		/// </summary>
		private readonly OperationContext Context;

		/// <summary>
		/// The hosting environment.
		/// </summary>
		private readonly IWebHostEnvironment Environment;

		/// <summary>
		/// The logger.
		/// </summary>
		private readonly ILogger Logger;
		#endregion

		#region [Constructors]
		/// <summary>
		/// Initializes a new instance of the <see cref="OperationSeeder"/> class.
		/// </summary>
		/// 
		/// <param name="context">The operation context.</param>
		/// <param name="environment">The environment.</param>
		/// <param name="logger">The logger.</param>
		public OperationSeeder
		(
			OperationContext context,
			IWebHostEnvironment environment,
			ILogger<OperationSeeder> logger
		)
		{
			this.Context = context;
			this.Environment = environment;
			this.Logger = logger;
		}
		#endregion

		#region [Seed Methods]
		/// <summary>
		/// Seeds the operation context models (as well as other necessary entities).
		/// </summary>
		public void Seed()
		{
			// Nothing to do here
		}
		#endregion
	}
}