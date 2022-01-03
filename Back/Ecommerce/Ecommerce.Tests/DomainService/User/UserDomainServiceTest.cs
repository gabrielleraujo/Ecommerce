using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Data.Context;
using Ecommerce.Repository.EF;
using Ecommerce.CrossCutting.DTO.User;
using Ecommerce.DomainService.Services;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Tests.Configurations;
using System;
using Xunit;
using Moq;
using FluentAssertions;

namespace Ecommerce.Tests.DomainService.User
{
    public class UserDomainServiceTest
    {
        [Fact(DisplayName = "Add_WhenGivenCreateUserDTOWithValidInformation_MustIncludeInDB")]
        [Trait("UserDomainService", "DomainService Tests")]
        public void Add_WhenGivenCreateUserDTOWithValidInformation_MustIncludeInDB()
        {
            //Arrange

            var createUserDto = CreatBiaUserDto();

            var mapperConfig = AutoMapperConfiguration.Configure();
            var mapper = mapperConfig.CreateMapper();

            var options = new DbContextOptionsBuilder<EcommerceContext>().UseInMemoryDatabase("EcommerceContext").Options;
            var context = new EcommerceContext(options);
            var userRepository = new UserRepository(context);

            var mockLogger = new Mock<ILogger<UserDomainService>>();

            var userDomainService = new UserDomainService(userRepository, mapper, mockLogger.Object);

            // Act
            userDomainService.Add(createUserDto);

            // Assert
            var usersInDB = userRepository.GetByEmail(createUserDto.Email);
            Assert.NotNull(usersInDB);
        }

        [Fact(DisplayName = "Add_ThrowsArgumentExceptionWhithTheExpectedMessage_WhenEmailAlreadyExistsInDB")]
        [Trait("UserDomainService", "DomainService Tests")]
        public void Add_ThrowsArgumentExceptionWhithTheExpectedMessage_WhenEmailAlreadyExistsInDB()
        {
            //Arrange

            var createUserDto = CreatJoaoUserDto();

            var mapperConfig = AutoMapperConfiguration.Configure();
            var mapper = mapperConfig.CreateMapper();

            var options = new DbContextOptionsBuilder<EcommerceContext>().UseInMemoryDatabase("EcommerceContext").Options;
            var context = new EcommerceContext(options);
            var userRepository = new UserRepository(context);

            var mockLogger = new Mock<ILogger<UserDomainService>>();

            var userDomainService = new UserDomainService(userRepository, mapper, mockLogger.Object);
            var expectedMessageException = "This email is already in use.";

            userDomainService.Add(createUserDto);

            // Act
            Action act = () => userDomainService.Add(createUserDto);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage(expectedMessageException);
        }

        [Fact(DisplayName = "Add_ReturnTheReadDTO_WhenTheEmailDoesNotYetExistInTheDB")]
        [Trait("UserDomainService", "DomainService Tests")]
        public void Add_ReturnTheReadDTO_WhenTheEmailDoesNotYetExistInTheDB()
        {
            //Arrange

            var createUserDto = CreatJoaoUserDto();

            var mapperConfig = AutoMapperConfiguration.Configure();
            var mapper = mapperConfig.CreateMapper();

            var user = mapper.Map<Data.Entities.User>(createUserDto);
            var expectedReadUserDto = mapper.Map<ReadUserDTO>(user);

            var mockUserRepository = new Mock<IUserRepository>();
            var mockLogger = new Mock<ILogger<UserDomainService>>();

            var userDomainService = new UserDomainService(mockUserRepository.Object, mapper, mockLogger.Object);
            
            // Act
            var readUserDtoResult = userDomainService.Add(createUserDto);

            // Assert
            expectedReadUserDto.Should().BeEquivalentTo(readUserDtoResult);
        }

        [Fact(DisplayName = "Add_GetByEmailNeedsToBeCallOnlyOnce_Always")]
        [Trait("UserDomainService", "DomainService Tests")]
        public void Add_GetByEmailNeedsToBeCallOnlyOnce_Always()
        {
            //Arrange

            var createUserDto = CreatJoaoUserDto();

            var mapperConfig = AutoMapperConfiguration.Configure();
            var mapper = mapperConfig.CreateMapper();

            var mockUserRepository = new Mock<IUserRepository>();
            var mockLogger = new Mock<ILogger<UserDomainService>>();

            var userDomainService = new UserDomainService(mockUserRepository.Object, mapper, mockLogger.Object);

            // Act
            userDomainService.Add(createUserDto);

            // Assert
            mockUserRepository.Verify(x => x.GetByEmail(It.IsAny<string>()), Times.Once());
        }

        private CreateUserDTO CreatJoaoUserDto()
        {
            return new CreateUserDTO
            {
                Name = "João",
                Surname = "Souza",
                Username = "jao",
                Email = "joao@gmail.com",
                Password = "123",
                RePassword = "123",
                Role = "comprador",
            };
        }

        private CreateUserDTO CreatBiaUserDto()
        {
            return new CreateUserDTO
            {
                Name = "Bia",
                Surname = "Araújo",
                Username = "bia",
                Email = "bia@gmail.com",
                Password = "123",
                RePassword = "123",
                Role = "comprador",
            };
        }
    }
}