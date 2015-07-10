using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Task9_Library2
{
    public class MyFile
    {
       string path;
       bool newFile = false;
       bool changed = false;
       public MyFile(string path, bool newFile = false)
       {
          this.path = path;
          this.newFile = newFile;
       }
    }
}
