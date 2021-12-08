using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.User;
using Ecommerce.ApplicationService.Interfaces;
using Ecommerce.DomainService.Interfaces;
using Ecommerce.ValidationService.Services;
using FluentResults;

namespace Ecommerce.ApplicationService.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserDomainService _userDomainService;
        private readonly UserValidationService _userValidationService;

        public UserApplicationService(IUserDomainService userDomainService, UserValidationService userValidationService)
        {
            _userDomainService = userDomainService;
            _userValidationService = userValidationService;
        }

        public ReadUserDTO Add(CreateUserDTO createUserDto)
        {
            _userValidationService.Validate(createUserDto);

            return _userDomainService.Add(createUserDto);
        }

        public Result Update(int id, UpdateUserDTO updateUserDto)
        {
            return _userDomainService.Update(id, updateUserDto);
        }

        public ReadUserDTO GetById(int id)
        {
            return _userDomainService.GetById(id);
        }

        public ReadUserDTO GetByLogin(string username, string password)
        {
            return _userDomainService.GetByLogin(username, password);
        }

        public Result Delete(int id)
        {
            return _userDomainService.Delete(id);
        }

        public IList<ReadUserDTO> List()
        {
            return _userDomainService.List();
        }
    }
}