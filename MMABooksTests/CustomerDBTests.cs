using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests {
    [TestFixture]
    public class CustomerDBTests {
       
        [SetUp]
        public void SetUp() { }

        [Test]
        public void TestGetCustomer() {
            Customer c = CustomerDB.GetCustomer(1);
            Assert.AreEqual(1, c.CustomerID);
        }

        [Test]
        public void TestCreateCustomer() {
            Customer customerNew = new() {
                Name = "Mickey Mouse",
                Address = "101 Main Street",
                City = "Orlando",
                State = "FL",
                ZipCode = "10101"
            };
            int addedCustomer = CustomerDB.AddCustomer(customerNew);
            Customer referencedCustomer = CustomerDB.GetCustomer(addedCustomer);
            Assert.AreEqual("Mickey Mouse", referencedCustomer.Name);
            Console.WriteLine(addedCustomer);
        }

        [Test]
        public void TestChangeCustomer() {
            /*
                Version #0

                If "700" isn't the custom ID for the newly created customer(s), reset the "MMABooks" DB or replace "700" with the correct IDs, otherwise everything used within this test will break

                If we were trying to find the last added customer in raw SQL, we could simply do:
                    SELECT *
                    FROM customers
                    ORDER BY customerid DESC
                    LIMIT 1;
            */
            Customer customerOriginal = new(700, "John Doe", "Oregon", "Eugene", "OR", "97405");
            int addedCustomerOriginal = CustomerDB.AddCustomer(customerOriginal);
            // Version #1
            Customer customerUpdated = new(addedCustomerOriginal, "Jane Doe", "California", "San Diego", "CA", "91911");
            bool updatedCustomer = CustomerDB.UpdateCustomer(customerOriginal, customerUpdated);
            if (updatedCustomer == false) {
                Customer referencedCustomer = CustomerDB.GetCustomer(addedCustomerOriginal);
                Assert.AreEqual("Jane Doe", referencedCustomer.Name);
            }
        }

        [Test]
        public void TestRemoveCustomer() {
            Customer customerNew = new() {
                Name = "John Smith",
                Address = "New York",
                City = "Buffalo",
                State = "NY",
                ZipCode = "14201"
            };
            bool deletedCustomer = CustomerDB.DeleteCustomer(customerNew);
            if (deletedCustomer == false) {
                Customer getCustomer = CustomerDB.GetCustomer(customerNew.CustomerID);
                Assert.AreEqual(null, getCustomer);
            }
        }
    }
}
