using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Video_Store;

namespace VideoStoreUnitTests
{
    [TestClass]
    public class RentedClassUnitTest
    {
        [TestMethod]
        public void GetListOfRentedMovies_HasRows_ReturnsObject()
        {
            MoviesRented obj = new MoviesRented();
            DataTable dataTable = obj.ListRented();
            Assert.IsNotNull(dataTable);
        }

    }
}
