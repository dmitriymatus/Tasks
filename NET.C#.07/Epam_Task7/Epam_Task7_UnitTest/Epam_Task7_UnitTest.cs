using System;
using Epam_Task7_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epam_Task7_UnitTest
{
   [TestClass]
   public class Epam_Task7_UnitTest
   {

      [TestMethod]
      [ExpectedException(typeof(System.ArgumentException))]
      public void Test1()
      {
         MatrixClass a = new MatrixClass(0,0,1,1,1,2,3);
      }

      [TestMethod]
      [ExpectedException(typeof(System.ArgumentException))]
      public void Test2()
      {
         MatrixClass a = new MatrixClass(2, 2, 1, 1);
      }

      [TestMethod]
      [ExpectedException(typeof(System.ArgumentException))]
      public void CompareToTest1()
      {
         MatrixClass a = new MatrixClass(2, 2, 1, 1, 1, 2);
         a.CompareTo("Hello world");
      }

      [TestMethod]
      public void CompareToTest2()
      {
         MatrixClass a = new MatrixClass(2, 2, 1, 1, 1, 2);
         MatrixClass b = new MatrixClass(2, 2, 1, 1, 1, 2);
         Assert.AreEqual(0, a.CompareTo(b));
      }


      [TestMethod]
      [ExpectedException(typeof(MatrixException))]
      public void OperatorTest1()
      {
         MatrixClass a = new MatrixClass(2, 3, 1, 1, 1, 2, 2, 5);
         MatrixClass b = new MatrixClass(4, 2, 1, 1, 1, 2, 9, 8, 7, 6);
         MatrixClass c = a * b;
      }


      [TestMethod]
      [ExpectedException(typeof(MatrixException))]
      public void InverseMatrixTest()
      {
         MatrixClass a = new MatrixClass(2, 3, 1, 1, 1, 2, 2, 5);
         MatrixClass c = MatrixClass.InverseMatrix(a);
      }
   }
}
