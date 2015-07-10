using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Epam_Task5_2_Library
{
   /// <summary>
   /// Класс для работы с многочленами от одной переменной 
   /// </summary>
   public class Multinomial
    {
      private int degree;
      private int[] coefficients;

      /// <summary>
      /// Конструктор класса
      /// </summary>
      /// <param name="coeff">Коэффициенты</param>
      public Multinomial(params int[] coeff)
      {
         coefficients = (int[])coeff.Clone();
         this.degree = coefficients.Length-1;
      }

      /// <summary>
      /// Конструктор класса
      /// </summary>
      /// <param name="inputString">Коэффициенты многочлена записанные через " ; "</param>
      public Multinomial(string inputString)
      {

         int i = 0;
         MatchCollection templateStrings = Regex.Matches(inputString, @"(?:-\d+|\d+)");
         int[] coeff = new int[templateStrings.Count];
         foreach (Match templateString in templateStrings)
         {
           coeff[i] = Convert.ToInt16(templateString.Value);
           i++;
         }
         coefficients = (int[])coeff.Clone();
         this.degree = coefficients.Length - 1;
      }
      /// <summary>
      /// Свойство для получения значения степени многочлена
      /// </summary>
      public int Degree
      {
         get
         {
            return degree;
         }
      }
      /// <summary>
      /// Индексатор для получения коэффициента
      /// </summary>
      /// <param name="index">Индекс коэффициента</param>
      /// <returns>Возвращает коэффициент</returns>
      public int this[int index]
      {
         get
         {
            if (index < 0 || index >= this.coefficients.Length)
            {
               throw new Exception("Индекс имеет неправильное значение");
            }
            return this.coefficients[index];
         }
      }
       /// <summary>
       /// Перегруженная операция получения строки
       /// </summary>
       /// <param name="a">Многочлен</param>
       /// <returns>Возвращает многочлен записанный в строку</returns>
      public static implicit operator string(Multinomial a)
      {
         int degreeIndex = a.Degree;
         StringBuilder answer = new StringBuilder();
         for (int i = 0; i < a.coefficients.Length; i++)
         {

            if (a.coefficients[i] > 0 && i != 0)
            {
               answer.Append("+");
            }
            if (i == a.coefficients.Length-1)
            {
               answer.Append(a.coefficients[i]);
            }
            else
            {              
               answer.Append(a.coefficients[i]);
               answer.Append("X");
               if (degreeIndex > 1)
               {
                  answer.Append("(");
                  answer.Append(degreeIndex);
                  answer.Append(")");
                  degreeIndex--;
               }
            }//end of else
         }
            return answer.ToString();
      } //end of operator string
      /// <summary>
      /// Метод для получения строки
      /// </summary>
      /// <returns>Возвращает многочлен записанный в строку</returns>
      public override string ToString()
      {
         return (string)this;
      }

      /// <summary>
      /// Операция сравнения
      /// </summary>
      /// <param name="first">Первый многочлен</param>
      /// <param name="second">Второй многочлен</param>
      /// <returns>Возвращает true если многочлены равны</returns>
      public static bool operator ==(Multinomial first, Multinomial second)
      {
         if ((object)first == null || (object)second == null)
         {
            if (first == null && second == null)
            {
               throw new Exception("Объекты равны null");
            }
            return false;
         }
         
         if (first.coefficients.Length != second.coefficients.Length)
         {
            return false;
         }
         for (int i = 0; i < first.coefficients.Length; i++)
         {
            if (first.coefficients[i] != second.coefficients[i])
            {
               return false;
            }
         }
         return true;
      }
      /// <summary>
      /// Операция сравнения
      /// </summary>
      /// <param name="first">Первый многочлен</param>
      /// <param name="second">Второй многочлен</param>
      /// <returns>Возвращает true если многочлены не равны</returns>
      public static bool operator !=(Multinomial first, Multinomial second)
      {
         if (first == second) { return false; }
         return true;
      }

      /// <summary>
      /// Определяет, равен ли заданный объект Object текущему объекту Object.
      /// </summary>
      /// <param name="obj">Объект, который требуется сравнить с текущим объектом.</param>
      /// <returns>Значение true, если указанный объект Object равен текущему объекту Object; в противном случае — значение false.</returns>
      public override bool Equals(Object obj)
      {//проверить null
         // Check for null values and compare run-time types.
         if (obj == null)
         {
            throw new Exception("Объект равен null");
         }
         if (this.GetType() != obj.GetType())
            return false;

         return (this == (Multinomial)obj);
      }

      /// <summary>
      /// Перегруженный метод GetHashCode
      /// </summary>
      /// <returns>Хэш-код для текущего объекта Object.</returns>
      public override int GetHashCode()
      {
         int hashCode = 0;
         for (int i = 0; i < this.coefficients.Length; i++)
         {
            hashCode = hashCode ^ this.coefficients[i];
         }
            return hashCode;
      }

    }
}
