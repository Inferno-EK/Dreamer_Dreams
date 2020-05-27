using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Save
{
    public static class ProgressSave
    {
        public static void SaveProgressTo(string Pash)
        {
            List<string> strings = new List<string>();



            File.WriteAllLines(Pash, strings);
        }
    }
}
