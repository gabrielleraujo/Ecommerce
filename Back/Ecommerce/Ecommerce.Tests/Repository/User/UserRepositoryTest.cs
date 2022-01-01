using Ecommerce.Data.Context;
using Ecommerce.Repository.EF;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Ecommerce.Tests.Repository.User
{
    public class UserRepositoryTest
    {

        [Fact(DisplayName = "Add_SaveChangesNeedsToBeCalledOnlyOnce_Always")]
        [Trait("UserRepository", "Repository Tests")]
        public void Add_SaveChangesNeedsToBeCalledOnlyOnce_Always()
        {
            //Arrange

            var user = CreatGabiUser();

            var options = new DbContextOptionsBuilder<EcommerceContext>().UseInMemoryDatabase("EcommerceContext").Options;

            var mockDbSetUser = new Mock<DbSet<Data.Entities.User>>();

            var mockContext = new Mock<EcommerceContext>(options);
            mockContext.Setup(x => x.Users).Returns(mockDbSetUser.Object);

            var userRepository = new UserRepository(mockContext.Object);

            // Act
            userRepository.Add(user);

            // Assert
            mockDbSetUser.Verify(m => m.Add(It.IsAny<Data.Entities.User>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact(DisplayName = "Add_WhenGivenUserWithValidInformation_MustIncludeInDB")]
        [Trait("UserRepository", "Repository Tests")]
        public void Add_WhenGivenUserWithValidInformation_MustIncludeInDB()
        {
            //Arrange

            var createUserDto = CreatPedroUser();

            var options = new DbContextOptionsBuilder<EcommerceContext>().UseInMemoryDatabase("EcommerceContext").Options;

            var context = new EcommerceContext(options);
            var userRepository = new UserRepository(context);

            // Act
            userRepository.Add(createUserDto);

            // Assert
            var usersInDB = userRepository.List();
            Assert.NotNull(usersInDB);
        }

        private Data.Entities.User CreatGabiUser()
        {
            return new Data.Entities.User
            {
                Name = "gabi",
                Surname = "Araújo",
                UserName = "gabi",
                Email = "gabi@gmail.com",
                Password = "123",
                Role = "comprador",
            };
        }

        private Data.Entities.User CreatPedroUser()
        {
            return new Data.Entities.User
            {
                Name = "Pedro",
                Surname = "Souza",
                UserName = "pedro",
                Email = "pedro@gmail.com",
                Password = "123",
                Role = "comprador",
            };
        }
    }
}