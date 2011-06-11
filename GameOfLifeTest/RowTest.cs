using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameOfLifeTest
{
    
    
    /// <summary>
    ///This is a test class for RowTest and is intended
    ///to contain all RowTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RowTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Row target = new Row("X\tX\tX\n"); // TODO: Initialize to an appropriate value
            string expected = "X\tX\tX\n"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Row Constructor
        ///</summary>
        [TestMethod()]
        public void RowConstructorTest()
        {
            Row target = new Row("X\t-\tX\n");
            string expected = "X\t-\tX\n"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetColumnCount
        ///</summary>
        [TestMethod()]
        public void GetColumnCountTest()
        {
            Row target = new Row("X\t-\tX\n"); // TODO: Initialize to an appropriate value
            int expected = 3; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetColumnCount();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsNewRowNeeded
        ///</summary>
        [TestMethod()]
        public void IsNewRowNeededTest()
        {
            Row target = new Row("X\tX\tX\t-\n"); // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsNewRowNeeded();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
