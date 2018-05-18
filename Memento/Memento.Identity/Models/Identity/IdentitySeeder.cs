using Memento.Identity.Models.Identity.Repositories.Roles;
using Memento.Identity.Models.Identity.Repositories.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Memento.Identity.Models.Identity
{
	/// <summary>
	/// Implements the identity database seeder.
	/// </summary>
	///
	/// <seealso cref="IdentityContext"/>
	public sealed class IdentitySeeder
	{
		#region [Constants]
		/// <summary>
		/// The filename with the seeding data for the 'Role' models.
		/// </summary>
		private const string ROLES_FILE_NAME = "Models/Identity/Seeding/Roles";

		/// <summary>
		/// The filename with the seeding data for the 'User' models.
		/// </summary>
		private const string USERS_FILE_NAME = "Models/Identity/Seeding/Users";
		#endregion

		#region [Properties]
		/// <summary>
		/// The context.
		/// </summary>
		private readonly IdentityContext Context;

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
		/// Initializes a new instance of the <see cref="IdentitySeeder"/> class.
		/// </summary>
		/// 
		/// <param name="context">The identity context.</param>
		/// <param name="environment">The environment.</param>
		/// <param name="logger">The logger.</param>
		public IdentitySeeder
		(
			IdentityContext context,
			IWebHostEnvironment environment,
			ILogger<IdentitySeeder> logger
		)
		{
			this.Context = context;
			this.Environment = environment;
			this.Logger = logger;
		}
		#endregion

		#region [Seed Methods]
		/// <summary>
		/// Seeds the identity context models (as well as other necessary entities).
		/// </summary>
		public void Seed()
		{
			this.SeedRoles();
			this.SeedUsers();
		}

		/// <summary>
		/// Seeds the roles.
		/// </summary>
		private void SeedRoles()
		{
			// Build the roles
			var roles = new List<Role>();

			try
			{
				// Read the roles from the global file
				string globalFile = $"{ROLES_FILE_NAME}.json";
				roles.AddRange(JsonSerializer.Deserialize<List<Role>>(File.ReadAllText(globalFile)));
			}
			catch (DirectoryNotFoundException)
			{
				// Ignore if the file does not exist
			}
			catch (Exception exception)
			{
				this.Logger.LogError(exception.Message, exception);
			}

			try
			{
				// Read the roles from the environment specific file
				string environmentFile = $"{ROLES_FILE_NAME}.{this.Environment.EnvironmentName}.json";
				roles.AddRange(JsonSerializer.Deserialize<List<Role>>(File.ReadAllText(environmentFile)));
			}
			catch (DirectoryNotFoundException)
			{
				// Ignore if the file does not exist
			}
			catch (Exception exception)
			{
				this.Logger.LogError(exception.Message, exception);
			}

			// Sort the roles
			roles.Sort((first, second) => string.Compare(first.Name, second.Name, StringComparison.Ordinal));

			// Update the context
			foreach (var role in roles)
			{
				// Check if it exists
				var contextRole = this.Context.Roles
					.FirstOrDefault(r => r.Name == role.Name);

				// Add the role
				if (contextRole == null)
				{
					this.Context.Roles.Add(role);
					continue;
				}
			}

			// Save the context
			this.Context.SaveChanges();
		}

		/// <summary>
		/// Seeds the users.
		/// </summary>
		private void SeedUsers()
		{
			// Build the users
			var users = new List<User>();

			try
			{
				// Read the users from the global file
				string globalFile = $"{USERS_FILE_NAME}.json";
				users.AddRange(JsonSerializer.Deserialize<List<User>>(File.ReadAllText(globalFile)));
			}
			catch (DirectoryNotFoundException)
			{
				// Ignore if the file does not exist
			}
			catch (Exception exception)
			{
				this.Logger.LogError(exception.Message, exception);
			}

			try
			{
				// Read the users from the environment specific file
				string environmentFile = $"{USERS_FILE_NAME}.{this.Environment.EnvironmentName}.json";
				users.AddRange(JsonSerializer.Deserialize<List<User>>(File.ReadAllText(environmentFile)));
			}
			catch (DirectoryNotFoundException)
			{
				// Ignore if the file does not exist
			}
			catch (Exception exception)
			{
				this.Logger.LogError(exception.Message, exception);
			}

			// Sort the users
			users.Sort((first, second) => string.Compare(first.UserName, second.UserName, StringComparison.Ordinal));

			// Update the context
			foreach (var user in users)
			{
				// Check if it exists
				var contextUser = this.Context.Users
					.FirstOrDefault(u => u.UserName == user.UserName);

				// Add the user
				if (contextUser == null)
				{
					this.Context.Users.Add(user);
					continue;
				}
			}

			// Save the context
			this.Context.SaveChanges();
		}
		#endregion
	}
}