using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Task3_Library
{
   /// <summary>
   /// Класс содержит методы для нахождения НОД
   /// </summary>
   public class GCDSearch
   {
      /// <summary>
      /// Метод реализующий алгоритм Евклида для вычисления НОД двух целых чисел 
      /// </summary>
      /// <param name="firstValue">Первое число</param>
      /// <param name="secondValue">Второе число</param>
      /// <returns>Возвращает НОД</returns>
      private static int EuclideanAlgorithm(int firstValue, int secondValue)
      {
         if (firstValue < 0 | secondValue < 0)
         {
            throw new Exception("Числа должны быть положительными");
         }
         int a = 0;
         while (firstValue % secondValue != 0)
         {
            a = firstValue % secondValue;
            firstValue = secondValue;
            secondValue = a;
         }         
         return secondValue;
      }
      /// <summary>
      /// Метод реализующий алгоритм Евклида для вычисления НОД двух и более целых чисел
      /// </summary>
      /// <param name="workTime">Выходной параметр. Время выполнения в миллисекундах</param>
      /// <param name="firstValue">Первое число</param>
      /// <param name="secondValue">Второе число</param>
      /// <param name="values">Числа</param>
      /// <returns>Возвращает НОД</returns>
      public static int EuclideanAlgorithm(out double workTime, int firstValue, int secondValue, params int[] values)
      {
         int answer = 0;
         System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
         time.Start();         
         answer = EuclideanAlgorithm(firstValue, secondValue);
         for (int i = 0; i < values.Length; i++)
         {
            answer = EuclideanAlgorithm(answer, values[i]);
         }
         time.Stop();
         workTime = Convert.ToDouble(time.Elapsed.TotalMilliseconds.ToString());
         return answer;
      }

      /// <summary>
      ///  Метод, реализующий алгоритм Стейна (бинарный алгоритм Эвклида) для расчета НОД двух целых чисел
      /// </summary>
      /// <param name="firstValue">Первое число</param>
      /// <param name="secondValue">Второе число</param>
      /// <returns>Возвращает НОД</returns>
      private static int BinaryGCDAlgorithm(int firstValue, int secondValue)
      {
         if (firstValue < 0 | secondValue < 0)
         {
            throw new Exception("Числа должны быть положительными");
         }
         int deg = 0;
         if (firstValue == 0 || secondValue == 0)
         {
            return firstValue | secondValue;
         }
         while (((firstValue | secondValue) & 1) == 0)
         {
            deg++;
            firstValue >>= 1;
            secondValue >>= 1;
         }
         while (firstValue != 0 && secondValue != 0)
         {
            if ((secondValue & 1) != 0)
               while ((firstValue & 1) == 0)
                  firstValue >>= 1;
            else
               while ((secondValue & 1) == 0)
                  secondValue >>= 1;
            if (firstValue >= secondValue)
               firstValue = (firstValue - secondValue) >> 1;
            else
               secondValue = (secondValue - firstValue) >> 1;
         }
         return ((firstValue | secondValue) << deg);
      }

      /// <summary>
      /// Метод, реализующий алгоритм Стейна (бинарный алгоритм Эвклида) для расчета НОД двух и более целых чисел
      /// </summary>
      /// <param name="workTime">Время выполнения</param>
      /// <param name="firstValue">Первое число</param>
      /// <param name="secondValue">Второе число</param>
      /// <param name="values">Числа для которых нужно вычислить НОД</param>
      /// <returns>Возвращает НОД</returns>
      public static int BinaryGCDAlgorithm(out double workTime,int firstValue, int secondValue, params int[] values)
      {
         System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
         int answer = 0;
         time.Start();
         answer = BinaryGCDAlgorithm(firstValue, secondValue);
         for (int i = 0; i < values.Length; i++)
         {
            answer = BinaryGCDAlgorithm(answer, values[i]);
         }
         time.Stop();
         workTime = Convert.ToDouble(time.Elapsed.TotalMilliseconds.ToString());
         return answer;
      }

   }
}
