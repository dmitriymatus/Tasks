using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Epam_Task_12_Library;

namespace Epam_Task_12_ConsoleApplication
{
   class Program
   {
      static void Main(string[] args)
      {
         BinaryTree<TestInfo> tree = new BinaryTree<TestInfo>();
         List<TestInfo> testsFromFile;
         List<TestInfo> tests = new List<TestInfo>()
         {
            new TestInfo("dima", "firsttest", new DateTime(2014, 10, 20), 9),
            new TestInfo("oleg", "firsttest", new DateTime(2014, 11, 20), 4),
            new TestInfo("maksim", "secondtest", new DateTime(2014, 09, 15), 7),
            new TestInfo("oleg", "thirdtest", new DateTime(2014, 12, 08), 8)
         };

         // сериализация
         BinaryFormatter binFormat = new BinaryFormatter();
         using (Stream fStream = new FileStream("AllTests.dat", FileMode.Create, FileAccess.Write, FileShare.None))
         {
            binFormat.Serialize(fStream, tests);
         }

         // десериализация
         using (Stream fStream = File.OpenRead("AllTests.dat"))
         {
            testsFromFile = (List<TestInfo>)binFormat.Deserialize(fStream);
         }

         // создание дерева
         foreach (TestInfo temp in testsFromFile)
         {
            tree.Add(temp);
         }




         Console.WriteLine("All tests:");
         foreach (TestInfo temp in tree)
         {
            Console.WriteLine(temp.ToString());
         }


         Console.WriteLine("\nGood tests:");
         BinaryTree<TestInfo> GoodTests = GetGoodTests(tree,5);
         foreach (TestInfo temp in GoodTests.OrderBy(temp=> temp.Score))
         {
            Console.WriteLine(temp.ToString());
         }


         Console.WriteLine("\nFirst test:");
         BinaryTree<TestInfo> FirstTest = GetSomeTest(tree,"firsttest");
         foreach (TestInfo temp in FirstTest.OrderBy(temp => temp.Score))
         {
            Console.WriteLine(temp.ToString());
         }


         Console.WriteLine("\nScores for student oleg:");
         List<int> testScores = GetTestsScores(tree,"oleg");
         foreach (int temp in testScores)
         {
            Console.WriteLine(temp);
         }

         Console.WriteLine("\nTests after september:");
         BinaryTree<TestInfo> dateTests = GetTestsDate(tree, new DateTime(2014, 10, 01));
         foreach (TestInfo temp in dateTests)
         {
            Console.WriteLine(temp.ToString());
         }

         Console.ReadLine();
      }


      static BinaryTree<TestInfo> GetGoodTests(BinaryTree<TestInfo> tree, int minimalScore)
      {
         var result = from testInfo in tree where testInfo.Score > minimalScore  select testInfo;
         return new BinaryTree<TestInfo>(result.ToList<TestInfo>());
      }

      static BinaryTree<TestInfo> GetSomeTest(BinaryTree<TestInfo> tree, string testName)
      {
         IEnumerable<TestInfo> result = from testInfo in tree where testInfo.TestName == testName select testInfo;
         return new BinaryTree<TestInfo>(result.ToList<TestInfo>());
      }

      static List<int> GetTestsScores(BinaryTree<TestInfo> tree, string name)
      {
         IEnumerable<int> result = from testInfo in tree where testInfo.StudentName == name select testInfo.Score; 
         return result.ToList<int>();
      }

      static BinaryTree<TestInfo> GetTestsDate(BinaryTree<TestInfo> tree, DateTime date)
      {
         var result = tree.Where(temp => temp.Date >= date).OrderBy(temp=>temp.Date).Select(temp => temp);
         return new BinaryTree<TestInfo>(result.ToList<TestInfo>());
      }

      static List<TestInfo> GetTests()
      {

      }
   }
}
