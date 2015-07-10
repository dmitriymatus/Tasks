using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Task7_Library
{
   /// <summary>
   /// Класс исключений
   /// </summary>
   public class MatrixException : ApplicationException
   {
      /// <summary>
      /// Конструктор исключения
      /// </summary>
      public MatrixException(){}
      /// <summary>
      /// Конструктор исключения
      /// </summary>
      /// <param name="msg">Сообщение описывающее исключение</param>
      public MatrixException(string msg) : base(msg) { }
   }

   /// <summary>
   /// Класс для работы с матрицами
   /// </summary>
    public class MatrixClass : IComparable
    {
       double[,] matrix;
       /// <summary>
       /// Свойство для получения матрицы
       /// </summary>
       public double[,] Matrix
       {
          get
          {
             //
             return (double[,])matrix.Clone();
          }
       }

       /// <summary>
       /// Индексатор для получения значения из матрицы
       /// </summary>
       /// <param name="n">Столбец</param>
       /// <param name="m">Строка</param>
       /// <returns>Возвращает элемент который находится в n-ом столбце,m-ой строке</returns>
       public double this[int n, int m]
       {
          get
          {
             //
             if (Matrix.GetLength(0) < n || Matrix.GetLength(1) < m || n < 0 || m < 0 )
             {
                throw new IndexOutOfRangeException("Индекс находился вне границ массива");
             }
             return Matrix[n, m];
          }
       
       }

       /// <summary>
       /// Конструктор
       /// </summary>
       /// <param name="n">Количество столбцов</param>
       /// <param name="m">Количество строк</param>
       /// <param name="values">Элементы матрицы</param>
       public MatrixClass(int m, int n, params double[] values)
       {
          if (m <= 0 || n <= 0)
          {
             throw new ArgumentException("The number of rows and columns must be greater than 0");
          }
          //
          if (values == null)
          {
             throw new ArgumentException("null value");
          }

          if (values.Length != m * n)
          {
             throw new ArgumentException("Incorrect number of values");
          }
          matrix = new double[m, n];
          int k = 0;
          for (int i = 0; i < m; i++)
          {            
             for (int j = 0; j < n; j++)
             {
                matrix[i,j] = values[k];
                k++; 
             }
          }
       }
       /// <summary>
       /// Конструктор
       /// </summary>
       /// <param name="value">Объект типа MatrixClass</param>
       public MatrixClass(MatrixClass value)
       {
          //
          if (value == null)
          {
             throw new ArgumentException("null value");
          }
          matrix = new double[value.Matrix.GetLength(0), value.Matrix.GetLength(1)];
          for (int i = 0; i < value.Matrix.GetLength(0); i++)
          {
             for (int j = 0; j < value.Matrix.GetLength(1); j++)
             {
                this.matrix[i, j] = value[i,j];
             }
          }
       }

       /// <summary>
       /// Конструктор
       /// </summary>
       /// <param name="value">Массив</param>
       public MatrixClass(double[,] value)
       {
          //
          if (value == null)
          {
             throw new ArgumentException("null value");
          }
          matrix = new double[value.GetLength(0), value.GetLength(1)];
          matrix = (double[,])value.Clone();
       }
       /// <summary>
       /// Метод сравнения
       /// </summary>
       /// <param name="obj">Объект с которым нужно сравнить</param>
       /// <returns>Возвращает целое число</returns>
      public int CompareTo(object obj)
       {
          if (obj == null) return 1;

          MatrixClass secondMatrix = obj as MatrixClass;
          if (secondMatrix != null)
          {
             return this.Matrix.Length.CompareTo(secondMatrix.Matrix.Length);
          }
          else
          {
             throw new ArgumentException("Object is not a MatrixClass");
          }
       }
       /// <summary>
       /// Операция умножения
       /// </summary>
       /// <param name="first">Первый объект типа MatrixClass</param>
       /// <param name="second">Второй объект типа MatrixClass</param>
       /// <returns>Объект типа MatrixClass который является произведением двух матриц</returns>
       public static MatrixClass operator * (MatrixClass first, MatrixClass second)
       {
          if ((object)first == null || (object)second == null)
          {
             throw new ArgumentException("Parameters cannot be null");
          }
          if (first.Matrix.GetLength(1) != second.Matrix.GetLength(0))
          {
             throw new MatrixException("Number of columns in the first factor must be equal to the number of rows in the second");
          }
          if(first.Matrix.GetLength(0)<second.Matrix.GetLength(0))
          {
             MatrixClass temp = new MatrixClass(first);
             first = second;
             second = temp;

          }
          double[] resultMatrix = new double[first.Matrix.GetLength(0) * second.Matrix.GetLength(1)];
          int k = 0;
          for (int y = 0; y < first.matrix.GetLength(0); y++)
          {
             for (int i = 0; i < second.Matrix.GetLength(1); i++)
             {
                for (int j = 0; j < second.Matrix.GetLength(0); j++)
                {
                   resultMatrix[k] += first.Matrix[y, j] * second.Matrix[j, i];
                  
                }
                k++;
             }
          }
          return new MatrixClass(first.Matrix.GetLength(0),second.Matrix.GetLength(1),resultMatrix);
       }
       /// <summary>
       /// Операция сложения
       /// </summary>
       /// <param name="first">Первый объект типа MatrixClass</param>
       /// <param name="second">Второй объект типа MatrixClass</param>
       /// <returns>Объект типа MatrixClass который является суммой двух матриц</returns>
       public static MatrixClass operator +(MatrixClass first, MatrixClass second)
       {
          if ((object)first == null || (object)second == null)
          {
             throw new ArgumentException("Parameters cannot be null");
          }
          if (first.Matrix.GetLength(0) != second.Matrix.GetLength(0) || first.Matrix.GetLength(1) != second.Matrix.GetLength(1))
          {
             throw new MatrixException("Matrixes must be the identical size");
          }
          double[] resultMatrix = new double[first.Matrix.Length];
          int k = 0;
          for(int i=0;i<first.Matrix.GetLength(0);i++)
          {
             for(int j = 0;j<second.Matrix.GetLength(1);j++)
             {
                resultMatrix[k] = first.Matrix[i,j] + second.Matrix[i,j];
                k++;
             }
          }
          return new MatrixClass(first.Matrix.GetLength(0),second.Matrix.GetLength(1),resultMatrix);
       }
       /// <summary>
       /// Операция вычитания
       /// </summary>
       /// <param name="first">Первый объект типа MatrixClass</param>
       /// <param name="second">Второй объект типа MatrixClass</param>
       /// <returns>Объект типа MatrixClass который является разностью двух матриц</returns>
       public static MatrixClass operator -(MatrixClass first, MatrixClass second)
       {
          if ((object)first == null || (object)second == null)
          {
             throw new ArgumentException("Parameters cannot be null");
          }
          if (first.Matrix.GetLength(0) != second.Matrix.GetLength(0) || first.Matrix.GetLength(1) != second.Matrix.GetLength(1))
          {
             throw new MatrixException("Matrixes must be the identical size");
          }
          double[] resultMatrix = new double[first.Matrix.Length];
          int k = 0;
          for (int i = 0; i < first.Matrix.GetLength(0); i++)
          {
             for (int j = 0; j < second.Matrix.GetLength(1); j++)
             {
                resultMatrix[k] = first.Matrix[i, j] - second.Matrix[i, j];
                k++;
             }
          }
          return new MatrixClass(first.Matrix.GetLength(0), second.Matrix.GetLength(1), resultMatrix);
       }


       /// <summary>
       /// Метод для нахождения обратной матрицы
       /// </summary>
       /// <param name="obj">Матрица</param>
       /// <returns></returns>
       public static MatrixClass InverseMatrix(MatrixClass obj)
       {
          //
          if (obj == null)
          {
             throw new ArgumentException("obj has a null value");
          }
          if (obj.Matrix.GetLength(0) != obj.Matrix.GetLength(1))
          {
             throw new MatrixException("Matrix must be square");
          }
          double determ = Determinant(obj.Matrix);
          if (determ == 0)
          {
             throw new MatrixException("Matrix dont have inverse matrix");
          }
          double[,] answer = new double[obj.Matrix.GetLength(0), obj.Matrix.GetLength(0)];
             for (int j = 0; j < obj.Matrix.GetLength(0); j++)
             {
                answer[j, j] = 1;
             }

             for (int i = 0; i < obj.Matrix.GetLength(0); i++)
             {
                for (int t = 0; t < obj.Matrix.GetLength(0); t++)
                {
                   answer[t, i] = Math.Pow(-1, i + t)* Determinant(GetMinor(obj.Matrix, i, t));
                }
             }
             for (int i = 0; i < obj.Matrix.GetLength(0); i++)
             {
                for (int t = 0; t < obj.Matrix.GetLength(0); t++)
                {
                   answer[t, i] = (1 / determ) * answer[t,i];
                }
             }
             return new MatrixClass(answer);
       }
       /// <summary>
       /// Метод для нахождения определителя матрицы
       /// </summary>
       /// <param name="matrix">Матрица для которой нужно найти определитель</param>
       /// <returns>Возвращает определитель</returns>
       private static double Determinant(double[,] matrix)
       {
          //
          if (matrix == null)
          {
             throw new ArgumentException("matrix has a null value");
          }
          if (matrix.GetLength(0) == 1) return matrix[0, 0];
          if (matrix.GetLength(0) == 2) return ((matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]));
          double det = 0;
             for (int i = 0; i < matrix.GetLength(1); i++)
             {
                det += Math.Pow(-1, 0 + i) * matrix[0, i] * Determinant(GetMinor(matrix, 0, i));
             }
          return det;
       }
       /// <summary>
       /// Метод для нахождения минора матрицы
       /// </summary>
       /// <param name="matrix">Матрица для которой нужно найти минор</param>
       /// <param name="row">Индекс строки из которой нужно вычеркнуть эллемент</param>
       /// <param name="column">Индекс столбца из которого нужно вычеркнуть эллемент</param>
       /// <returns>Возвращает минор</returns>
       private static double[,] GetMinor(double[,] matrix, int row = 0, int column = 0)
       {
          if (matrix == null)
          {
             throw new ArgumentException("matrix has a null value");
          }
          if(matrix.GetLength(0) == 2)
          {
             return matrix;
          }
          double[,] buf = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
          for (int i = 0; i < matrix.GetLength(0); i++)
             for (int j = 0; j < matrix.GetLength(1); j++)
             {
                if ((i != row) || (j != column))
                {
                   if (i > row && j < column) buf[i - 1, j] = matrix[i, j];
                   if (i < row && j > column) buf[i, j - 1] = matrix[i, j];
                   if (i > row && j > column) buf[i - 1, j - 1] = matrix[i, j];
                   if (i < row && j < column) buf[i, j] = matrix[i, j];
                }
             }
          return buf;
       }

    } // end of class Matrix
}
