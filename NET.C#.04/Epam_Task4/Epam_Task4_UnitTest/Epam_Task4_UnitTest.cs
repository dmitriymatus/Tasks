using System;
using Epam_Task4_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epam_Task4_UnitTest
{
   [TestClass]
   public class Epam_Task4_UnitTest
   {
      /// <summary>
      /// Тест для проверки метода вычисления площади треугольника
      /// </summary>
      [TestMethod]
      public void TestMethod1()
      {
         Triangle a = new Triangle(1,1,5,4,5,1);
         int answer = 6;
         Assert.AreEqual(a.Square(), answer);
      }

      /// <summary>
      /// Тест для проверки метода вычисления периметра треугольника
      /// </summary>
      [TestMethod]
      public void TestMethod2()
      {
         Triangle a = new Triangle(1,1,5,4,5,1);
         int answer = 12;
         Assert.AreEqual(a.Perimeter(), answer);
      }

      /// <summary>
      /// Тест для проверки метода который проверяет существование треугольника
      /// </summary>
      [TestMethod]
      public void TestMethod3()
      {
         Triangle a = new Triangle(1,1,5,4,5,1);
         Assert.IsNotNull(a);
      }
   }
}
