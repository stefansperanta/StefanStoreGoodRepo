using System.Collections.Generic;
using System.Linq;
using Moq;
using StefanStore.Domain;
using StefanStore.Infrastructure;
using StefanStore.Repository.Abstract.UnitOfWork;
using StefanStore.Repository.Concrete.UnitOfWork;

namespace StefanStore.Repository.IocBinding
{
    public class RepoModule : IAppModule
    {
        public void Bind(IBinder binder)
        {
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Products.GetAll()).Returns(new List<Product>
            {
                new Product {ProductID=1,Name = "Table", Price = 25, Category="Kitchen"},
                new Product {ProductID=2,Name = "Ball", Price = 179,Category = "Outside"},
                new Product {ProductID=3,Name = "Oven", Price = 95, Category="Kitchen"},
                new Product {ProductID=4,Name = "KeyBoard", Price = 10,Category = "Office"},
                new Product {ProductID=5,Name = "Phone", Price = 20,Category = "Office"},
                new Product {ProductID=6,Name = "Mouse", Price = 45,Category = "Office"},
                new Product {ProductID=7,Name = "TV", Price = 34, Category = "Office"},
                new Product {ProductID=8,Name = "Glass", Price = 47,Category = "Kitchen"},
                new Product {ProductID=9,Name = "Plate", Price = 88, Category="Kitchen"},
                new Product {ProductID=10,Name = "Fork", Price = 44, Category="Kitchen"},
                new Product {ProductID=11,Name = "Knife", Price = 66, Category ="Kitchen"}
            }.AsQueryable());

            //binder.BindToConstant<IUnitOfWork, IUnitOfWork>(mock.Object);
            binder.Bind<IUnitOfWork, StefanStoreUow>();
        }
    }
}