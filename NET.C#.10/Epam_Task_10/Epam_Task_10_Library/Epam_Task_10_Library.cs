using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Epam_Task_10_Library
{
   /// <summary>
   /// Класс который хранит данные о событии
   /// </summary>
   public class TimerEventArgs : EventArgs
   {
      public readonly string msg;
      public TimerEventArgs(string message)
      {
         msg = message;
      }
   }
   /// <summary>
   /// Класс реализует таймер
   /// </summary>
    public class Timer
    {
       /// <summary>
       /// Делегат
       /// </summary>
       public delegate void TimerHandler(object sender, TimerEventArgs e);
       /// <summary>
       /// Событие которое возникает после завершения отсчёта времени
       /// </summary>
       public event TimerHandler EndOfTime;
       /// <summary>
       /// Событие которое возникает каждую секунду
       /// </summary>
       public event TimerHandler EndOfSecond;
       /// <summary>
       /// Метод для вызова события
       /// </summary>
       /// <param name="e">Данные о событии</param>
       protected virtual void OnEndOfSecond(TimerEventArgs e)
       {
          if (EndOfSecond != null)
          {
             EndOfSecond(this, e);
          }
       }
       /// <summary>
       /// Метод для вызова события
       /// </summary>
       /// <param name="e">Данные о событии</param>
       protected virtual void OnEndOfTime(TimerEventArgs e)
       {
          if (EndOfTime != null)
          {
             EndOfTime(this, e);
          }
       }
       /// <summary>
       /// Метод для обратного отсчёта времени, по истечении времени инициирует событие EndOfTime
       /// </summary>
       /// <param name="seconds">Количество секунд</param>
       public void Start(int seconds)
       {
          if (seconds <= 0)
          {
             throw new Exception("Значение времени должно быть больше 0");
          }          
             for (int i = seconds; i > 0; i--)
             {
               OnEndOfSecond(new TimerEventArgs(String.Format("{0}", i)));      
               Thread.Sleep(1000);
             }
             OnEndOfTime(new TimerEventArgs("Time is over!"));
       }
    }
}
