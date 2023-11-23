using NUnit.Framework;
using MMABooksBusinessClasses;
using System;

namespace MMABooksTests
{
    [TestFixture]
    public class StateTests
    {

        [Test]
        public void Test1()
        {
            int expected = 5;
            Assert.AreEqual(expected, 3 + 2);
        }

        [Test]
        public void TestStateConstructor()
        {
            State state1 = new State();
            Assert.IsNotNull(state1);
            Assert.AreEqual(null, state1.StateCode);
            Assert.AreEqual(null, state1.StateName);

            string newCode = "OR";
            string newName = "Oregon";
            State state2 = new State(newCode, newName);
            Assert.IsNotNull(state2);
            Assert.AreEqual(newCode, state2.StateCode);
            Assert.AreEqual(newName, state2.StateName);
        }

        [Test]
        public void TestStateSetters()
        {
            State state1 = new State("NY", "New York");
            string newCode = "OR";
            string newName = "Oregon";
        
            state1.StateCode = newCode;
            state1.StateName = newName;
        
            Assert.AreEqual(newCode, state1.StateCode);
            Assert.AreEqual(newName, state1.StateName);
       
            newCode = "CA";
            newName = "California";
            state1.StateCode = newCode;
            state1.StateName = newName;
            Assert.AreEqual(newCode, state1.StateCode);
            Assert.AreEqual(newName, state1.StateName);
        }

        [Test]
        public void TestStateGetters()
        {
           
        }  

        [Test]
        public void TestStateToString()
        {
            State state1 = new State("NY", "New York");
            Assert.IsTrue(state1.ToString().Contains("NY"));
            Assert.IsTrue(state1.ToString().Contains("New York"));
        }


      
        private State state;

        [SetUp]
        public void SetUp()
        {
            state = new State("NY", "New York");
        }

        [Test]
        public void TestSettersInvalidValueTryCatch()
        {
            try
            {
                state.StateCode = "123";
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.Pass("If the exception IS thrown, the property IS doing the right thing.");
            }
        }

        [Test]
        public void TestSettersInvalidValueThrows()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => state.StateCode = "123");
        }
    }
}