using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam_Task4_Library;

namespace Epam_Task4_ConsoleApplication
{
   class Epam_Task4_ConsoleApplication
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Введите координаты вершин треугольника:");
         int x1 = Convert.ToInt16(Console.ReadLine());
         int y1 = Convert.ToInt16(Console.ReadLine());
         int x2 = Convert.ToInt16(Console.ReadLine());
         int y2 = Convert.ToInt16(Console.ReadLine());
         int x3 = Convert.ToInt16(Console.ReadLine());
         int y3 = Convert.ToInt16(Console.ReadLine());
         Triangle prim = new Triangle(x1,y1,x2,y2,x3,y3);
         if (prim != null)
         {
            Console.WriteLine("Такой треугольник существует!");
            Console.WriteLine("Периметр треугольника: {0}", prim.Perimeter());
            Console.WriteLine("Площадь треугольника: {0}", prim.Square());
         }
         else
         {
            Console.WriteLine("Такого треугольника не существует!");
         }
         Console.ReadLine();
      }
   }
}
