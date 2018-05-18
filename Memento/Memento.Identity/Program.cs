using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Memento.Identity
{
	/// <summary>
	/// Implements the applications bootstrapping class.
	/// </summary>
	public sealed class Program
	{
		/// <summary>
		/// The applications bootstrapping method.
		/// </summary>
		/// 
		/// <param name="arguments">The bootstrapping arguments.</param>
		public static void Main(string[] arguments)
		{
			CreateHostBuilder(arguments).Build().Run();
		}

		/// <summary>
		/// The applications host building method.
		/// </summary>
		/// 
		/// <param name="arguments">The bootstrapping arguments.</param>
		public static IHostBuilder CreateHostBuilder(string[] arguments)
		{
			return Host.CreateDefaultBuilder(arguments).ConfigureWebHostDefaults(builder =>
			{
				builder.UseStartup<Startup>();
			});
		}
	}
}