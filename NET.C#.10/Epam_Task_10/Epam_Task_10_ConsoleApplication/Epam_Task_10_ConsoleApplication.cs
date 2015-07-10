using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam_Task_10_Library;

namespace Epam_Task_10_ConsoleApplication
{
   class Epam_Task_10_ConsoleApplication
   {
      static void Main(string[] args)
      {
         Timer firstTimer = new Timer();
         firstTimer.EndOfTime += (a, e) => { Console.Clear(); Console.Write(e.msg); };
         firstTimer.EndOfSecond += (a, e) => { Console.Clear(); Console.Write(e.msg); };
         Console.WriteLine("Введите количество секунд:");
         int time = Convert.ToInt32(Console.ReadLine());
         Console.Clear();
         firstTimer.Start(time);
         Console.ReadLine();
      }
   }
}
