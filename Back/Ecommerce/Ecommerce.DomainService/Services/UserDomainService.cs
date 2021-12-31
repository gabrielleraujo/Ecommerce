using AutoMapper;
using Ecommerce.DomainService.Interfaces;
using Ecommerce.Repository.Interfaces;
using Ecommerce.CrossCutting.DTO.User;
using Ecommerce.Data.Entities;
using FluentResults;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;

namespace Ecommerce.DomainService.Services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserDomainService> _logger;

        public UserDomainService(IUserRepository userRepository, IMapper mapper, ILogger<UserDomainService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public ReadUserDTO Add(CreateUserDTO createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);

            if (_userRepository.GetByEmail(user.Email) != null)
            {
                var exception = new ArgumentException("This email is already in use.");
                _logger.LogError(exception, exception.Message);
                throw exception;
            }

            _userRepository.Add(user);

            return _mapper.Map<ReadUserDTO>(user);
        }

        public Result Update(int id, UpdateUserDTO updateUserDto)
        {
            var user = _userRepository.GetById(id);

            if (user == null) { return Result.Fail("Usuario não encontrado"); }

            _mapper.Map(updateUserDto, user);
            _userRepository.Update(user);

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            var user = _userRepository.GetById(id);

            if (user == null) { return Result.Fail("Usuario não encontrado"); }

            _userRepository.Delete(id);

            return Result.Ok();
        }

        public IList<ReadUserDTO> List()
        {
            var users = _userRepository.List();

            return users != null ? _mapper.Map<IList<ReadUserDTO>>(users) : null;
        }

        public ReadUserDTO GetById(int id)
        {
            var user = _userRepository.GetById(id);

            return user != null ? _mapper.Map<ReadUserDTO>(user) : null;
        }

        public ReadUserDTO GetByLogin(string username, string password)
        {
            var user = _userRepository.GetByLogin(username, password);

            return user != null ? _mapper.Map<ReadUserDTO>(user) : null;
        }

        public int? GetAddress(int userId)
        {
            return _userRepository.GetAddress(userId);
        }
    }
}