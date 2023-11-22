using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests {
    [TestFixture]
    public class ProductDBTests {
        // I wasn't sure if I was suppose to use this, so I left it blank
        [SetUp]
        public void SetUp() { }

        [Test]
        public void TestGetProduct() {
            Product p = ProductDB.GetProduct("ADV4");
            Assert.AreEqual("ADV4", p.ProductCode);
        }

        [Test]
        public void TestCreateProduct() {
            Product productNew = new("ZZZ1", "Book 1", 10.0000m, 123);
            string addedProduct = ProductDB.AddProduct(productNew);
            Product referencedProduct = ProductDB.GetProduct(addedProduct);
            Assert.AreEqual("ZZZ1", referencedProduct.ProductCode);
        }

        [Test]
        public void TestRemoveProduct() {
            Product productNew = new() {
                ProductCode = "ZZZ2",
                Description = "Book 2",
                UnitPrice = 20.0000m,
                OnHandQuantity = 456,
            };
            bool deletedProduct = ProductDB.DeleteProduct(productNew);
            if (deletedProduct == false) {
                Product getProduct = ProductDB.GetProduct(productNew.ProductCode);
                Assert.AreEqual(null, getProduct);
            }
        }

        [Test]
        public void TestChangeProduct() {
            // Version #0
            Product productOriginal = new("ZZZ3", "Book 3", 30.0000m, 789);
            string addedProductOrignal = ProductDB.AddProduct(productOriginal);
            // Version #1
            Product productUpdated = new(addedProductOrignal, "Book 4", 40.0000m, 1011);
            bool updatedProduct = ProductDB.UpdateProduct(productOriginal, productUpdated);
            if (updatedProduct == false) {
                Product referencedProduct = ProductDB.GetProduct(addedProductOrignal);
                Assert.AreEqual("Book 4", referencedProduct.Description);
            }
        }
    }
}
