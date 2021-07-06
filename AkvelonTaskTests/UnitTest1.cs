using AkvelonTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AkvelonTaskTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidBalanceVerificator_IsBalancedBracketsString_ReturnMinusOne() {

            //Arrange
            BalanceVerificator verificator = new BalanceVerificator();

            //Act
            int result = verificator.IsBalancedBracketsString("{[()[]]}");

            //Assert
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void ValidBalanceVerificator_IsBalancedBracketsString_ReturnThree()
        {

            //Arrange
            BalanceVerificator verificator = new BalanceVerificator();

            //Act
            int result = verificator.IsBalancedBracketsString("{[([]]}");

            //Assert
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void ValidBalanceVerificator_IsBalancedBracketsString_ReturnTwo()
        {

            //Arrange
            BalanceVerificator verificator = new BalanceVerificator();

            //Act
            int result = verificator.IsBalancedBracketsString("{[}]");

            //Assert
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void ValidBalanceVerificator_UpdateGradationData_MinusTwo()
        {

            //Arrange
            BalanceVerificator verificator = new BalanceVerificator();

            //Act
            int result = verificator.IsBalancedBracketsString("{a[]a}");

            //Assert
            Assert.AreEqual(result, -2);
        }

        [TestMethod]
        public void ValidBalanceVerificator_UpdateGradationData_ReturnOne()
        {

            //Arrange
            BalanceVerificator verificator = new BalanceVerificator();

            //Act
            int result = verificator.IsBalancedBracketsString("(((()))");

            //Assert
            Assert.AreEqual(result, 1);
        }
    }
}
