using Newtonsoft.Json;
using System.IO;

namespace PCPW2
{
    class ConfigIO
    {
        static public string ToJson(Config cfg)
        {
            return JsonConvert.SerializeObject(cfg);
        }

        static public Config FromJson(string input)
        {
            return JsonConvert.DeserializeObject<Config>(input);
        }

        static public bool SaveToFile(Config cfg, string cfgPath)
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

        static public Config ReadFromFile(string cfgPath)
        {
            Config cfg;
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
