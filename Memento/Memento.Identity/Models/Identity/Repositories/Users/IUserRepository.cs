using Memento.Shared.Models.Repositories;

namespace Memento.Identity.Models.Identity.Repositories.Users
{
	/// <summary>
	/// Defines an interface for a 'User' repository.
	/// Provides methods to interact with the movies (CRUD and more).
	/// </summary>
	///
	/// <seealso cref="User" />
	/// <seealso cref="UserFilter" />
	/// <seealso cref="UserFilterOrderBy" />
	/// <seealso cref="UserFilterOrderDirection" />
	public interface IUserRepository : IModelRepository<User, UserFilter, UserFilterOrderBy, UserFilterOrderDirection>
	{
		#region [Methods] IUserRepository
		#endregion
	}
}