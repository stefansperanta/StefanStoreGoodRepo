using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StefanStore.Domain;
using StefanStore.Repository.Abstract.UnitOfWork;
using StefanStore.Service;

namespace StefanStore.UnitTests2
{
    //[TestClass]
    //public class ProductServiceTests
    //{
    //    private Mock<IUnitOfWork> _testsSetup;

    //    [TestMethod]
    //    public void Can_Page()
    //    {
    //        //Arrange
    //        var mockUow = TestsSetup();

    //        ProductService productService = new ProductService(mockUow.Object);
    //        int pageSize = 3;
    //        // Act
    //        IEnumerable<Product> result = (IEnumerable<Product>)productService.GetPagedProducts(null,pageSize, 2);
    //        // Assert
    //        Product[] prodArray = result.ToArray();
    //        Assert.IsTrue(prodArray.Length == 2);
    //        Assert.AreEqual(prodArray[0].Name, "P4");
    //        Assert.AreEqual(prodArray[1].Name, "P5");
    //    }

    //    [TestMethod]
    //    public void Can_GetProducts()
    //    {
    //        // Arrange
    //        var mockUow = TestsSetup();

    //        ProductService productService = new ProductService(mockUow.Object);

    //        // Act
    //        IEnumerable<Product> result = (IEnumerable<Product>)productService.GetAllProducts();

    //        // Assert
    //        Product[] prodArray = result.ToArray();
    //        Assert.IsTrue(prodArray.Length == 5);
    //        Assert.AreEqual(prodArray[0].Name, "P1");
    //        Assert.AreEqual(prodArray[1].Name, "P2");
    //    }

    //    private Mock<IUnitOfWork> TestsSetup()
    //    {
    //        _testsSetup = new Mock<IUnitOfWork>();
    //        _testsSetup.Setup(m => m.Products.GetAll()).Returns(new List<Product>
    //        {
    //            new Product {ProductID = 1, Name = "P1"},
    //            new Product {ProductID = 2, Name = "P2"},
    //            new Product {ProductID = 3, Name = "P3"},
    //            new Product {ProductID = 4, Name = "P4"},
    //            new Product {ProductID = 5, Name = "P5"}
    //        }.AsQueryable());
    //        return _testsSetup;
    //    }
    //}
}