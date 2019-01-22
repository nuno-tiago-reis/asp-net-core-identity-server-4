using Memento.Shared.Models.Repositories;

namespace Memento.Identity.Models.Identity.Repositories.Roles
{
	/// <summary>
	/// Defines an interface for a 'Role' repository.
	/// Provides methods to interact with the movies (CRUD and more).
	/// </summary>
	///
	/// <seealso cref="Role" />
	/// <seealso cref="RoleFilter" />
	/// <seealso cref="RoleFilterOrderBy" />
	/// <seealso cref="RoleFilterOrderDirection" />
	public interface IRoleRepository : IModelRepository<Role, RoleFilter, RoleFilterOrderBy, RoleFilterOrderDirection>
	{
		#region [Methods] IRoleRepository
		#endregion
	}
}