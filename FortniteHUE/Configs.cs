using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FortniteHUE.Json.Storage;
namespace FortniteHUE.Config
{
    public class Configs
    {
        private string configDir = "";
        public Configs(string config) => configDir = config;
        public void Load()
        {
            h = JsonConvert.DeserializeObject<hueJson>(File.ReadAllText(configDir));
            string json = File.ReadAllText(configDir);
            jsonObj = JsonConvert.DeserializeObject(json);
        }
        
    }
}
