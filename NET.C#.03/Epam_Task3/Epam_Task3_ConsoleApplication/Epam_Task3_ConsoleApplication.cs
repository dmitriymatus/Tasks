using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam_Task3_Library;

namespace Epam_Task3_ConsoleApplication
{
   class Program
   {
      static void Main(string[] args)
      {
         double time;
         Console.WriteLine("Введите два числа: ");
         int firstValue = Convert.ToInt16(Console.ReadLine());
         int secondValue = Convert.ToInt16(Console.ReadLine());
         Console.WriteLine("Нод этих чисел: {0}", GCDSearch.EuclideanAlgorithm(out time, firstValue, secondValue));
         Console.WriteLine("Время выполнения алгоритма Евклида: {0} мс", time);
         Console.WriteLine("Введите четыре числа : ");
         firstValue = Convert.ToInt16(Console.ReadLine());
         secondValue = Convert.ToInt16(Console.ReadLine());
         int c = Convert.ToInt16(Console.ReadLine());
         int d = Convert.ToInt16(Console.ReadLine());
         Console.WriteLine("Нод этих чисел: {0}", GCDSearch.EuclideanAlgorithm(out time, firstValue, secondValue, c, d));
         Console.WriteLine("Время выполнения алгоритма Евклида: {0} мс", time);
         Console.WriteLine("Введите два числа: ");
         firstValue = Convert.ToInt16(Console.ReadLine());
         secondValue = Convert.ToInt16(Console.ReadLine());
         Console.WriteLine("Нод этих чисел: {0}", GCDSearch.BinaryGCDAlgorithm(out time, firstValue, secondValue));
         Console.WriteLine("Время выполнения алгоритма Стейна (бинарного алгоритма Эвклида): {0} мс", time);
         Console.WriteLine("Введите четыре числа : ");
         firstValue = Convert.ToInt16(Console.ReadLine());
         secondValue = Convert.ToInt16(Console.ReadLine());
         c = Convert.ToInt16(Console.ReadLine());
         d = Convert.ToInt16(Console.ReadLine());
         Console.WriteLine("Нод этих чисел: {0}", GCDSearch.BinaryGCDAlgorithm(out time, firstValue, secondValue, c, d));
         Console.WriteLine("Время выполнения алгоритма Стейна (бинарного алгоритма Эвклида): {0} мс", time);
         Console.Read();
      }
   }
}
