using AutoMapper;
using IdentityServer4;
using Memento.Identity.Configuration;
using Memento.Identity.Models.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Memento.Identity.Models.Identity;
using Memento.Identity.Models.Identity.Repositories.Roles;
using Memento.Identity.Models.Identity.Repositories.Users;
using Memento.Identity.Models.Operation;
using Memento.Identity.Resources;
using Memento.Shared.Extensions;
using Memento.Shared.Models.Bindings;
using Memento.Shared.Routing.Transformers;
using Memento.Shared.Services.Localization;
using Memento.Shared.Services.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;

namespace Memento.Identity
{
	/// <summary>
	/// Implements the applications configuration class.
	/// </summary>
	public sealed class Startup
	{
		#region [Properties]
		/// <summary>
		/// The configuration.
		/// </summary>
		private readonly IConfiguration Configuration;

		/// <summary>
		/// The identity settings.
		/// </summary>
		private readonly IdentitySettings IdentitySettings;
		#endregion

		#region [Constructors]
		/// <summary>
		/// Initializes a new instance of the <see cref="Startup"/> class.
		/// </summary>
		/// 
		/// <param name="configuration">The configuration.</param>
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
			this.IdentitySettings = configuration.Get<IdentitySettings>();
		}
		#endregion

		#region [Methods]
		/// <summary>
		/// This method gets called by the runtime.
		/// Use this method to add services to the container.
		/// </summary>
		/// 
		/// <param name="services">The services.</param>
		public void ConfigureServices(IServiceCollection services)
		{
			#region [Required: ASP.NET AppSettings]
			services
				.Configure<IdentitySettings>(this.Configuration);
			#endregion

			#region [Required: ASP.NET Middleware]
			services
				.AddControllersWithViews()
				.AddSharedLocalization<SharedResources>(this.IdentitySettings.Localization);

			services
				.AddRazorPages();

			services
				.Configure<ApiBehaviorOptions>(options =>
				{
					// hide the default validation errors
					options.InvalidModelStateResponseFactory = (context) =>
					{
						foreach (var keyValuePair in context.ModelState)
						{
							if (keyValuePair.Value.ValidationState != ModelValidationState.Invalid)
								continue;

							keyValuePair.Value.Errors.Clear();
							keyValuePair.Value.Errors.Add(new ModelError($"The '{keyValuePair.Key}' field is invalid."));
						}

						return new BadRequestObjectResult(context.ModelState);
					};
					// see: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.apibehavioroptions.suppressinferbindingsourcesforparameters?view=aspnetcore-3.1
					options.SuppressInferBindingSourcesForParameters = true;
				});
			services
				.Configure<CookiePolicyOptions>(options =>
				{
					// require the consent cookie
					options.CheckConsentNeeded = context => true;
					// require the latest cookie site policies
					options.MinimumSameSitePolicy = SameSiteMode.None;
				});
			services
				.Configure<MvcOptions>(options =>
				{
					// transform the routing tokens by splitting them with slashes
					options.Conventions.Add(new RouteTokenTransformerConvention(new SlashParameterTransformer()));
					// convert datetimes to utc
					options.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider());
				});
			services
				.Configure<JsonOptions>(options =>
				{
					// configure the default options
					options.JsonSerializerOptions.ConfigureDefaultOptions();
				});
			services
				.Configure<RouteOptions>(options =>
				{
					// transform the routing tokens by converting them to lower case
					options.LowercaseUrls = true;
					// don't append a trailing slash
					options.AppendTrailingSlash = false;
				});
			#endregion

			#region [Required: ASP.NET DataProtection]
			//services
				//.AddAzureDataProtection(this.MovieSettings.DataProtection);
				//.AddFileSystemDataProtection(this.MovieSettings.DataProtection);
			#endregion

			#region [Required: ASP.NET EntityFramework]
			services
				.AddDbContext<ConfigurationContext>(options =>
				{
					options.UseSqlServer(this.IdentitySettings.ConnectionStrings.Configuration, builder =>
					{
						builder.MigrationsAssembly(typeof(ConfigurationContext).Assembly.FullName);
					});
				})
				.AddTransient<ConfigurationSeeder>();

			services
				.AddDbContext<IdentityContext>(options =>
				{
					options.UseSqlServer(this.IdentitySettings.ConnectionStrings.Identity, builder =>
					{
						builder.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName);
					});
				})
				.AddTransient<IdentitySeeder>();

			services
				.AddDbContext<OperationContext>(options =>
				{
					options.UseSqlServer(this.IdentitySettings.ConnectionStrings.Operation, builder =>
					{
						builder.MigrationsAssembly(typeof(OperationContext).Assembly.FullName);
					});
				})
				.AddTransient<OperationSeeder>();

			services
				.AddTransient<IRoleRepository, RoleRepository>()
				.AddTransient<IUserRepository, UserRepository>();
			#endregion

			#region [Required: ASP.NET Identity]
			services
				.AddIdentity<User, Role>(options =>
				{
					options.User.RequireUniqueEmail = true;

					options.SignIn.RequireConfirmedAccount = true;
					options.SignIn.RequireConfirmedEmail = true;
					options.SignIn.RequireConfirmedPhoneNumber = false;

					options.Lockout.AllowedForNewUsers = true;
					options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
					options.Lockout.MaxFailedAccessAttempts = 5;

					options.Password.RequiredLength = 12;
					options.Password.RequireDigit = true;
					options.Password.RequireLowercase = true;
					options.Password.RequireUppercase = true;
					options.Password.RequiredUniqueChars = 1;
					options.Password.RequireNonAlphanumeric = true;
				})
				.AddEntityFrameworkStores<IdentityContext>()
				.AddDefaultTokenProviders();
			#endregion

			#region [Required: ASP.NET IdentityServer]
			services
				.AddIdentityServer(options =>
				{
					// Consent
					options.UserInteraction.ConsentUrl = "/IdentityServer/Consent";
					options.UserInteraction.ConsentReturnUrlParameter = "returnUrl";

					// Device
					options.UserInteraction.DeviceVerificationUrl = "/IdentityServer/Device";
					options.UserInteraction.DeviceVerificationUserCodeParameter = "userCode";

					// Error
					options.UserInteraction.ErrorUrl = "/IdentityServer/Error";
					options.UserInteraction.ErrorIdParameter = "errorId";

					// Login
					options.UserInteraction.LoginUrl = "/IdentityServer/Account/Login";
					options.UserInteraction.LoginReturnUrlParameter = "returnUrl";

					// Logout
					options.UserInteraction.LogoutUrl = "/IdentityServer/Account/Logout";
					options.UserInteraction.LogoutIdParameter = "logoutId";

					// Events
					options.Events.RaiseErrorEvents = true;
					options.Events.RaiseFailureEvents = true;
					options.Events.RaiseInformationEvents = true;
					options.Events.RaiseSuccessEvents = true;
				})
				.AddAspNetIdentity<User>()
				.AddConfigurationStore(options =>
				{
					options.ConfigureDbContext = builder =>
					{
						builder.UseSqlServer(this.IdentitySettings.ConnectionStrings.Configuration, sql =>
						{
							sql.MigrationsAssembly(typeof(ConfigurationContext).Assembly.FullName);
						});
					};
				})
				.AddOperationalStore(options =>
				{
					options.ConfigureDbContext = builder =>
					{
						builder.UseSqlServer(this.IdentitySettings.ConnectionStrings.Operation, sql =>
						{
							sql.MigrationsAssembly(typeof(OperationContext).Assembly.FullName);
						});
					};
				})
				.AddDeveloperSigningCredential();
			#endregion

			#region [Required: ASP.NET Services]
			services
				.AddSingleton<ILookupNormalizer, UpperInvariantLookupNormalizer>();
			#endregion

			#region [Required: Authentication]
			services
				.AddAuthentication()
				.AddLocalApi(options =>
				{
					options.SaveToken = true;
					options.ExpectedScope = string.Empty;
				})
				.AddGoogle("Google", options =>
				{
					options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

					options.ClientId = this.IdentitySettings.Google.ApiKey;
					options.ClientSecret = this.IdentitySettings.Google.ApiSecret;
				})
				.AddFacebook("Facebook", options =>
				{
					options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

					options.ClientId = this.IdentitySettings.Facebook.ApiKey;
					options.ClientSecret = this.IdentitySettings.Facebook.ApiSecret;
				})
				.AddMicrosoftAccount("Microsoft", options =>
				{
					options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

					options.ClientId = this.IdentitySettings.Microsoft.ApiKey;
					options.ClientSecret = this.IdentitySettings.Microsoft.ApiSecret;
				})
				.AddTwitter("Twitter", options =>
				{
					options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

					options.ConsumerKey = this.IdentitySettings.Twitter.ApiKey;
					options.ConsumerSecret = this.IdentitySettings.Twitter.ApiSecret;
				});
			#endregion

			#region [Required: Authorization]
			services
				.AddAuthorization(options =>
				{
					options.AddPolicy(IdentityServerConstants.LocalApi.PolicyName, policy =>
					{
						policy.AddAuthenticationSchemes(IdentityServerConstants.LocalApi.AuthenticationScheme);
						policy.RequireAuthenticatedUser();
						policy.Build();
					});
				})
				.AddAuthorizationPolicyEvaluator();
			#endregion

			#region [Required: AutoMapper]
			services
				.AddAutoMapper(typeof(MovieMapperProfile).Assembly);
			#endregion

			#region [Required: Services]
			services
				.AddSendGridService(this.IdentitySettings.SendGrid)
				.AddTwilioService(this.IdentitySettings.Twilio);
			//services
				//.AddAzureStorageService(this.IdentitySettings.Storage);
				//.AddFileSystemStorageService(this.IdentitySettings.Storage);
			#endregion
		}

		/// <summary>
		/// This method gets called by the runtime.
		/// Use this method to configure the HTTP request pipeline.
		/// </summary>
		/// 
		/// <param name="builder">The builder.</param>
		/// <param name="environment">The environment.</param>
		// 
		public void Configure(IApplicationBuilder builder, IWebHostEnvironment environment)
		{
			#region [Required: ASP.NET Errors]
			if (environment.IsDevelopment())
			{
				builder.UseDeveloperExceptionPage();
				builder.UseDatabaseErrorPage();
			}
			else
			{
				builder.UseExceptionHandler("/Error");
				builder.UseHsts();
			}
			#endregion

			#region [Required: ASP.NET Middleware]
			builder.UseCors(action =>
			{
				action.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
			});
			builder.UseHttpsRedirection();
			builder.UseCookiePolicy();
			builder.UseStaticFiles();
			builder.UseRouting();
			builder.UseHsts();
			#endregion

			#region [Required: ASP.NET IdentityServer]
			builder.UseIdentityServer();
			#endregion

			#region [Required: ASP.NET Authentication]
			builder.UseAuthentication();
			builder.UseAuthorization();
			#endregion

			#region [Required: ASP.NET Localization]
			builder.UseSharedLocalization(this.IdentitySettings.Localization);
			#endregion

			#region [Required: ASP.NET EntityFramework]
			using (var scope = builder.ApplicationServices.CreateScope())
			{
				scope.ServiceProvider.GetService<ConfigurationContext>().Database.Migrate();
				scope.ServiceProvider.GetService<ConfigurationSeeder>().Seed();

				scope.ServiceProvider.GetService<IdentityContext>().Database.Migrate();
				scope.ServiceProvider.GetService<IdentitySeeder>().Seed();

				scope.ServiceProvider.GetService<OperationContext>().Database.Migrate();
				scope.ServiceProvider.GetService<OperationSeeder>().Seed();
			}
			#endregion

			#region [Required: ASP.NET Routing]
			builder.UseEndpoints(endpoints =>
			{
				endpoints.MapAreaControllerRoute
				(
					name: "IdentityServer",
					areaName: "IdentityServer",
					pattern: "IdentityServer/{controller=Home}/{action=Index}/{id?}"
				);
				endpoints.MapControllerRoute
				(
					name: "Default",
					pattern: "{controller=Home}/{action=Index}/{id?}"
				);
				endpoints.MapRazorPages();
			});
			#endregion
		}
		#endregion
	}
}