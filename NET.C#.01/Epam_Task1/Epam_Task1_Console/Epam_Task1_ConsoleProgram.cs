using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Epam_Task1;

namespace EPAM_Task1_Console
{
   class ConsoleProgram
   {
      static void Main(string[] args)
      {
            FileStream file = new FileStream("Example.txt", FileMode.Open);
            Console.WriteLine("Введите числа:");
            string a = Console.ReadLine();
            Console.WriteLine("From user input:\n{0}",MyConvert.ConvertFunc(a));
            Console.WriteLine("From text file:\n{0}",MyConvert.ConvertFunc(file));
            Console.ReadLine();
      }
   }
}
