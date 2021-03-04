using Newtonsoft.Json;
using System.IO;

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
            catch
            {
                return false;
            }
            return true;
        }

        public Config ReadFromFile(Config cfg, string cfgPath)
        {
            try
            {
                string str = File.ReadAllText(cfgPath);
                cfg = FromJson(str);
            }
            catch
            {
                return null;
            }
            return cfg;
        }
    }
}
