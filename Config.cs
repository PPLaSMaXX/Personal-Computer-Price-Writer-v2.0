using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPW2
{
    class Config
    {
        public string link;
        public string saveFilePath;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public Config FromJson(string input)
        {
            return JsonConvert.DeserializeObject<Config>(input);
        }

        public bool SaveToFIle(string cfgPath)
        {
            try
            {
                File.WriteAllText(cfgPath, ToJson());
            }
            catch(Exception e) 
            {
                return false;
            }
            return true;
        }

        public bool ReadFromFile(string cfgPath)
        {
            try
            {
                string str = File.ReadAllText(cfgPath);
                Config cfg = FromJson(str);
                link = cfg.link;
                saveFilePath = cfg.saveFilePath;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
