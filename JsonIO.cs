using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace PCPW2
{
    class JsonIO
    {
        static public string ToJson(List<Preset> presets)
        {
            return JsonConvert.SerializeObject(presets);
        }

        static public List<Preset> FromJson(string input)
        {
            return JsonConvert.DeserializeObject<List<Preset>>(input);
        }

        static public bool SaveToFile(List<Preset> presets, string jsonPath)
        {
            try
            {
                File.WriteAllText(jsonPath, ToJson(presets));
            }
            catch
            {
                return false;
            }
            return true;
        }

        static public List<Preset> ReadFromFile(string jsonPath)
        {
            List<Preset> presets;
            try
            {
                string str = File.ReadAllText(jsonPath);
                presets = FromJson(str);
            }
            catch
            {
                return null;
            }
            return presets;
        }
    }
}
