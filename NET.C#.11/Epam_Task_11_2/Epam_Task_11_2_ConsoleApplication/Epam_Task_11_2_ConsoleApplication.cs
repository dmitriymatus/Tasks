using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam_Task_11_2_Library;

namespace Epam_Task_11_2_ConsoleApplication
{
   class Program
   {
      static void Main(string[] args)
      {
         IFactory firstFactory = new Factory1();
         Client firstClient = new Client(firstFactory);

         IFactory secondFactory = new Factory2();
         Client secondClient = new Client(secondFactory);

         Console.WriteLine("FirstClient have products:");
         Console.WriteLine(firstClient.ProductsName());
         Console.WriteLine(" \nSecondClient have products:");
         Console.WriteLine(secondClient.ProductsName());

         Console.ReadLine();
      }
   }
}
