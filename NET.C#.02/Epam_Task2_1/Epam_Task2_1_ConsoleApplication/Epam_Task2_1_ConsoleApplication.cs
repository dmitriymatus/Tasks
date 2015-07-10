using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam_Task2_1;

namespace Epam_Task2_1_ConsoleApplication
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Введите степень, число и точность");
         int degree = Convert.ToInt16(Console.ReadLine());
         double value = Convert.ToDouble(Console.ReadLine());
         double accuracy = Convert.ToDouble(Console.ReadLine());           
         Console.WriteLine(NewtonMath.NewtonPow(degree, value, accuracy));
         if (NewtonMath.Comparer(degree, value, accuracy) == 0)
         {
            Console.WriteLine("Полученный методом NewtonPow результат совпадает со значением, рассчитываемым с помощью метода Math.Pow библиотеки классов .NET Framework.");
         }
         else { Console.WriteLine("Полученный методом NewtonPow результат отличается от значения, рассчитываемого с помощью метода Math.Pow библиотеки классов .NET Framework на {0}", NewtonMath.Comparer(degree, value, accuracy)); }

         Console.ReadLine();
      }
   }
}
