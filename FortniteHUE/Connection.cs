using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FortniteHUE.Config;
using static FortniteHUE.HTTPRequests.HTTPRequests;
using static FortniteHUE.Json.Storage;
using static FortniteHUE.GameState.GameState;
using System.Drawing;

namespace FortniteHUE.Connections
{
    public class Connection
    {
        public bool ConnectPhilipsHUE()
        {
            GetPhilipsHueBridgeInfo();
            try
            {
                double hue, saturation, value;
                string t;
                do
                {
                    t = PostRequest($"http://{h.internalIP}/api", "{\"devicetype\":\"fnhue\"}");
                } while (t.Contains("link button not pressed"));
                string username = JObject.Parse(t.Replace("[", "").Replace("]", ""))["success"]["username"].ToString();
                jsonObj["username"] = username;
                string lightData = GetRequest("http://" + h.internalIP + "/api/" + username + "/lights");
                dynamic data = JsonConvert.DeserializeObject(lightData);
                ColorToHSV(Color.Blue, out hue, out saturation, out value);
                int i = 0;
                foreach (var light in data)
                {
                    i++;
                    PutRequest("http://" + h.internalIP + "/api/" + username + "/lights/" + i + "/state", "{\"on\":true, \"sat\":" + ((float)Math.Round(saturation * 254)) + ", \"bri\":" + ((float)Math.Round(value * 254)) + ",\"hue\":" + ((float)Math.Round(hue * 65565 / 360)) + "}");
                }
                jsonObj["lightCount"] = i;
                string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                File.WriteAllText("Config//hue.json", output);
                return true;
            }
            catch
            {
                return false;
            }

        }

        private void GetPhilipsHueBridgeInfo()
        {
            string json = File.ReadAllText("Config//hue.json");
            jsonObj = JsonConvert.DeserializeObject(json);
            JObject j = JObject.Parse(new WebClient().DownloadString("https://discovery.meethue.com/").Replace("[", "").Replace("]", ""));
            jsonObj["internalIP"] = j["internalipaddress"].ToString();
            jsonObj["bridgeID"] = j["id"].ToString();
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText("Config//hue.json", output);
            new Configs("Config//hue.json").Load();
        }
    }
}
