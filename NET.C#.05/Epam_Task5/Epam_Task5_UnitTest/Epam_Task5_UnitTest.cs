using System;
using Epam_Task5_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epam_Task5_UnitTest
{
   [TestClass]
   public class Epam_Task5_UnitTest
   {
      [TestMethod]
      public void indexTest1()
      {
         MyVector a = new MyVector(5, 6, 7);
         double answer = 6;
         Assert.AreEqual(a[1], answer);
      }

      [TestMethod]
      [ExpectedException(typeof(System.Exception))]
      public void indexTest2()
      {
         MyVector a = new MyVector(5, 6, 7);
         double n = a[3];
      }

      [TestMethod]
      public void operatorTest1()
      {
         MyVector a = new MyVector(5, 6, 7);
         MyVector b = new MyVector(2, 3, 4);
         MyVector answer = new MyVector(7,9,11);
         MyVector c = a + b;
         Assert.AreEqual(c[0], answer[0]);
         Assert.AreEqual(c[1], answer[1]);
         Assert.AreEqual(c[2], answer[2]);
      }

      [TestMethod]
      public void operatorTest2()
      {
         MyVector a = new MyVector(5, 6, 7);
         MyVector b = new MyVector(2, 3, 4);
         MyVector answer = new MyVector(3, 3, 3);
         MyVector c = a - b;
         Assert.AreEqual(c[0], answer[0]);
         Assert.AreEqual(c[1], answer[1]);
         Assert.AreEqual(c[2], answer[2]);
      }


      [TestMethod]
      public void operatorTest3()
      {
         MyVector a = new MyVector(5, 6, 7);
         MyVector b = new MyVector(2, 3, 4);
         MyVector answer = new MyVector(3, -6, 3);
         MyVector c = a * b;
         Assert.AreEqual(c[0], answer[0]);
         Assert.AreEqual(c[1], answer[1]);
         Assert.AreEqual(c[2], answer[2]);
      }


      [TestMethod]
      public void operatorTest4()
      {
         MyVector a = new MyVector(1, 2, 3);
         MyVector b = new MyVector(1, 2, 3);
         double answer = 0;
         double c = a ^ b;
         Assert.AreEqual(c, answer);
      }
   }
}
