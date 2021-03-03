using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPW2
{
    class ConfigIO
    {
        public string ToJson(Config cfg)
        {
            return JsonConvert.SerializeObject(cfg);
        }

        public Config FromJson(string input)
        {
            return JsonConvert.DeserializeObject<Config>(input);
        }

        public bool SaveToFIle(Config cfg, string cfgPath)
        {
            try
            {
                File.WriteAllText(cfgPath, ToJson(cfg));
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool ReadFromFile(Config cfg, string cfgPath)
        {
            try
            {
                string str = File.ReadAllText(cfgPath);
                cfg = FromJson(str);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
