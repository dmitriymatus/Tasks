using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam_Task_11_1_Library;
using Epam_Task_11_1_Library2;

namespace Epam_Task_11_1_ConsoleApplication
{
   class Epam_Task_11_1_ConsoleApplication
   {
      static void Main(string[] args)
      {
         DateTime testdata = new DateTime(2014, 10, 20);
         TestInfo a = new TestInfo("dima", "firsttest", testdata, 9);
         testdata = new DateTime(2014, 11, 20);
         TestInfo b = new TestInfo("oleg", "firsttest", testdata, 4);
         BinaryTree<TestInfo> tree = new BinaryTree<TestInfo>();
         tree.Add(a);
         tree.Add(b);
         foreach (TestInfo c in tree)
         {
            Console.WriteLine(c.ToString());
         }
         tree.Remove(a);
         foreach (TestInfo c in tree)
         {
            Console.WriteLine(c.ToString());
         }
         if (!tree.IsReadOnly)
         {
            Console.WriteLine("not only for reading");
         }
         testdata = new DateTime(2014, 11, 10);
         TestInfo d = new TestInfo("pasha", "secondtest", testdata, 8);
         tree.Add(a);
         tree.Add(d);
         foreach (TestInfo c in tree)
         {
            Console.WriteLine(c.ToString());
         }
         if (tree.Contains(a))
         {
            Console.WriteLine("Tree contains this element");
         }
         Console.ReadLine();
      }
   }
}
