using AutoMapper;
using Memento.Identity.Models.Identity.Repositories;
using Memento.Identity.Models.Identity.Contracts.Roles;
using Memento.Identity.Models.Identity.Contracts.Users;
using Memento.Identity.Models.Identity.Repositories.Roles;
using Memento.Identity.Models.Identity.Repositories.Users;
using Memento.Shared.Configuration;
using Memento.Shared.Models.Pagination;
using System;

namespace Memento.Identity.Configuration
{
	/// <summary>
	/// Implements the 'MovieMapper' profile.
	/// </summary>
	/// 
	/// <seealso cref="Profile" />
	public sealed class MovieMapperProfile : MementoMapperProfile
	{
		#region [Constructor]
		/// <summary>
		/// Initializes a new instance of the <see cref="MovieMapperProfile"/> class.
		/// </summary>
		public MovieMapperProfile()
		{
			this.CreateMappings();
		}
		#endregion

		#region [Methods]
		/// <inheritdoc />
		protected override void CreateMappings()
		{
			base.CreateMappings();

			#region [Contracts: Roles]
			// Roles: Model => Contract
			this.CreateMap<Role, RoleDetailContract>()
				.ForMember(contract => contract.Claims, expression => expression.MapFrom(model => model.RoleClaims))
				.ForMember(contract => contract.Users, expression => expression.MapFrom(model => model.RoleUsers));
			// Roles: Model => Contract
			this.CreateMap<Role, RoleFormContract>()
				.ForMember(contract => contract.Claims, expression => expression.MapFrom(model => model.RoleClaims))
				.ForMember(contract => contract.Users, expression => expression.MapFrom(model => model.RoleUsers));
			// Roles: Model => Contract
			this.CreateMap<Role, RoleListContract>()
				.ForMember(contract => contract.Claims, expression => expression.MapFrom(model => model.RoleClaims))
				.ForMember(contract => contract.Users, expression => expression.MapFrom(model => model.RoleUsers));

			// Roles: Contract => Model
			this.CreateMap<RoleFormContract, Role>()
				.ForMember(model => model.RoleClaims, expression => expression.MapFrom(contract => contract.Claims))
				.ForMember(model => model.RoleUsers, expression => expression.MapFrom(contract => contract.Users));

			// Roles: Contract => Contract
			this.CreateMap<RoleDetailContract, RoleFormContract>();
			// Roles: Contract => Contract
			this.CreateMap<RoleListContract, RoleFormContract>();
			#endregion

			#region [Contracts: RoleClaims]
			// RoleClaims: Model => Contract
			this.CreateMap<RoleClaim, RoleClaimDetailContract>();
			// RoleClaims: Model => Contract
			this.CreateMap<RoleClaim, RoleClaimFormContract>();
			// RoleClaims: Model => Contract
			this.CreateMap<RoleClaim, RoleClaimListContract>();

			// RoleClaims: Contract => Model
			this.CreateMap<RoleClaimFormContract, RoleClaim>();
			#endregion

			#region [Contracts: RoleUsers]
			// RoleUsers: Model => Contract
			this.CreateMap<UserRole, RoleUserDetailContract>()
				.ConstructUsing((model, context) => context.Mapper.Map<RoleUserDetailContract>(model.User))
				.ForAllOtherMembers(contract => contract.Ignore());
			// RoleUsers: Model => Contract
			this.CreateMap<UserRole, RoleUserFormContract>()
				.ConstructUsing((model, context) => context.Mapper.Map<RoleUserFormContract>(model.User))
				.ForAllOtherMembers(model => model.Ignore());
			// RoleUsers: Model => Contract
			this.CreateMap<UserRole, RoleUserListContract>()
				.ConstructUsing((model, context) => context.Mapper.Map<RoleUserListContract>(model.User))
				.ForAllOtherMembers(model => model.Ignore());

			// RoleUsers: Model => Contract
			this.CreateMap<User, RoleUserDetailContract>();
			// RoleUsers: Model => Contract
			this.CreateMap<User, RoleUserFormContract>();
			// RoleUsers: Model => Contract
			this.CreateMap<User, RoleUserListContract>();

			// RoleUsers: Contract => Model
			this.CreateMap<RoleUserFormContract, UserRole>()
				.ForMember(model => model.UserId, expression => expression.MapFrom(contract => contract.Id))
				.ForAllOtherMembers(model => model.Ignore());

			// RoleUsers: Contract => Contract
			this.CreateMap<RoleUserDetailContract, RoleUserFormContract>();
			// RoleUsers: Contract => Contract
			this.CreateMap<RoleUserListContract, RoleUserFormContract>();

			// RoleUsers: Contract => Contract
			this.CreateMap<UserDetailContract, RoleUserFormContract>();
			// RoleUsers: Contract => Contract
			this.CreateMap<UserListContract, RoleUserFormContract>();

			// UserGenres: Contract => Contract
			this.CreateMap<RoleUserDetailContract, UserListContract>();
			// UserGenres: Contract => Contract
			this.CreateMap<RoleUserListContract, UserListContract>();
			#endregion

			#region [Contracts: Users]
			// Users: Model => Contract
			this.CreateMap<User, UserDetailContract>()
				.ForMember(contract => contract.Claims, expression => expression.MapFrom(model => model.UserClaims))
				.ForMember(contract => contract.Roles, expression => expression.MapFrom(model => model.UserRoles));
			// Users: Model => Contract
			this.CreateMap<User, UserFormContract>()
				.ForMember(contract => contract.Claims, expression => expression.MapFrom(model => model.UserClaims))
				.ForMember(contract => contract.Roles, expression => expression.MapFrom(model => model.UserRoles));
			// Users: Model => Contract
			this.CreateMap<User, UserListContract>()
				.ForMember(contract => contract.Claims, expression => expression.MapFrom(model => model.UserClaims))
				.ForMember(contract => contract.Roles, expression => expression.MapFrom(model => model.UserRoles));

			// Users: Contract => Model
			this.CreateMap<UserFormContract, User>()
				.ForMember(model => model.UserClaims, expression => expression.MapFrom(contract => contract.Claims))
				.ForMember(model => model.UserRoles, expression => expression.MapFrom(contract => contract.Roles));

			// Users: Contract => Contract
			this.CreateMap<UserDetailContract, UserFormContract>();
			// Users: Contract => Contract
			this.CreateMap<UserListContract, UserFormContract>();
			#endregion

			#region [Contracts: UserClaims]
			// UserClaims: Model => Contract
			this.CreateMap<UserClaim, UserClaimDetailContract>();
			// UserClaims: Model => Contract
			this.CreateMap<UserClaim, UserClaimFormContract>();
			// UserClaims: Model => Contract
			this.CreateMap<UserClaim, UserClaimListContract>();

			// MovieGenres: Contract => Model
			this.CreateMap<UserClaimFormContract, UserClaim>();
			#endregion

			#region [Contracts: UserRoles]
			// UserRoles: Model => Contract
			this.CreateMap<UserRole, UserRoleDetailContract>()
				.ConstructUsing((model, context) => context.Mapper.Map<UserRoleDetailContract>(model.Role))
				.ForAllOtherMembers(model => model.Ignore());
			// UserRoles: Model => Contract
			this.CreateMap<UserRole, UserRoleFormContract>()
				.ConstructUsing((model, context) => context.Mapper.Map<UserRoleFormContract>(model.Role))
				.ForAllOtherMembers(model => model.Ignore());
			// UserRoles: Model => Contract
			this.CreateMap<UserRole, UserRoleListContract>()
				.ConstructUsing((model, context) => context.Mapper.Map<UserRoleListContract>(model.Role))
				.ForAllOtherMembers(model => model.Ignore());

			// UserRoles: Model => Contract
			this.CreateMap<Role, UserRoleDetailContract>();
			// UserRoles: Model => Contract
			this.CreateMap<Role, UserRoleFormContract>();
			// UserRoles: Model => Contract
			this.CreateMap<Role, UserRoleListContract>();

			// UserRoles: Contract => Model
			this.CreateMap<UserRoleFormContract, UserRole>()
				.ForMember(model => model.RoleId, expression => expression.MapFrom(contract => contract.Id))
				.ForAllOtherMembers(model => model.Ignore());

			// UserRoles: Contract => Contract
			this.CreateMap<UserRoleDetailContract, UserRoleFormContract>();
			// UserRoles: Contract => Contract
			this.CreateMap<UserRoleListContract, UserRoleFormContract>();

			// UserRoles: Contract => Contract
			this.CreateMap<RoleDetailContract, UserRoleFormContract>();
			// UserRoles: Contract => Contract
			this.CreateMap<RoleListContract, UserRoleFormContract>();

			// MovieGenres: Contract => Contract
			this.CreateMap<UserRoleDetailContract, RoleListContract>();
			// MovieGenres: Contract => Contract
			this.CreateMap<UserRoleListContract, RoleListContract>();
			#endregion

			#region [Filters: Roles]
			// Genres: Page => Filter
			this.CreateMap<Page<RoleListContract>, RoleFilter>()
				.ForMember(filter => filter.OrderBy, expression => expression.MapFrom(page => Enum.Parse(typeof(RoleFilterOrderBy), page.OrderBy)))
				.ForMember(filter => filter.OrderDirection, expression => expression.MapFrom(page => Enum.Parse(typeof(RoleFilterOrderDirection), page.OrderDirection)));
			#endregion

			#region [Filters: Users]
			// Genres: Page => Filter
			this.CreateMap<Page<UserListContract>, UserFilter>()
				.ForMember(filter => filter.OrderBy, expression => expression.MapFrom(page => Enum.Parse(typeof(UserFilterOrderBy), page.OrderBy)))
				.ForMember(filter => filter.OrderDirection, expression => expression.MapFrom(page => Enum.Parse(typeof(UserFilterOrderDirection), page.OrderDirection)));
			#endregion
		}
		#endregion
	}
}