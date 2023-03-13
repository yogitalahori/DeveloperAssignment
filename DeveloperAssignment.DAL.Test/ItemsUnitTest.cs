using DeveloperAssignment.DAL.Contracts;
using DeveloperAssignment.DAL.Data;
using DeveloperAssignment.DAL.Models;
using DeveloperAssignment.DAL.Repositories;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Xunit.Sdk;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeveloperAssignment.DAL.Test
{
    [TestClass]
    public class ItemDALTests
    {
        private IRepository<ItemDTO> iRepository;

        private IEnumerable<ItemDTO> GetFakeData()
        {
            var i = 1;
            var items = A.ListOf<ItemDTO>(2);
            items.ForEach(x => x.ItemId = i++);
            return items.Select(_ => _);
        }

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DeveloperAssignmentDB").Options;

            //mock dbset
            var fakeData = GetFakeData().AsQueryable();
            var dbSet = new Mock<DbSet<ItemDTO>>();

            dbSet.As<IQueryable<ItemDTO>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            dbSet.As<IQueryable<ItemDTO>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            dbSet.As<IQueryable<ItemDTO>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            dbSet.As<IQueryable<ItemDTO>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            var appDbContextMock = new Mock<ApplicationDbContext>(options);
            appDbContextMock.Setup(c => c.Items).Returns(dbSet.Object);

            iRepository = new ItemRepository(appDbContextMock.Object);
        }

        [TestMethod]
        public void CheckItemsListNotNull()
        {
            Setup();
            var items = iRepository.GetAll();

            Assert.IsNotNull(items);
        }

        [TestMethod]
        public void CheckItemsListCount()
        {
            Setup();
            var items = iRepository.GetAll();

            Assert.IsTrue(items.Count() >= 0);
        }
    }
}