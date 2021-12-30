using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using Ecommerce.CrossCutting.DTO.User;
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
            var readUserDto = await _userApiClient.GetUsersAsync();

            IList<UserHomeViewModel> userHomeViewModel = _mapper.Map<IList<UserHomeViewModel>>(readUserDto);
            return new UserListViewModel { Users = userHomeViewModel };
        }

        public async Task<IList<UserDetailsViewModel>> ListAsync()
        {
            var readUserDto = await _userApiClient.GetUsersAsync();
            return _mapper.Map<IList<UserDetailsViewModel>>(readUserDto); ;
        }

        public async Task<UserDetailsViewModel> GetByIdAsync(int id)
        {
            var readUserDto = await _userApiClient.GetUserByIdAsync(id);
            return _mapper.Map<UserDetailsViewModel>(readUserDto);
        }

        public async Task<UserDetailsViewModel> AddAsync(UserRegistrationViewModel usuarioViewModel)
        {
            var createUserDto = _mapper.Map<CreateUserDTO>(usuarioViewModel);

            var readUserDto = await _userApiClient.PostUserAsync(createUserDto);
            return _mapper.Map<UserDetailsViewModel>(readUserDto);
        }

        public async Task<Result> DeleteAsync(int id) => await _userApiClient.DeleteUserAsync(id);
    }
}