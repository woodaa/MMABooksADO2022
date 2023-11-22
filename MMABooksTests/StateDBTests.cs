﻿using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

using MySql.Data.MySqlClient;

namespace MMABooksTests
{
    [TestFixture]
    public class StateDBTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void TestGetStates()
        {
            List<State> states = StateDB.GetStates();
            Assert.AreEqual(53, states.Count);
            Assert.AreEqual("Alabama", states[0].StateName);
        }

        /*
         Reference on why this is commented out - https://classes.lanecc.edu/mod/forum/discuss.php?d=943774
         
         As I and another student pointed out in the linked thread, we're not sure why this function/method/test even exists among the starter files, as the classes diagram for this lab doesn't even include/require it
         */
        //[Test]
        //public void TestGetStatesDBUnavailable()
        //{
        //    Assert.Throws<MySqlException>(() => StateDB.GetStates());
        //}
    }
}
