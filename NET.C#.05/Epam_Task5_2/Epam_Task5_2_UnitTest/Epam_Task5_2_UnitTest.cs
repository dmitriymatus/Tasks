using System;
using Epam_Task5_2_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epam_Task5_2_UnitTest
{
   [TestClass]
   public class Epam_Task5_2_UnitTest
   {
      [TestMethod]
      public void IndexTest()
      {
         Multinomial prim = new Multinomial(1,2,3,4);
         int a = prim[2];
         Assert.AreEqual(a, 3);
      }

      [TestMethod]
      public void toStringTest()
      {
         Multinomial prim = new Multinomial(1, 2, 3, 4);
         string a = "1X(3)+2X(2)+3X+4";
         Assert.AreEqual(a, (string)prim);
        
      }

      [TestMethod]
      public void Test1()
      {
         Multinomial prim = new Multinomial(1, 2, 3, 4);
         Multinomial prim2 = new Multinomial(1, 2, 3, 4);
         Assert.AreEqual(prim == prim2, true);
      }

      [TestMethod]
      public void Test2()
      {
         Multinomial prim = new Multinomial(2, 3, 4, 5);
         Multinomial prim2 = new Multinomial(1, 2, 3, 4);
         Assert.AreEqual(prim == prim2, false);
      }

      [TestMethod]
      public void Test3()
      {
         Multinomial prim = new Multinomial(1, 2, 3, 4);
         Multinomial prim2 = new Multinomial(1, 2, 3, 4);
         Assert.AreEqual(prim != prim2, false);
      }

      [TestMethod]
      public void Test4()
      {
         Multinomial prim = new Multinomial(2, 3, 4, 5);
         Multinomial prim2 = new Multinomial(1, 2, 3, 4);
         Assert.AreEqual(prim != prim2, true);
      }

      [TestMethod]
      public void Test5()
      {
         Multinomial prim = new Multinomial(1, 2, 3, 4);
         Multinomial prim2 = new Multinomial(1, 2, 3, 4);
         Assert.AreEqual(prim.Equals(prim2), true);
      }

      [TestMethod]
      public void Test6()
      {
         Multinomial prim = new Multinomial(2, 3, 4, 5);
         Multinomial prim2 = new Multinomial(1, 2, 3, 4);
         Assert.AreEqual(prim.Equals(prim2), false);
      }
   }
}
