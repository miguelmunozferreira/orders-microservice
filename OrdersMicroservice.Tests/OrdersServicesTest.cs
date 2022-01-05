using Moq;
using NUnit.Framework;
using OrdersMicroservice.Core.Domain;
using OrdersMicroservice.Core.Interfaces;
using OrdersMicroservice.Core.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OrdersMicroservice.Tests
{
    [TestFixture]
    public class OrdersServiceTests
    {
        private readonly Mock<IOrdersRespository> ordersRepository;
        private readonly OrdersService service;
        public OrdersServiceTests()
        {
            this.ordersRepository = new Mock<IOrdersRespository>();
            this.service = new OrdersService(ordersRepository.Object);
        }

        [Test]
        public async Task IfOrderIdIsEmpty_GetOrder_ShouldReturnFalse()
        {
            var result = await service.GetOrder(Guid.NewGuid());

            Assert.Null(result);
        }

        [Test]
        public async Task IfEverythingIsOk_GetOrder_ShouldReturnAnOrder()
        {
            var order = new Order { Id = Guid.NewGuid(), Amount = 0, UserId = Guid.NewGuid() };
            ordersRepository.Setup(x => x.GetOrder(It.IsAny<Guid>())).ReturnsAsync(order);

            var result = await service.GetOrder(Guid.NewGuid());

            Assert.AreEqual(order, result);
        }

        [Test]
        public async Task IfOrderIdIsEmpty_CreateOrder_ShouldReturnNull()
        {
            var order = new Order { Id = Guid.Empty, Amount = 0, UserId = Guid.NewGuid() };

            var result = await service.CreateOrder(order);

            Assert.Null(result);
        }

        [Test]
        public async Task IfAmountLessThanZero_CreateOrder_ShouldReturnNull()
        {
            var order = new Order { Id = Guid.NewGuid(), Amount = -1, UserId = Guid.NewGuid() };

            var result = await service.CreateOrder(order);

            Assert.Null(result);
        }

        [Test]
        public async Task IfEverythingIsOk_CreateOrder_ShouldReturnAnOrder()
        {
            var order = new Order { Id = Guid.Empty, Amount = 0, UserId = Guid.NewGuid() };
            ordersRepository.Setup(x => x.CreateOrder(It.IsAny<Order>())).ReturnsAsync(order);

            var result = await service.CreateOrder(order);

            Assert.AreEqual(order, result);
        }

        [Test]
        public async Task IfOrderIdIsEmpty_DeleteOrder_ShouldReturnFalse()
        {
            var result = await service.DeleteOrder(Guid.NewGuid());

            Assert.False(result);
        }

        [Test]
        public async Task IfEverythingIsOk_DeleteOrder_ShouldReturnTrue()
        {
            ordersRepository.Setup(x => x.DeleteOrder(It.IsAny<Guid>())).ReturnsAsync(true);

            var result = await service.DeleteOrder(Guid.NewGuid());

            Assert.True(result);
        }

        [Test]
        public async Task IfAmountLessThanZero_UpdateOrder_ShouldReturnFalse()
        {
            var order = new Order { Id = Guid.NewGuid(), Amount = -1, UserId = Guid.NewGuid() };

            var result = await service.UpdateOrder(order);

            Assert.False(result);
        }

        [Test]
        public async Task IfOrderIdIsEmpty_UpdateOrder_ShouldReturnFalse()
        {
            var order = new Order { Id = Guid.Empty, Amount = 0, UserId = Guid.NewGuid() };

            var result = await service.UpdateOrder(order);

            Assert.False(result);
        }

        [Test]
        public async Task IfUserIdIsEmpty_UpdateOrder_ShouldReturnFalse()
        {
            var order = new Order { Id = Guid.NewGuid(), Amount = 0, UserId = Guid.Empty };

            var result = await service.UpdateOrder(order);

            Assert.False(result);
        }

        [Test]
        public async Task IfEverythingIsOk_UpdateOrder_ShouldReturnTrue()
        {
            var order = new Order { Id = Guid.NewGuid(), Amount = 0, UserId = Guid.NewGuid() };
            ordersRepository.Setup(x => x.UpdateOrder(It.IsAny<Order>())).ReturnsAsync(true);

            var result = await service.UpdateOrder(order);

            Assert.True(result);
        }
    }
}