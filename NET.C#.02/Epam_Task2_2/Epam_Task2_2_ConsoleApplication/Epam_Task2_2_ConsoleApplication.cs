using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam_Task2_2_Library;

namespace Epam_Task2_2_ConsoleApplication
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Введите число");
         int value = Convert.ToInt16(Console.ReadLine());
         Console.WriteLine(ConvertToBinnary.MyConvert(value));
         Console.ReadLine();
      }
   }
}
