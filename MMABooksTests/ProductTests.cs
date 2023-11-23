using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests {
    [TestFixture]
    public class ProductTests {
        [Test]
        public void Test1() {
            int expected = 5;
            Assert.AreEqual(expected, 3 + 2);
        }

        [Test]
        public void TestProductConstructor() {
            // Product #1
            Product product1 = new();
            Assert.IsNotNull(product1);
            Assert.AreEqual(null, product1.ProductCode);
            Assert.AreEqual(null, product1.Description);
            Assert.AreEqual(0.0, product1.UnitPrice);
            Assert.AreEqual(0, product1.OnHandQuantity);
            // Product #2
            string newProductCode = "ABC1";
            string newDescription = "Book 1";
            decimal newUnitPrice = 0.1m;
            int newOnHandQuantity = 1234;
            Product product2 = new(newProductCode, newDescription, newUnitPrice, newOnHandQuantity);
            Assert.IsNotNull(product2);
            Assert.AreEqual(newProductCode, product2.ProductCode);
            Assert.AreEqual(newDescription, product2.Description);
            Assert.AreEqual(newUnitPrice, product2.UnitPrice);
            Assert.AreEqual(newOnHandQuantity, product2.OnHandQuantity);
        }

        [Test]
        public void TestProductSetters() {
            // Version #0
            Product product = new("ABC1", "Book 1", 0.1m, 1234);
            // Version #1
            string newProductCode = "DEF2";
            string newDescription = "Book 2";
            decimal newUnitPrice = 0.2m;
            int newOnHandQuantity = 5678;
            product.ProductCode = newProductCode;
            product.Description = newDescription;
            product.UnitPrice = newUnitPrice;
            product.OnHandQuantity = newOnHandQuantity;
            Assert.AreEqual(newProductCode, product.ProductCode);
            Assert.AreEqual(newDescription, product.Description);
            Assert.AreEqual(newUnitPrice, product.UnitPrice);
            Assert.AreEqual(newOnHandQuantity, product.OnHandQuantity);
            // Version #2
            newProductCode = "GHI3";
            newDescription = "Book 3";
            newUnitPrice = 0.3m;
            newOnHandQuantity = 9101;
            product.ProductCode = newProductCode;
            product.Description = newDescription;
            product.UnitPrice = newUnitPrice;
            product.OnHandQuantity = newOnHandQuantity;
            Assert.AreEqual(newProductCode, product.ProductCode);
            Assert.AreEqual(newDescription, product.Description);
            Assert.AreEqual(newUnitPrice, product.UnitPrice);
            Assert.AreEqual(newOnHandQuantity, product.OnHandQuantity);
        }

     
        [Test]
        public void TestProductGetters() { }

        [Test]
        public void TestProductToString() {
            Product product = new("ABC1", "Book 1", 0.1m, 1234);
            Assert.IsTrue(product.ToString().Contains('1'));
            Assert.IsTrue(product.ToString().Contains('A'));
            Console.WriteLine(product);
        }

        private Product product;

        [SetUp]
        public void SetUp() => product = new("ABC1", "Book 1", 0.1m, 1234);

        [Test]
        public void TestSettersInvalidValueTryCatch() {
            // Product code
            try {
                product.ProductCode = "DEFGH";
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException) { Assert.Pass("If the exception IS thrown, the property IS doing the right thing."); }
            // Unit price
            try {
                product.UnitPrice = 0.0m;
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException) { Assert.Pass("If the exception IS thrown, the property IS doing the right thing."); }
        }

        [Test]
        public void TestSettersInvalidValueThrows() {
            // Product code
            Assert.Throws<ArgumentOutOfRangeException>(() => product.ProductCode = "DEFGH");
            // Unit price
            Assert.Throws<ArgumentOutOfRangeException>(() => product.UnitPrice = 0.0m);
        }
    }
}
