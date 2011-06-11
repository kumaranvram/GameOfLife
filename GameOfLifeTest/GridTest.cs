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
        public void ToStringTest1()
        {
            Grid target = new Grid("X X\nX X"); // TODO: Initialize to an appropriate value
            string expected = "X X\nX X\n";
            string actual;
            target.AdvanceToNextGeneration();
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest2()
        {
            Grid target = new Grid("X X -\nX - X\n- X -"); // TODO: Initialize to an appropriate value
            string expected = "X X -\nX - X\n- X -\n";
            string actual;
            target.AdvanceToNextGeneration();
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest3()
        {
            Grid target = new Grid("- X -\n- X -\n- X -"); // TODO: Initialize to an appropriate value
            string expected = "- - -\nX X X\n- - -\n";
            string actual;
            target.AdvanceToNextGeneration();
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest4()
        {
            Grid target = new Grid("- X X X\nX X X -");
            string expected = "- - X -\nX - - X\nX - - X\n- X - -\n";
            string actual;
            target.AdvanceToNextGeneration();
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest5()
        {
            Grid target = new Grid("X X X - X\nX - X - X\nX X X - X"); // TODO: Initialize to an appropriate value
            string expected = "- - X - - - -\n- X - X - - -\nX - - - - X X\n- X - X - - -\n- - X - - - -\n"; // TODO: Initialize to an appropriate value
            string actual;
            target.AdvanceToNextGeneration();
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest6()
        {
            Grid target = new Grid("X X X\nX X X\nX X X\n"); // TODO: Initialize to an appropriate value
            string expected = "- - X - -\n- X - X -\nX - - - X\n- X - X -\n- - X - -\n";
            string actual;
            target.AdvanceToNextGeneration();
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest7()
        {
            Grid target = new Grid("- X -\nX - X\n- X -\n"); // TODO: Initialize to an appropriate value
            string expected = "- X -\nX - X\n- X -\n";
            string actual;
            target.AdvanceToNextGeneration();
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsNewColumnNeededAtRight
        ///</summary>
        [TestMethod()]
        [DeploymentItem("GameOfLife.exe")]
        public void IsNewColumnNeededAtRightTest()
        {            
            Grid_Accessor target = new Grid_Accessor(); // TODO: Initialize to an appropriate value
            target.LoadPattern("X X X\nX X X\nX X X");
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;            
            actual = target.IsNewColumnNeededAtRight();
            Assert.AreEqual(expected, actual);                     
        }

        /// <summary>
        ///A test for IsNewColumnNeededAtRight
        ///</summary>
        [TestMethod()]
        [DeploymentItem("GameOfLife.exe")]
        public void IsNewColumnNeededAtRightTest1()
        {
            Grid_Accessor target = new Grid_Accessor(); // TODO: Initialize to an appropriate value
            target.LoadPattern("- X -\nX - X\n- X -");
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsNewColumnNeededAtRight();
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        ///A test for IsNewColumnNeededAtLeft
        ///</summary>
        [TestMethod()]
        [DeploymentItem("GameOfLife.exe")]
        public void IsNewColumnNeededAtLeftTest()
        {
            Grid_Accessor target = new Grid_Accessor(); // TODO: Initialize to an appropriate value
            target.LoadPattern("X X X\nX X X\nX X X");
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsNewColumnNeededAtLeft();
            Assert.AreEqual(expected, actual);            
        }

        /// <summary>
        ///A test for IsNewColumnNeededAtLeft
        ///</summary>
        [TestMethod()]
        [DeploymentItem("GameOfLife.exe")]
        public void IsNewColumnNeededAtLeftTest1()
        {
            Grid_Accessor target = new Grid_Accessor(); // TODO: Initialize to an appropriate value
            target.LoadPattern("- X -\nX - X\n- X -");
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsNewColumnNeededAtLeft();
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        ///A test for Grid Constructor
        ///</summary>
        [TestMethod()]
        public void GridConstructorTest1()
        {
            string pattern = "X -\n- X\n"; // TODO: Initialize to an appropriate value
            Grid target = new Grid(pattern);
            string actual = target.ToString();
            Assert.AreEqual(pattern, actual);
        }
    }
}
