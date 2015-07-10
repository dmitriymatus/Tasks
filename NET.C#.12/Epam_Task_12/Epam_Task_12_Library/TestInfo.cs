using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Task_12_Library
{
   /// <summary>
   /// Класс для хранения данных о тесте
   /// </summary>
   [Serializable]
   public class TestInfo : IComparable
   {
      string studentName;
      /// <summary>
      /// Свойства для получения имени студента
      /// </summary>
      public string StudentName
      {
         get
         {
            return studentName;
         }
      }
      string testName;
      /// <summary>
      /// Свойство для получения имени теста
      /// </summary>
      public string TestName
      {
         get
         {
            return testName;
         }
      }
      DateTime date;
      /// <summary>
      /// Свойство для получения даты теста
      /// </summary>
      public DateTime Date
      {
         get
         {
            return date;
         }
      }
      int score;
      /// <summary>
      /// Свойство для получения оценки за тест
      /// </summary>
      public int Score
      {
         get
         {
            return score;
         }
      }

      /// <summary>
      /// Конструктор класса
      /// </summary>
      /// <param name="studentName">Имя студента</param>
      /// <param name="testName">Имя теста</param>
      /// <param name="date">Дата теста</param>
      /// <param name="score">Оценка за тест</param>
      public TestInfo(string studentName, string testName, DateTime date, int score)
      {
         if (studentName == null || testName == null || date == null)
         {
            throw new Exception("Null value");
         }
         if (score < 0)
         {
            throw new Exception("Score must be greater then 0");
         }
         this.studentName = studentName;
         this.testName = testName;
         this.date = date;
         this.score = score;
      }

      /// <summary>
      /// Метод сравнения
      /// </summary>
      /// <param name="obj">Объект с которым надо сравнить</param>
      /// <returns></returns>
      public int CompareTo(object obj)
      {
         if (obj == null) return 1;
         TestInfo temp = obj as TestInfo;
         if (this.StudentName != temp.StudentName)
         {
            return this.StudentName.CompareTo(temp.StudentName);
         }
         else
         {
            return this.TestName.CompareTo(temp.TestName);
         }
      }

      /// <summary>
      /// Метод для получения информации о тесте в виде строки
      /// </summary>
      /// <returns>Возвращает строку</returns>
      public override string ToString()
      {
         return String.Format("Имя студента: {0}\nНазвание теста: {1}\nОценка за тест: {2}\nДата:{3},{4},{5}", this.StudentName, this.TestName, this.Score, this.Date.Year, this.Date.Month, this.Date.Day);
      }
   } // end of TestInfo
}
