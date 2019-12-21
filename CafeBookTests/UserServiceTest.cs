using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CafeBook.Models;
using CafeBook.Repositories;
using CafeBook.Services;
using Moq;
using Xunit;

namespace CafeBookTests
{
    public class UserServiceTest
    {
        [Fact]
        public async Task AddAndSaveTest()
        {
            var fakeRepo = Mock.Of<IUserRepository>();
            var userService = new UserService(fakeRepo);
            var user = new User { Id = "1", Login = "qwer", Password = "qwer" };
            await userService.AddAndSave(user);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var fakeRepo = Mock.Of<IUserRepository>();
            var userService = new UserService(fakeRepo);
            var user = new User { Id = "1", Login = "qwer", Password = "qwer" };
            await userService.Update(user);
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepo = Mock.Of<IUserRepository>();
            var userService = new UserService(fakeRepo);
            var user = new User { Id = "1", Login = "qwer", Password = "qwer" };
            await userService.Delete(user);
        }

        [Fact]
        public async Task GetUsers()
        {
            var users = new List<User>
            {
                new User{Id = "1", Login = "qwer", Password = "qwer" },
                new User{Id = "2", Login = "qwerty", Password = "qwerty" }
            };

            var fakeRepo = new Mock<IUserRepository>();
            fakeRepo.Setup(x => x.GetAllUser()).ReturnsAsync(users);

            var userService = new UserService(fakeRepo.Object);
            var resultUsers = await userService.GetAllUser();

            Assert.Collection(resultUsers, user =>
            {
                Assert.Equal("qwer", user.Login);
            },
            user =>
            {
                Assert.Equal("qwerty", user.Login);
            });
        }
    }
}
