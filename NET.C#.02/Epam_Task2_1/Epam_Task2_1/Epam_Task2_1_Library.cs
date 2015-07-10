using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Task2_1
{
   /// <summary>
   /// Класс для вычисления корня n-ой степени из числа Методом Ньютона
   /// </summary>
   public class NewtonMath
   {
       /// <summary>
       /// Метод вычисляет корень n-ой степени из числа, Методом Ньютона
       /// </summary>
       /// <param name="degree">Степень</param>
       /// <param name="value">Число</param>
       /// <param name="accuracy">Точность</param>
       /// <returns>Результат вычисления корня n-ой степени из числа</returns>
      public static double NewtonPow(int degree, double value, double accuracy = 0.00000000001)
      {
         double prevResult;
         double result = 1;
         // Корень любой натуральной степени из нуля — нуль.
         if (value == 0) return 0;
         // Корень чётной степени из отрицательного числа не существует в области вещественных чисел
         if (degree%2 == 0 && value < 0)
         {
            throw new Exception("Корень чётной степени из отрицательного числа не существует в области вещественных чисел");
         }
         if (degree <= 0)
         {
            throw new Exception("Степень должна быть положительной");
         }
         do
         {
            prevResult = result;
            result = (1 / (double)degree) * (((double)degree - 1) * prevResult + value / Math.Pow(prevResult, (double)degree - 1));
         } while (Math.Abs(result - prevResult) >= accuracy);
         return result;
      }

      /// <summary>
      /// Функция сравнения
      /// </summary>
      /// <param name="degree">Степень</param>
      /// <param name="value">Число</param>
      /// <param name="accuracy">Точность</param>
      /// <returns>Возвращает True если полученный методом NewtonPow результат совпадает со значением, рассчитываемым с помощью метода Math.Pow библиотеки классов .NET Framework.</returns>
      public static double Comparer(int degree, double value, double accuracy = 0.0000000001)
      {
         return Math.Pow(value, 1.0 / degree) - NewtonPow(degree,value,accuracy);
      }
   }
}