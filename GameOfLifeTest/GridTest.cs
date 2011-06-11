using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameOfLifeTest
{
    
    
    /// <summary>
    ///This is a test class for GridTest and is intended
    ///to contain all GridTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GridTest
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
            Grid target = new Grid("X\tX\tX\t-\tX\nX\t-\tX\t-\tX\nX\tX\tX\t-\tX"); // TODO: Initialize to an appropriate value
            string expected = "-\t-\tX\t-\t-\t-\t-\n-\tX\t-\tX\t-\t-\t-\nX\t-\t-\t-\t-\tX\tX\n-\tX\t-\tX\t-\t-\t-\n-\t-\tX\t-\t-\t-\t-\n"; // TODO: Initialize to an appropriate value
            string actual;
            target.AdvanceToNextGeneration();
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }              

        /// <summary>
        ///A test for IsNewColumnNeededAtRight
        ///</summary>
        [TestMethod()]
        [DeploymentItem("GameOfLife.exe")]
        public void IsNewColumnNeededAtRightTest()
        {
            //Grid target = new Grid("X\tX\tX\t-\tX\nX\t-\tX\t-\tX\nX\tX\tX\t-\tX");
            Grid_Accessor target = new Grid_Accessor(); // TODO: Initialize to an appropriate value
            target.LoadPattern("X\tX\tX\t-\tX\nX\t-\tX\t-\tX\nX\tX\tX\t-\tX");
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;            
            actual = target.IsNewColumnNeededAtRight();
            Assert.AreEqual(expected, actual);                     
        }
        
        /*
        /// <summary>
        ///A test for IsNewColumnNeededAtLeft
        ///</summary>
        [TestMethod()]
        [DeploymentItem("GameOfLife.exe")]
        public void IsNewColumnNeededAtLeftTest()
        {
            Grid_Accessor target = new Grid_Accessor(); // TODO: Initialize to an appropriate value
            target.LoadPattern("X\tX\tX\nX\tX\tX\nX\tX\tX");
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsNewColumnNeededAtLeft();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
        */
        
        /// <summary>
        ///A test for Grid Constructor
        ///</summary>
        [TestMethod()]
        public void GridConstructorTest1()
        {
            string pattern = "X\t-\n-\tX\n"; // TODO: Initialize to an appropriate value
            Grid target = new Grid(pattern);
            string actual = target.ToString();
            Assert.AreEqual(pattern, actual);
        }
    }
}
