using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam_Task6_1_Library;

namespace Epam_Task6_1_ConsoleApplication
{
   class Epam_Task6_1_ConsoleApplication
   {
      static void Main(string[] args)
      {
         ProgramConverter[] a = new ProgramConverter[4];
         a[0] = new ProgramConverter();
         a[1] = new ProgramHelper();
         a[2] = new ProgramConverter();
         a[3] = new ProgramHelper();
         foreach (ProgramConverter b in a)
         {
            b.ConvertToCSharp("aaa");
         }
         foreach (ProgramConverter b in a)
         {
            if (b is ProgramHelper)
            {

               ProgramHelper g = (ProgramHelper)b;
               if (g.CodeCheckSyntax("Код CSharp", "CSharp"))
               {
                  Console.WriteLine("Это код CSharp");
               }
            }
         }

         Console.ReadLine();
      }
   }
}
