namespace Memento.Identity.Configuration
{
	/// <summary>
	/// Defines all the available routes.
	/// </summary>
	public static class Routes
	{
		#region [Account]
		/// <summary>
		/// The account routes.
		/// </summary>
		public static class AccountRoutes
		{
			/// <summary>
			/// The account root route.
			/// </summary>
			public const string ROOT = "/Api/Account/";
		}
		#endregion

		#region [Identity]
		/// <summary>
		/// The role routes.
		/// </summary>
		public static class RoleRoutes
		{
			/// <summary>
			/// The roles root route.
			/// </summary>
			public const string ROOT = "/Api/Roles/";
		}

		/// <summary>
		/// The user routes.
		/// </summary>
		public static class UserRoutes
		{
			/// <summary>
			/// The user root route.
			/// </summary>
			public const string ROOT = "/Api/Users/";
		}
		#endregion

		#region [Movies]
		/// <summary>
		/// The genre routes.
		/// </summary>
		public static class GenreRoutes
		{
			/// <summary>
			/// The genres root route.
			/// </summary>
			public const string ROOT = "/Api/Genres/";
		}

		/// <summary>
		/// The movie routes.
		/// </summary>
		public static class MovieRoutes
		{
			/// <summary>
			/// The movies root route.
			/// </summary>
			public const string ROOT = "/Api/Movies/";
		}

		/// <summary>
		/// The person routes.
		/// </summary>
		public static class PersonRoutes
		{
			/// <summary>
			/// The persons root route.
			/// </summary>
			public const string ROOT = "/Api/Persons/";
		}
		#endregion
	}
}