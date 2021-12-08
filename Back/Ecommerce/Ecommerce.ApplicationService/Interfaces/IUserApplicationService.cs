using Ecommerce.CrossCutting.DTO.User;
using FluentResults;
using System.Collections.Generic;

namespace Ecommerce.ApplicationService.Interfaces

{
    public interface IUserApplicationService
    {
        ReadUserDTO Add(CreateUserDTO createUserDto);
        IList<ReadUserDTO> List();
        ReadUserDTO GetById(int id);
        ReadUserDTO GetByLogin(string username, string password);

        Result Update(int id, UpdateUserDTO updateUserDto);
        Result Delete(int id);
    }
}