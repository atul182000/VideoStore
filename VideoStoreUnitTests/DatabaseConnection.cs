using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Video_Store;

namespace VideoStoreUnitTests
{
    [TestClass]
    public class DatabaseConnectionTest
    {
        [TestMethod]
        public void ConnectionStateOpen_ReturnsTrue()
        {
            Authentication obj = new Authentication();
            bool val = obj.TestConnection;
            Assert.IsTrue(val);
        }
    }
}
