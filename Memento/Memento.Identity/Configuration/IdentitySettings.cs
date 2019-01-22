using Memento.Shared.Configuration;
using Memento.Shared.Services.Localization;
using Memento.Shared.Services.Notifications;

namespace Memento.Identity.Configuration
{
	/// <summary>
	/// Implements the 'Identity' settings.
	/// </summary>
	public sealed class IdentitySettings
	{
		#region [Properties] Localization
		/// <summary>
		/// Gets or sets the localization options.
		/// </summary>
		public SharedLocalizerOptions Localization { get; set; }
		#endregion

		#region [Properties] Login Providers
		/// <summary>
		/// Gets or sets the google options.
		/// </summary>
		public ExternalProviderOptions Google { get; set; }

		/// <summary>
		/// Gets or sets the google options.
		/// </summary>
		public ExternalProviderOptions Facebook { get; set; }

		/// <summary>
		/// Gets or sets the google options.
		/// </summary>
		public ExternalProviderOptions Microsoft { get; set; }

		/// <summary>
		/// Gets or sets the google options.
		/// </summary>
		public ExternalProviderOptions Twitter { get; set; }
		#endregion

		#region [Properties] Notifications
		/// <summary>
		/// Gets or sets the sendgrid options.
		/// </summary>
		public SendGridOptions SendGrid { get; set; }

		/// <summary>
		/// Gets or sets the twilio options.
		/// </summary>
		public TwilioOptions Twilio { get; set; }
		#endregion

		#region [Properties] Connection Strings
		/// <summary>
		/// Gets or sets the connection strings.
		/// </summary>
		public ConnectionStrings ConnectionStrings { get; set; }
		#endregion
	}

	/// <summary>
	/// Implements the 'ConnectionStrings' settings.
	/// </summary>
	public sealed class ConnectionStrings
	{
		#region [Properties]
		/// <summary>
		/// The 'Configuration' connection string.
		/// </summary>
		public string Configuration { get; set; }

		/// <summary>
		/// The 'Identity' connection string.
		/// </summary>
		public string Identity { get; set; }

		/// <summary>
		/// The 'Operation' connection string.
		/// </summary>
		public string Operation { get; set; }
		#endregion
	}
}