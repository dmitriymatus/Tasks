using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam_Task7_Library;

namespace Epam_Task7_ConsoleApplication
{
   class Epam_Task7_ConsoleApplication
   {
      static void Main(string[] args)
      {
         MatrixClass prim = new MatrixClass(3,3,3,4,5,6,7,8,1,1,3);
         MatrixClass prim2 = new MatrixClass(3, 3, 3, 4, 5, 6, 7, 8, 1, 1, 3);
         MatrixClass prim3;
         MatrixClass prim4;
         MatrixClass prim5;
         Console.WriteLine("Первая матрица:");
         print(prim);
         Console.WriteLine("Вторая матрица:");
         print(prim2);
         Console.WriteLine("Результат умножения матриц:");
         try
         {
            prim3 = prim * prim2;
            print(prim3);
         }
         catch (MatrixException ex)
         {
            Console.WriteLine(ex.Message);
         }

         Console.WriteLine("Результат сложения матриц:");
         try
         {
            prim4 = prim + prim2;
            print(prim4);
         }
         catch (MatrixException ex)
         {
            Console.WriteLine(ex.Message);
         }

         Console.WriteLine("Результат вычитания матриц:");
         try
         {
            prim5 = prim - prim2;
            print(prim5);
         }
         catch (MatrixException ex)
         {
            Console.WriteLine(ex.Message);
         }

         Console.WriteLine("Обратная матрица матрицы 1:");
         try
         {
            print(MatrixClass.InverseMatrix(prim));
         }
         catch (MatrixException ex)
         {
            Console.WriteLine(ex.Message);
         }

         Console.WriteLine("Обратная матрица матрицы 2:");
         try
         {
            print(MatrixClass.InverseMatrix(prim2));
         }
         catch (MatrixException ex)
         {
            Console.WriteLine(ex.Message);
         }
         Console.ReadLine();
      }


      public static void print(MatrixClass a)
      {
         for (int i = 0; i < a.Matrix.GetLength(0); i++)
         {
            for (int j = 0; j < a.Matrix.GetLength(1); j++)
            {
               Console.Write("{0} ", a[i, j]);
            }
            Console.WriteLine();
         }
      }


   }
}
