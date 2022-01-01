using Ecommerce.Repository.Interfaces;
using Moq;
using Xunit;

namespace Ecommerce.Tests.Repository.User
{
    public class UserRepositoryTest
    {

        [Fact(DisplayName = "Add_NeedsToBeCalledOnlyOnce_Always")]
        [Trait("UserRepository", "Repository Tests")]
        public void Add_NeedsToBeCalledOnlyOnce_Always()
        {
            //Arrange

            var user = CreatJoaoUser();

            var userRepositoryMock = new Mock<IUserRepository>();
            var userRepository = userRepositoryMock.Object;

            // Act
            userRepository.Add(user);

            // Assert
            userRepositoryMock.Verify(x => x.Add(It.IsAny<Data.Entities.User>()), Times.Once());
        }

        private Data.Entities.User CreatJoaoUser()
        {
            return new Data.Entities.User
            {
                Name = "João",
                Surname = "Souza",
                UserName = "jao",
                Email = "joao@gmail.com",
                Password = "123",
                Role = "comprador",
            };
        }
    }
}