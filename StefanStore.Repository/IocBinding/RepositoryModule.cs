using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using StefanStore.Domain.Abstract.UnitOfWork;
using StefanStore.Domain.Concrete.UnitOfWork;
using StefanStore.Infrastructure;

namespace StefanStore.Domain.IocBinding
{
    public class RepositoryModule : IAppModule
    {
        public void Bind(IBinder binder)
        {
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Products.GetAll()).Returns(new List<Product>
            {
                new Product {Name = "Table", Price = 25},
                new Product {Name = "Ball", Price = 179},
                new Product {Name = "Chair", Price = 95}
            }.AsQueryable());

            binder.BindToConstant<IUnitOfWork, IUnitOfWork>(mock.Object);
        }
    }
}