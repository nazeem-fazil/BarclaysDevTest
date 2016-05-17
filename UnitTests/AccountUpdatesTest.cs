using CustomerProcessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class AccountUpdatesTest
    {
        [TestMethod]
        public void AccountUpdates_Constructor_LoadData_Correct()
        {
            // Arrange
            int expected = 2;
            string path = "AccountData";

            // Act
            var accountUpdates = AccountUpdates.CreateAccountUpdates(path);
            // Assert
            Assert.AreEqual(expected, accountUpdates.Accounts.Count);
        }

        [TestMethod]
        public void AccountUpdates_TotalCredit_LoadData_Correct()
        {
            // Arrange
            decimal expected = 21.33M;
            string path = "AccountData";

            // Act
            var accountUpdates = AccountUpdates.CreateAccountUpdates(path);

            // Assert
            Assert.AreEqual(expected, accountUpdates.TotalCredit);
        }
    }
}
