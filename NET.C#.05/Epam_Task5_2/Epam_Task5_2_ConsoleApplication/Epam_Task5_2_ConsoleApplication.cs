using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam_Task5_2_Library;

namespace Epam_Task5_2_ConsoleApplication
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Введите степень многочлена:");
         int degree = Convert.ToInt16(Console.ReadLine());
         int[] a = new int[degree+1];
         for (int i = 0; i <= degree; i++)
         {
            Console.WriteLine("Введите коэффициент:");
            a[i] = Convert.ToInt16(Console.ReadLine());
         }

         Multinomial prim = new Multinomial(a);
         Console.WriteLine((string)prim);
         
         Console.WriteLine("Введите степень многочлена:");
         degree = Convert.ToInt16(Console.ReadLine());
         a = new int[degree + 1];
         for (int i = 0; i <= degree; i++)
         {
            Console.WriteLine("Введите коэффициент:");
            a[i] = Convert.ToInt16(Console.ReadLine());
         }

         Multinomial prim2 = new Multinomial(a);
         Console.WriteLine((string)prim2);
         Console.WriteLine(prim2.ToString());


         if (prim == prim2)
         {
            Console.WriteLine("Многочлены равны");
         }

         if (prim != prim2)
         {
            Console.WriteLine("Многочлены не равны");
         }
         Console.WriteLine(prim.GetHashCode());
         Console.WriteLine(prim2.GetHashCode());
         Console.ReadLine();

      }
   }
}
