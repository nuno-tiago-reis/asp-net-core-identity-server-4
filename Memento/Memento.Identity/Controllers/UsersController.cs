using AutoMapper;
using Memento.Identity.Configuration;
using Memento.Identity.Models.Identity.Contracts.Users;
using Memento.Identity.Models.Identity.Repositories.Users;
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
	/// Implements the API controller for the user model.
	/// </summary>
	///
	/// <seealso cref="MementoApiController" />
	[ApiController]
	[Route(Routes.UserRoutes.ROOT)]
	public sealed class UsersController : MementoApiController
	{
		#region [Properties]
		/// <summary>
		/// The 'User' repository.
		/// </summary>
		private readonly IUserRepository Repository;
		#endregion

		#region [Constructors]
		/// <summary>
		/// Initializes a new instance of the <see cref="UsersController"/> class.
		/// </summary>
		/// 
		/// <param name="repository">The repository.</param>
		/// <param name="logger">The logger.</param>
		/// <param name="mapper">The mapper.</param>
		/// <param name="localizer">The localizer.</param>
		public UsersController
		(
			IUserRepository repository,
			ILogger<UsersController> logger,
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
		/// Creates a 'User' in the backend.
		/// </summary>
		/// 
		/// <param name="contract">The contract.</param>
		[HttpPost]
		public async Task<ActionResult<MementoResponse<UserDetailContract>>> CreateAsync([FromBody] UserFormContract contract)
		{
			// Map the user
			var user = this.Mapper.Map<User>(contract);

			// Create the user
			var createdUser = await this.Repository.CreateAsync(user);

			// Build the response
			return this.BuildCreateResponse<User, UserDetailContract>(createdUser);
		}

		/// <summary>
		/// Updates a 'User' in the backend.
		/// </summary>
		///
		/// <param name="id">The identifier.</param>
		/// <param name="contract">The contract.</param>
		[HttpPut("{id:long}")]
		public async Task<ActionResult<MementoResponse>> UpdateAsync([FromRoute] long id, [FromBody] UserFormContract contract)
		{
			// Map the user
			var user = this.Mapper.Map<User>(contract);
			user.Id = id;

			// Update the user
			await this.Repository.UpdateAsync(user);

			// Build the response
			return this.BuildUpdateResponse();
		}

		/// <summary>
		/// Deletes a 'User' in the backend.
		/// </summary>
		///
		/// <param name="id">The identifier.</param>
		[HttpDelete("{id:long}")]
		public async Task<ActionResult<MementoResponse>> DeleteAsync([FromRoute] long id)
		{
			// Delete the user
			await this.Repository.DeleteAsync(id);

			// Build the response
			return this.BuildDeleteResponse();
		}

		/// <summary>
		/// Gets a 'User' from the backend.
		/// </summary>
		///
		/// <param name="id">The identifier.</param>
		[HttpGet("{id:long}")]
		public async Task<ActionResult<MementoResponse<UserDetailContract>>> GetAsync([FromRoute] long id)
		{
			// Get the users
			var user = await this.Repository.GetAsync(id);

			// Build the response
			return this.BuildGetResponse<User, UserDetailContract>(user);
		}

		/// <summary>
		/// Gets 'Users' from the backend according to the filter.
		/// </summary>
		/// 
		/// <param name="filter">The filter.</param>
		[HttpGet]
		public async Task<ActionResult<MementoResponse<IPage<UserListContract>>>> GetAsync([FromQuery] UserFilter filter)
		{
			// Get the users
			var users = await this.Repository.GetAllAsync(filter);

			// Build the response
			return this.BuildGetAllResponse<User, UserListContract>(users);
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