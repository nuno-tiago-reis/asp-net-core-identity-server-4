using AutoMapper;
using Memento.Identity.Configuration;
using Memento.Identity.Models.Identity.Contracts.Roles;
using Memento.Identity.Models.Identity.Repositories.Roles;
using Memento.Identity.Resources;
using Memento.Shared.Controllers;
using Memento.Shared.Models.Pagination;
using Memento.Shared.Models.Responses;
using Memento.Shared.Services.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Memento.Identity.Controllers
{
	/// <summary>
	/// Implements the API controller for the role model.
	/// </summary>
	///
	/// <seealso cref="MementoApiController" />
	[ApiController]
	[Route(Routes.RoleRoutes.ROOT)]
	public sealed class RolesController : MementoApiController
	{
		#region [Properties]
		/// <summary>
		/// The 'Role' repository.
		/// </summary>
		private readonly IRoleRepository Repository;
		#endregion

		#region [Constructors]
		/// <summary>
		/// Initializes a new instance of the <see cref="RolesController"/> class.
		/// </summary>
		/// 
		/// <param name="repository">The repository.</param>
		/// <param name="logger">The logger.</param>
		/// <param name="mapper">The mapper.</param>
		/// <param name="localizer">The localizer.</param>
		public RolesController
		(
			IRoleRepository repository,
			ILogger<RolesController> logger,
			IMapper mapper,
			ILocalizerService localizer
		)
		: base(logger, mapper, localizer)
		{
			this.Repository = repository;
		}
		#endregion

		#region [Methods]
		/// <summary>
		/// Creates a 'Role' in the backend.
		/// </summary>
		/// 
		/// <param name="contract">The contract.</param>
		[HttpPost]
		public async Task<ActionResult<MementoResponse<RoleDetailContract>>> CreateAsync([FromBody] RoleFormContract contract)
		{
			// Map the role
			var role = this.Mapper.Map<Role>(contract);

			// Create the role
			var createdRole = await this.Repository.CreateAsync(role);

			// Build the response
			return this.BuildCreateResponse<Role, RoleDetailContract>(createdRole);
		}

		/// <summary>
		/// Updates a 'Role' in the backend.
		/// </summary>
		///
		/// <param name="id">The identifier.</param>
		/// <param name="contract">The contract.</param>
		[HttpPut("{id:long}")]
		public async Task<ActionResult<MementoResponse>> UpdateAsync([FromRoute] long id, [FromBody] RoleFormContract contract)
		{
			// Map the role
			var role = this.Mapper.Map<Role>(contract);
			role.Id = id;

			// Update the role
			await this.Repository.UpdateAsync(role);

			// Build the response
			return this.BuildUpdateResponse();
		}

		/// <summary>
		/// Deletes a 'Role' in the backend.
		/// </summary>
		///
		/// <param name="id">The identifier.</param>
		[HttpDelete("{id:long}")]
		public async Task<ActionResult<MementoResponse>> DeleteAsync([FromRoute] long id)
		{
			// Delete the role
			await this.Repository.DeleteAsync(id);

			// Build the response
			return this.BuildDeleteResponse();
		}

		/// <summary>
		/// Gets a 'Role' from the backend.
		/// </summary>
		///
		/// <param name="id">The identifier.</param>
		[HttpGet("{id:long}")]
		public async Task<ActionResult<MementoResponse<RoleDetailContract>>> GetAsync([FromRoute] long id)
		{
			// Get the roles
			var role = await this.Repository.GetAsync(id);

			// Build the response
			return this.BuildGetResponse<Role, RoleDetailContract>(role);
		}

		/// <summary>
		/// Gets 'Roles' from the backend according to the filter.
		/// </summary>
		/// 
		/// <param name="filter">The filter.</param>
		[HttpGet]
		public async Task<ActionResult<MementoResponse<IPage<RoleListContract>>>> GetAsync([FromQuery] RoleFilter filter)
		{
			// Get the roles
			var roles = await this.Repository.GetAllAsync(filter);

			// Build the response
			return this.BuildGetAllResponse<Role, RoleListContract>(roles);
		}
		#endregion

		#region [Methods] Messages
		/// <inheritdoc />
		protected override string BuildCreateSuccessfulMessage()
		{
			// Build the message
			var message = this.Localizer.GetString(SharedResources.CONTROLLER_CREATE_SUCCESSFUL);

			return message;
		}

		/// <inheritdoc />
		protected override string BuildUpdateSuccessfulMessage()
		{
			// Build the message
			var message = this.Localizer.GetString(SharedResources.CONTROLLER_UPDATE_SUCCESSFUL);

			return message;
		}

		/// <inheritdoc />
		protected override string BuildDeleteSuccessfulMessage()
		{
			// Build the message
			var message = this.Localizer.GetString(SharedResources.CONTROLLER_DELETE_SUCCESSFUL);

			return message;
		}

		/// <inheritdoc />
		protected override string BuildGetSuccessfulMessage()
		{
			// Build the message
			var message = this.Localizer.GetString(SharedResources.CONTROLLER_GET_SUCCESSFUL);

			return message;
		}

		/// <inheritdoc />
		protected override string BuildGetAllSuccessfulMessage()
		{
			// Build the message
			var message = this.Localizer.GetString(SharedResources.CONTROLLER_GET_ALL_SUCCESSFUL);

			return message;
		}
		#endregion
	}
}