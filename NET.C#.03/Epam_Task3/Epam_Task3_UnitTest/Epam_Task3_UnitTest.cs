using System;
using Epam_Task3_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epam_Task3_UnitTest
{
   [TestClass]
   public class Epam_Task3_UnitTest
   {
      [TestMethod]
      public void EuclideanAlgorithmTest1()
      {
         // arrange
         int firstValue = 1071;
         int secondValue = 462;
         int answer = 21;
         int b = 0;
         double time;
         //act
         b = GCDSearch.EuclideanAlgorithm(out time, firstValue, secondValue);
         // assert
         Assert.AreEqual(b, answer);
      }

      [TestMethod]
      public void EuclideanAlgorithmTest2()
      {
         // arrange
         int firstValue = 78;
         int secondValue = 294;
         int c = 570;
         int d = 36;
         int answer = 6;
         int b = 0;
         double time;
         //act
         b = GCDSearch.EuclideanAlgorithm(out time, firstValue, secondValue, c, d);
         // assert
         Assert.AreEqual(b, answer);
      }

      [TestMethod]
      public void BinaryGCDAlgorithmTest()
      {
         // arrange
         int firstValue =  1071;
         int secondValue = 462;
         int answer = 21;
         int b = 0;
         double time;
         //act
         b = GCDSearch.BinaryGCDAlgorithm(out time, firstValue, secondValue);
         // assert
         Assert.AreEqual(b, answer);
      }

      [TestMethod]
      public void BinaryGCDAlgorithmTest2()
      {
         // arrange
         int firstValue = 78;
         int secondValue = 294;
         int c = 570;
         int d = 36;
         int answer = 6;
         int b = 0;
         double time;
         //act
         b = GCDSearch.BinaryGCDAlgorithm(out time, firstValue, secondValue, c, d);
         // assert
         Assert.AreEqual(b, answer);
      }

   }
}
