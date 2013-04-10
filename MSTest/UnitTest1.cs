using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Data;

using MacroScope;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void SmokeTest()
        {
            var obj = MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider);
        }

        [TestMethod]
        public void TestSelectStatement()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT activity_id, NOW()
FROM dbo.fv_activity");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            Assert.AreEqual(@"SELECT activity_id, GETDATE()
FROM fv_activity", stringifier.ToSql());
        }

        [TestMethod]
        public void TestSelectStatementWithParam()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT activity_id, NOW()
FROM dbo.fv_activity
WHERE engineer_id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            Assert.AreEqual(@"SELECT activity_id, GETDATE()
FROM fv_activity
WHERE engineer_id = $app.userid$", stringifier.ToSql());
        }

        [TestMethod]
        public void TestSelectStatementWithTop()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT TOP 10 id
FROM dbo.fv_activity");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            Assert.AreEqual(@"SELECT TOP(10) id
FROM fv_activity", stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementWithDay()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT DAY(GETDATE())");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            Assert.AreEqual(@"SELECT DATEPART(dd, GETDATE())", stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementWithMonth()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT MONTH(GETDATE())");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            Assert.AreEqual(@"SELECT DATEPART(mm, GETDATE())", stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementWithYear()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT YEAR(GETDATE())");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            Assert.AreEqual(@"SELECT DATEPART(yy, GETDATE())", stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementWithDatePartWeek()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT DATEPART(wk,GETDATE())");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            Assert.AreEqual(@"SELECT DATEPART(wk, GETDATE())", stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementWithDateAddWeekExpression()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT DATEADD(wk,1+1,GETDATE())");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            Assert.AreEqual(@"SELECT DATEADD(wk, 1 + 1, GETDATE())", stringifier.ToSql());
        }
    }
}
