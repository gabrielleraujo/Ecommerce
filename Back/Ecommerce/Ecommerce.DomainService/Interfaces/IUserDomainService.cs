using FluentResults;
using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.User;

namespace Ecommerce.DomainService.Interfaces
{
    public interface IUserDomainService
    {
        ReadUserDTO Add(CreateUserDTO createUserDto);
        IList<ReadUserDTO> List();
        ReadUserDTO GetById(int id);
        ReadUserDTO GetByLogin(string username, string password);

        Result Update(int id, UpdateUserDTO updateUserDto);
        Result Delete(int id);
        int? GetAddress(int userId);
    }
}