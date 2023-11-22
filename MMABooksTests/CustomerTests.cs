using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests {
    [TestFixture]
    public class CustomerTests {
        [Test]
        public void Test1() {
            int expected = 5;
            Assert.AreEqual(expected, 3 + 2);
        }

        [Test]
        public void TestCustomerConstructor() {
            // Customer #1
            Customer customer1 = new();
            Assert.IsNotNull(customer1);
            Assert.AreEqual(0, customer1.CustomerID);
            Assert.AreEqual(null, customer1.Name);
            Assert.AreEqual(null, customer1.Address);
            Assert.AreEqual(null, customer1.City);
            Assert.AreEqual(null, customer1.State);
            Assert.AreEqual(null, customer1.ZipCode);
            // Customer #2
            int newID = 1;
            string newName = "John Doe";
            string newAddress = "Oregon";
            string newCity = "Eugene";
            string newState = "OR";
            string newZipCode = "97405";
            Customer customer2 = new(newID, newName, newAddress, newCity, newState, newZipCode);
            Assert.IsNotNull(customer2);
            Assert.AreEqual(newID, customer2.CustomerID);
            Assert.AreEqual(newName, customer2.Name);
            Assert.AreEqual(newAddress, customer2.Address);
            Assert.AreEqual(newCity, customer2.City);
            Assert.AreEqual(newState, customer2.State);
            Assert.AreEqual(newZipCode, customer2.ZipCode);
        }

        [Test]
        public void TestCustomerSetters() {
            // Version #0
            Customer customer = new(0, "John Smith", "New York", "Buffalo", "NY", "14201");
            // Version #1
            int newID = 1;
            string newName = "John Doe";
            string newAddress = "Oregon";
            string newCity = "Eugene";
            string newState = "OR";
            string newZipCode = "97405";
            customer.CustomerID = newID;
            customer.Name = newName;
            customer.Address = newAddress;
            customer.City = newCity;
            customer.State = newState;
            customer.ZipCode = newZipCode;
            Assert.AreEqual(newID, customer.CustomerID);
            Assert.AreEqual(newName, customer.Name);
            Assert.AreEqual(newAddress, customer.Address);
            Assert.AreEqual(newCity, customer.City);
            Assert.AreEqual(newState, customer.State);
            Assert.AreEqual(newZipCode, customer.ZipCode);
            // Version #2
            newID = 2;
            newName = "Jane Doe";
            newAddress = "California";
            newCity = "San Diego";
            newState = "CA";
            newZipCode = "91911";
            customer.CustomerID = newID;
            customer.Name = newName;
            customer.Address = newAddress;
            customer.City = newCity;
            customer.State = newState;
            customer.ZipCode = newZipCode;
            Assert.AreEqual(newID, customer.CustomerID);
            Assert.AreEqual(newName, customer.Name);
            Assert.AreEqual(newAddress, customer.Address);
            Assert.AreEqual(newCity, customer.City);
            Assert.AreEqual(newState, customer.State);
            Assert.AreEqual(newZipCode, customer.ZipCode);
        }

        // Omitting function body because of information in StateTests.cs regarding getters
        [Test]
        public void TestCustomerGetters() { }

        [Test]
        public void TestCustomerToString() {
            Customer customer = new(0, "John Smith", "New York", "Buffalo", "NY", "14201");
            Assert.IsTrue(customer.ToString().Contains("NY"));
            Assert.IsTrue(customer.ToString().Contains("New York"));
            // Check Test Explorer console for output, not terminal console
            Console.WriteLine(customer);
        }

        private Customer? customer;

        [SetUp]
        public void SetUp() => customer = new(0, "John Smith", "New York", "Buffalo", "NY", "14201");

        [Test]
        public void TestSettersInvalidValueTryCatch() {
            // Customer id
            try {
                customer.CustomerID = -1;
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException) { Assert.Pass("If the exception IS thrown, the property IS doing the right thing."); }
            //State
            try {
                customer.State = "ABC";
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException) { Assert.Pass("If the exception IS thrown, the property IS doing the right thing."); }
            // ZIP code
            try {
                customer.ZipCode = "123";
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException) { Assert.Pass("If the exception IS thrown, the property IS doing the right thing."); }
        }

        [Test]
        public void TestSettersInvalidValueThrows() {
            // Customer id
            Assert.Throws<ArgumentOutOfRangeException>(() => customer.CustomerID = -1);
            // State
            Assert.Throws<ArgumentOutOfRangeException>(() => customer.State = "ABC");
            // ZIP code
            Assert.Throws<ArgumentOutOfRangeException>(() => customer.ZipCode = "123");
        }
    }
}
