using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Task5_Library
{
   /// <summary>
   /// Класс для работы с вектором
   /// </summary>
   public class MyVector
   {
      double x, y, z;
      /// <summary>
      /// Свойство для получения значения x
      /// </summary>
      public double X { get { return x; } }
      /// <summary>
      /// Свойство для получения значения y
      /// </summary>
      public double Y { get { return y; } }
      /// <summary>
      /// Свойство для получения значения z
      /// </summary>
      public double Z { get { return z; } }
      /// <summary>
      /// Конструктор класса
      /// </summary>
      /// <param name="x">Значение x</param>
      /// <param name="y">Значение y</param>
      /// <param name="z">Значение z</param>
      public MyVector(double x = 0, double y = 0, double z = 0)
      {
         this.x = x;
         this.y = y;
         this.z = z;
      }
      /// <summary>
      /// Конструктор класса
      /// </summary>
      /// <param name="a">Вектор</param>
      public MyVector(MyVector a)
      {
         this.x = a.X;
         this.y = a.Y;
         this.z = a.Z;
      }
      /// <summary>
      /// Индексатор
      /// </summary>
      /// <param name="i">Индекс</param>
      /// <returns>Возвращает одно из 3 значений вектора</returns>
      public double this[int i]
      {
         get
         {
            switch (i)
            {
               case 0: return x;
               case 1: return y;
               case 2: return z;
               default: throw new Exception("Индекс должен быть в диапазоне от 0 до 2");
            }

         }
         set
         {
            switch (i)
            {
               case 0: x = value; break;
               case 1: y = value; break;
               case 2: z = value; break;
               default: throw new Exception("Индекс должен быть в диапазоне от 0 до 2");
            }

         }
      }
      /// <summary>
      /// Перегруженная операция сложения
      /// </summary>
      /// <param name="first">Первый вектор</param>
      /// <param name="second">Второй вектор</param>
      /// <returns>Возвращает сумму двух векторов</returns>
      public static MyVector operator +(MyVector first, MyVector second)
      {
         if (first == null || second == null)
            throw new Exception("Один из аргументов равен null");
         return new MyVector(first.X + second.X, first.Y + second.Y, first.Z + second.Z);
      }
      /// <summary>
      /// Перегруженная операция вычитания
      /// </summary>
      /// <param name="first">Первый вектор</param>
      /// <param name="second">Второй вектор</param>
      /// <returns>Возвращает разность двух векторов</returns>
      public static MyVector operator -(MyVector first, MyVector second)
      {
         if (first == null || second == null)
            throw new Exception("Один из аргументов равен null");
         return new MyVector(first.X - second.X, first.Y - second.Y, first.Z - second.Z);
      }
      /// <summary>
      /// Перегруженная операция векторного умножения
      /// </summary>
      /// <param name="first">Первый вектор</param>
      /// <param name="second">Второй вектор</param>
      /// <returns>Возвращает произведение двух векторов</returns>
      public static MyVector operator *(MyVector first, MyVector second)
      {
         if (first == null || second == null)
            throw new Exception("Один из аргументов равен null");
         return new MyVector((first.Y*second.Z) - (first.Z*second.Y), (first.Z * second.X) - (first.X*second.Z), (first.X*second.Y) - (first.Y*second.X));
      }
      /// <summary>
      /// Перегруженная операция нахождения угла между векторами
      /// </summary>
      /// <param name="first">Первый вектор</param>
      /// <param name="second">Второй вектор</param>
      /// <returns>Возвращает угол между векторами</returns>
      public static double operator ^(MyVector first, MyVector second)
      {
         if (first == null || second == null)
            throw new Exception("Один из аргументов равен null");
         double angle;
         double scalar = first.X*second.X + first.Y*second.Y + first.Z*second.Z;
         double firstLength = Math.Sqrt((first.X*first.X) + (first.Y*first.Y) + (first.Z*first.Z));
         double secondLength = Math.Sqrt((second.X*second.X) + (second.Y*second.Y) + (second.Z*second.Z));
         double cosAngle = scalar/(firstLength*secondLength);
         if (cosAngle == 0)
         {
            angle = 90;
         }
         else
         {
            angle = Math.Atan(Math.Sqrt(1 - Math.Pow(cosAngle,2))/2)*180/Math.PI;
         }
         return angle;
      }
   }
}
