using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMoq;

        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IUserRepository>();

            repositoryWrapperMoq.Setup(x => x.User)
                .Returns(userRepositoryMoq.Object);

            service = new UserService(repositoryWrapperMoq.Object);
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[]{new Customer() { Login = "",
                Password = "",
                LastName = "",
                FirstName = "",
                MiddleName = "",
                PhoneNumber = "",
                ZipCode = null,
                Region = "",
                City = "",
                Street = "",
                House = null,
                Flat = null,
                Age = 0,
                Gender = false,
                Deleted = false,}
                },
                new object[]{new Customer() { Login = "Test",
                Password = "",
                LastName = "",
                FirstName = "",
                MiddleName = "",
                PhoneNumber = "",
                ZipCode = null,
                Region = "",
                City = "",
                Street = "",
                House = null,
                Flat = null,
                Age = 0,
                Gender = false,
                Deleted = false,}
                },
                new object[]{new Customer() { Login = "Test",
                Password = "Test",
                LastName = "",
                FirstName = "",
                MiddleName = "",
                PhoneNumber = "",
                ZipCode = null,
                Region = "",
                City = "",
                Street = "",
                House = null,
                Flat = null,
                Age = 0,
                Gender = false,
                Deleted = false,}
                },
                new object[]{new Customer() { Login = "Test",
                Password = "Test",
                LastName = "Test",
                FirstName = "",
                MiddleName = "",
                PhoneNumber = "",
                ZipCode = null,
                Region = "",
                City = "",
                Street = "",
                House = null,
                Flat = null,
                Age = 0,
                Gender = false,
                Deleted = false,}
                },
                new object[]{new Customer() { Login = "Test",
                Password = "Test",
                LastName = "Test",
                FirstName = "Test",
                MiddleName = "",
                PhoneNumber = "",
                ZipCode = null,
                Region = "",
                City = "",
                Street = "",
                House = null,
                Flat = null,
                Age = 0,
                Gender = false,
                Deleted = false,}
                },
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Customer>()), Times.Never);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser()
        {
            var newUser = new Customer()
            {
                Login = "",
                Password = "",
                LastName = "",
                FirstName = "",
                MiddleName = "",
                PhoneNumber = "",
                ZipCode = null,
                Region = "",
                City = "",
                Street = "",
                House = null,
                Flat = null,
                Age = 0,
                Gender = false,
                Deleted = false,
            };

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Customer>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var newUser = new Customer()
            {
                Login = "swq",
                Password = "wqs",
                LastName = "wqs",
                FirstName = "sqw",
                MiddleName = "sqw",
                PhoneNumber = "edw",
                ZipCode = 123,
                Region = "VFCDA",
                City = "CD",
                Street = "vfc",
                House = 23,
                Flat = 2,
                Age = 12,
                Gender = true,
                Deleted = true,
            };

            await service.Create(newUser);

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Customer>()), Times.Once);
        }
    }
}
