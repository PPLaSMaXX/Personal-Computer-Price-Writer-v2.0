using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPW2
{
    internal class Preset
    {
        public string Name;
        public string link;
        public string saveFilePath;

        public Preset(string name, string link, string saveFilePath)
        {
            Name = name;
            this.link = link;
            this.saveFilePath = saveFilePath;
        }
    }
}
