using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using Memento.Shared.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Memento.Identity.Models.Configuration
{
	/// <summary>
	/// Implements the configuration database seeder.
	/// </summary>
	///
	/// <seealso cref="ConfigurationContext"/>
	public sealed class ConfigurationSeeder
	{
		#region [Constants]
		/// <summary>
		/// The filename with the seeding data for the 'ApiResource' models.
		/// </summary>
		private const string API_RESOURCES_FILE_NAME = "Models/Configuration/Seeding/ApiResources";

		/// <summary>
		/// The filename with the seeding data for the 'IdentityResource' models.
		/// </summary>
		private const string IDENTITY_RESOURCES_FILE_NAME = "Models/Configuration/Seeding/IdentityResources";

		/// <summary>
		/// The filename with the seeding data for the 'Client' models.
		/// </summary>
		private const string CLIENTS_FILE_NAME = "Models/Configuration/Seeding/Clients";
		#endregion

		#region [Properties]
		/// <summary>
		/// The context.
		/// </summary>
		private readonly ConfigurationContext Context;

		/// <summary>
		/// The json serializer options.
		/// </summary>
		private readonly JsonSerializerOptions SerializerOptions;

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
		/// Initializes a new instance of the <see cref="ConfigurationSeeder"/> class.
		/// </summary>
		/// 
		/// <param name="context">The configuration context.</param>
		/// <param name="environment">The environment.</param>
		/// <param name="logger">The logger.</param>
		public ConfigurationSeeder
		(
			ConfigurationContext context,
			IWebHostEnvironment environment,
			ILogger<ConfigurationSeeder> logger
		)
		{
			this.Context = context;
			this.Environment = environment;
			this.Logger = logger;

			this.SerializerOptions = new JsonSerializerOptions();
			this.SerializerOptions.ConfigureDefaultOptions();
		}
		#endregion

		#region [Seed Methods]
		/// <summary>
		/// Seeds the configuration context models (as well as other necessary entities).
		/// </summary>
		public void Seed()
		{
			this.SeedApiResources();
			this.SeedIdentityResources();
			this.SeedClients();
		}

		/// <summary>
		/// Seeds the api resources.
		/// </summary>
		private void SeedApiResources()
		{
			// Build the resources
			var resources = new List<ApiResource>();

			try
			{
				// Read the resources from the global file
				var globalFile = $"{API_RESOURCES_FILE_NAME}.json";
				resources.AddRange(JsonSerializer.Deserialize<List<ApiResource>>(File.ReadAllText(globalFile), this.SerializerOptions));
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
				// Read the resources from the environment specific file
				var environmentFile = $"{API_RESOURCES_FILE_NAME}.{this.Environment.EnvironmentName}.json";
				resources.AddRange(JsonSerializer.Deserialize<List<ApiResource>>(File.ReadAllText(environmentFile), this.SerializerOptions));
			}
			catch (DirectoryNotFoundException)
			{
				// Ignore if the file does not exist
			}
			catch (Exception exception)
			{
				this.Logger.LogError(exception.Message, exception);
			}

			// Sort the resources
			resources.Sort((first, second) => string.Compare(first.Name, second.Name, StringComparison.Ordinal));

			// Update the context
			foreach (var resource in resources)
			{
				// Check if it exists
				var contextRole = this.Context.ApiResources
					.FirstOrDefault(r => r.Name == resource.Name);

				// Add the client
				if (contextRole == null)
				{
					this.Context.ApiResources.Add(resource.ToEntity());
					continue;
				}
			}

			// Save the context
			this.Context.SaveChanges();
		}

		/// <summary>
		/// Seeds the identity resources.
		/// </summary>
		private void SeedIdentityResources()
		{
			// Build the resources
			var resources = new List<IdentityResource>();

			try
			{
				// Read the resources from the global file
				var globalFile = $"{IDENTITY_RESOURCES_FILE_NAME}.json";
				resources.AddRange(JsonSerializer.Deserialize<List<IdentityResource>>(File.ReadAllText(globalFile), this.SerializerOptions));
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
				// Read the resources from the environment specific file
				var environmentFile = $"{IDENTITY_RESOURCES_FILE_NAME}.{this.Environment.EnvironmentName}.json";
				resources.AddRange(JsonSerializer.Deserialize<List<IdentityResource>>(File.ReadAllText(environmentFile), this.SerializerOptions));
			}
			catch (DirectoryNotFoundException)
			{
				// Ignore if the file does not exist
			}
			catch (Exception exception)
			{
				this.Logger.LogError(exception.Message, exception);
			}

			// Sort the resources
			resources.Sort((first, second) => string.Compare(first.Name, second.Name, StringComparison.Ordinal));

			// Update the context
			foreach (var resource in resources)
			{
				// Check if it exists
				var contextResource = this.Context.IdentityResources
					.FirstOrDefault(r => r.Name == resource.Name);

				// Add the resource
				if (contextResource == null)
				{
					this.Context.IdentityResources.Add(resource.ToEntity());
					continue;
				}
			}

			// Save the context
			this.Context.SaveChanges();
		}

		/// <summary>
		/// Seeds the clients.
		/// </summary>
		private void SeedClients()
		{
			// Build the clients
			var clients = new List<Client>();

			try
			{
				// Read the clients from the global file
				var globalFile = $"{CLIENTS_FILE_NAME}.json";
				clients.AddRange(Newtonsoft.Json.JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(globalFile)));

				// TODO Replace with the System.Text.Json (Should be fixed in .NET 5.0)
				// https://github.com/dotnet/runtime/issues/31553
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
				// Read the clients from the environment specific file
				var environmentFile = $"{CLIENTS_FILE_NAME}.{this.Environment.EnvironmentName}.json";
				clients.AddRange(Newtonsoft.Json.JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(environmentFile)));

				// TODO Replace with the System.Text.Json (Should be fixed in .NET 5.0)
				// https://github.com/dotnet/runtime/issues/31553
			}
			catch (DirectoryNotFoundException)
			{
				// Ignore if the file does not exist
			}
			catch (Exception exception)
			{
				this.Logger.LogError(exception.Message, exception);
			}

			// Sort the clients
			clients.Sort((first, second) => string.Compare(first.ClientId, second.ClientId, StringComparison.Ordinal));

			// Update the context
			foreach (var client in clients)
			{
				// Check if it exists
				var contextRole = this.Context.Clients
					.FirstOrDefault(c => c.ClientId == client.ClientId);

				// Add the client
				if (contextRole == null)
				{
					this.Context.Clients.Add(client.ToEntity());
					continue;
				}
			}

			// Save the context
			this.Context.SaveChanges();
		}
		#endregion
	}
}