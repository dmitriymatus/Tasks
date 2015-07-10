using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Task_11_1_Library2
{
   /// <summary>
   /// Класс для хранения данных о тесте
   /// </summary>
   public class TestInfo : IComparable
   {
      string studentName;
      public string StudentName
      {
         get
         {
            return studentName;
         }
      }
      string testName;
      public string TestName
      {
         get
         {
            return testName;
         }
      }
      DateTime date;
      public DateTime Date
      {
         get
         {
            return date;
         }
      }
      int score;
      public int Score
      {
         get
         {
            return score;
         }
      }

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

      public string ToString()
      {
         return String.Format("Имя студента: {0}\nНазвание теста: {1}\nОценка за тест: {2}\nДата:{3},{4},{5}", this.StudentName, this.TestName, this.Score, this.Date.Year, this.Date.Month, this.Date.Day);
      }
   } // end of TestInfo
}
