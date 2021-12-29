using AutoMapper;
using Ecommerce.CrossCutting.DTO.User;
using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Clients.Interfaces;
using WebApp.Services.Interfaces;
using WebApp.ViewModels;

namespace WebApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IMapper _mapper;

        public UserService(IUserApiClient userApiClient, IMapper mapper)
        {
            _userApiClient = userApiClient;
            _mapper = mapper;
        }

        public async Task<UserListViewModel> IndexAsync()
        {
            var usuarios = await _userApiClient.GetUsersAsync();

            IList<UserHomeViewModel> usuariosHomeViewModel = _mapper.Map<IList<UserHomeViewModel>>(usuarios);

            var model = new UserListViewModel { Users = usuariosHomeViewModel };

            return model;
        }

        public async Task<IList<UserDetailsViewModel>> ListAsync()
        {
            var usuarios = await _userApiClient.GetUsersAsync();
            return _mapper.Map<IList<UserDetailsViewModel>>(usuarios); ;
        }

        public async Task<UserDetailsViewModel> GetByIdAsync(int id)
        {
            ReadUserDTO usuario = await _userApiClient.GetUserByIdAsync(id);
            return _mapper.Map<UserDetailsViewModel>(usuario);
        }

        public async Task<UserDetailsViewModel> AddAsync(UserRegistrationViewModel usuarioViewModel)
        {
            CreateUserDTO userDto = _mapper.Map<CreateUserDTO>(usuarioViewModel);

            var readUsuarioDto = await _userApiClient.PostUserAsync(userDto);
            return _mapper.Map<UserDetailsViewModel>(readUsuarioDto);
        }

        public async Task<Result> DeleteAsync(int id)
        {
            return await _userApiClient.DeleteUserAsync(id);
        }
    }
}