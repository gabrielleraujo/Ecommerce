using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Data.Context;
using Ecommerce.Repository.EF;
using Ecommerce.CrossCutting.DTO.User;
using Ecommerce.DomainService.Services;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Tests.Templates;
using System;
using Xunit;
using Moq;
using FluentAssertions;

namespace Ecommerce.Tests.User
{
    public class UserDomainServiceTest : UserDomainServiceTestBase
    {
        [Fact]
        public void Add_WhenGivenCreateUserDtoWithValidInformation_MustIncludeInDB()
        {
            //Arrange

            var createUserDto = CreatBiaUserDto();

            var mapperConfig = ConfigureAutoMapper();
            var mapper = mapperConfig.CreateMapper();

            var options = new DbContextOptionsBuilder<EcommerceContext>().UseInMemoryDatabase("EcommerceContext").Options;

            var context = new EcommerceContext(options);
            var userRepository = new UserRepository(context);

            var mockLogger = new Mock<ILogger<UserDomainService>>();
            var logger = mockLogger.Object;

            var userDomainService = new UserDomainService(userRepository, mapper, logger);
            userDomainService.Add(createUserDto);

            // Act
            var usersInDB = userRepository.List();

            // Assert
            Assert.NotNull(usersInDB);
        }

        [Fact]
        public void Add_ThrowsArgumentExceptionWhithTheExpectedMessage_WhenEmailAlreadyExistsInDB()
        {
            //Arrange

            var createUserDto = CreatJoaoUserDto();

            var mapperConfig = ConfigureAutoMapper();
            var mapper = mapperConfig.CreateMapper();

            var options = new DbContextOptionsBuilder<EcommerceContext>().UseInMemoryDatabase("EcommerceContext").Options;

            var context = new EcommerceContext(options);
            var userRepository = new UserRepository(context);

            var mockLogger = new Mock<ILogger<UserDomainService>>();
            var logger = mockLogger.Object;

            var userDomainService = new UserDomainService(userRepository, mapper, logger);
            var expectedMessageException = "This email is already in use.";

            var readUserDto = userDomainService.Add(createUserDto);

            // Act
            Action act = () => userDomainService.Add(createUserDto);

            // Assert
            var exeption = Assert.Throws<ArgumentException>(act);
            Assert.Equal(expectedMessageException, exeption.Message);
        }

        [Fact]
        public void Add_ReturnTheReadDTO_WhenEmailIsNotExistsInDB()
        {
            //Arrange

            var createUserDto = CreatJoaoUserDto();

            var mapperConfig = ConfigureAutoMapper();
            var mapper = mapperConfig.CreateMapper();

            var user = mapper.Map<Data.Entities.User>(createUserDto);
            var expectedReadUserDto = mapper.Map<ReadUserDTO>(user);

            var userRepositoryMock = new Mock<IUserRepository>();
            var userRepository = userRepositoryMock.Object;
            
            var mockLogger = new Mock<ILogger<UserDomainService>>();
            var logger = mockLogger.Object;

            var userDomainService = new UserDomainService(userRepository, mapper, logger);
            
            // Act
            var readUserDtoResult = userDomainService.Add(createUserDto);

            // Assert
            userRepositoryMock.Verify(x => x.GetByEmail(It.IsAny<string>()), Times.Once());
            userRepositoryMock.Verify(x => x.Add(It.IsAny<Data.Entities.User>()), Times.Once());
            expectedReadUserDto.Should().BeEquivalentTo(readUserDtoResult);
        }
    }
}