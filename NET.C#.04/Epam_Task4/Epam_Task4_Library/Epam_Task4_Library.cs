using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Task4_Library
{
   /// <summary>
   /// Класс для представления треугольника
   /// </summary>
   public class Triangle
   {
      private double firstSide, secondSide, thirdSide;
      /// <summary>
      /// Конструктор класса
      /// </summary>
      /// <param name="x1">Координата первой точки по оси X</param>
      /// <param name="y1">Координата первой точки по оси Y</param>
      /// <param name="x2">Координата второй точки по оси X</param>
      /// <param name="y2">Координата второй точки по оси Y</param>
      /// <param name="x3">Координата третьей точки по оси X</param>
      /// <param name="y3">Координата третьей точки по оси Y</param>
      public Triangle(int x1, int y1, int x2, int y2, int x3, int y3)
      {
         firstSide = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2-y1,2));
         secondSide = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
         thirdSide = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
         if (!isExist())
         {
            throw new Exception("Такой треугольник не существует! ");
         }
      }
      /// <summary>
      /// Метод для проверки существования треугольника
      /// </summary>
      /// <returns>Возвращает True если треугольник существует,возвращает False если треугольник не существует</returns>
      private bool isExist()
      {
         if (firstSide + secondSide <= thirdSide || firstSide + thirdSide <= secondSide || secondSide + thirdSide <= firstSide)
            return false;
         return true;
      }
      /// <summary>
      /// Метод для подсчёта периметра треугольника. 
      /// Перед применением нужно убедиться что такой треугольник существует при помощи метода <see cref="isExist"/>
      /// </summary>
      /// <returns>Возвращает периметр треугольника</returns>
      public double Perimeter()
      {
         return firstSide + secondSide + thirdSide;
      }
      /// <summary>
      /// Метод для подсчёта площади треугольника
      /// Перед применением нужно убедиться что такой треугольник существует при помощи метода <see cref="isExist"/>
      /// </summary>
      /// <returns>Возвращает площадь треугольника</returns>
      public double Square()
      {
         double p = (firstSide + secondSide + thirdSide) / 2;
         return Math.Sqrt(p * (p - firstSide) * (p - secondSide) * (p - thirdSide));
      }
   }
}