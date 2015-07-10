using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Task2_2_Library
{
   /// <summary>
   /// Класс содержит метод для преобразования неотрицательного десятичного значения целого числа в строку, содержащую двоичное представление этого значения.
   /// </summary>
   public class ConvertToBinnary
   {
      /// <summary>
      ///Метод преобразует число из десятичного кода в двоичный 
      /// </summary>
      /// <param name="value">Десятичное число</param>
      /// <returns>Возвращает строку  в которой записан двоичный код числа</returns>
      public static string MyConvert(int value)
      {
         if(value < 0)
         {
            throw new Exception("Число должно быть не отрицательным");
         }
         if (value == 0) return "0";
         StringBuilder tempValue = new StringBuilder();
         StringBuilder answer = new StringBuilder();
         do
         {
            tempValue.Append(value % 2);
            value = value / 2;
            if (value / 2 < 1)
            {
               tempValue.Append("1");
            }
         } while (value / 2 >= 1);

         for (int i = tempValue.Length; i > 0; i--)
         {
            answer.Append(tempValue.ToString(), i - 1, 1);
         }
         return answer.ToString();
      }
   }
}
