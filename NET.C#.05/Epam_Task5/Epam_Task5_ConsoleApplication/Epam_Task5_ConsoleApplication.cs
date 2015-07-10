using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam_Task5_Library;

namespace Epam_Task5_ConsoleApplication
{
   class Program
   {
      static void Main(string[] args)
      {
         double a, b, c, d, e, f;
         Console.WriteLine("Введите координаты двух векторов:");
         a = Convert.ToDouble(Console.ReadLine());
         b = Convert.ToDouble(Console.ReadLine());
         c = Convert.ToDouble(Console.ReadLine());
         d = Convert.ToDouble(Console.ReadLine());
         e = Convert.ToDouble(Console.ReadLine());
         f = Convert.ToDouble(Console.ReadLine());
         MyVector vect1 = new MyVector(a,b,c);
         MyVector vect2 = new MyVector(d, e, f);
         Console.WriteLine("Угол между векторами: {0}",vect1 ^ vect2);
         MyVector vect3 = vect1 + vect2;
         Console.WriteLine("Новый вектор(сложение двух векторов): {0},{1},{2}",vect3[0],vect3[1],vect3[2]);
         vect3 = vect1 - vect2;
         Console.WriteLine("Новый вектор(разность двух векторов): {0},{1},{2}", vect3[0], vect3[1], vect3[2]);
         vect3 = vect1 * vect2;
         Console.WriteLine("Новый вектор(Векторное умножение двух векторов): {0},{1},{2}", vect3[0], vect3[1], vect3[2]);
         Console.ReadLine();
      }
   }
}
