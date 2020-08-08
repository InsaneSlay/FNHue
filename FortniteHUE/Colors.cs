using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FortniteHUE.Json.Storage;
namespace FortniteHUE.Colors
{
    public class Colors
    {
        public Color GetColor(int index)
        {
            Color c = Color.Transparent;
            switch(index)
            {
                case 0:
                    c = Color.FromArgb(h.gamestatecolors.mainmenu.r, h.gamestatecolors.mainmenu.g, h.gamestatecolors.mainmenu.b);
                    break;
                case 1:
                    c = Color.FromArgb(h.gamestatecolors.battleroyale.r, h.gamestatecolors.battleroyale.g, h.gamestatecolors.battleroyale.b);
                    break;
                case 2:
                    c = Color.FromArgb(h.gamestatecolors.savetheworld.r, h.gamestatecolors.savetheworld.g, h.gamestatecolors.savetheworld.b);
                    break;
                case 3:
                    c = Color.FromArgb(h.gamestatecolors.queuestarted.r, h.gamestatecolors.queuestarted.g, h.gamestatecolors.queuestarted.b);
                    break;
                case 4:
                    c = Color.FromArgb(h.gamestatecolors.matchmakingcompleted.r, h.gamestatecolors.matchmakingcompleted.g, h.gamestatecolors.matchmakingcompleted.b);
                    break;
                case 5:
                    c = Color.FromArgb(h.gamestatecolors.gameended.r, h.gamestatecolors.gameended.g, h.gamestatecolors.gameended.b);
                    break;
                case 6:
                    c = Color.FromArgb(h.gamestatecolors.gameexited.r, h.gamestatecolors.gameexited.g, h.gamestatecolors.gameexited.b);
                    break;
                case 7:
                    c = Color.FromArgb(h.gamestatecolors.skydivingstarted.r, h.gamestatecolors.skydivingstarted.g, h.gamestatecolors.skydivingstarted.b);
                    break;
                case 8:
                    c = Color.FromArgb(h.gamestatecolors.skydivingended.r, h.gamestatecolors.skydivingended.g, h.gamestatecolors.skydivingended.b);
                    break;
            }
            return c;
        }
        public void SetColor(int index, Color c)
        {
            string sec = "";
            switch (index)
            {
                case 0:
                    sec = "mainmenu";
                    break;
                case 1:
                    sec = "battleroyale";
                    break;
                case 2:
                    sec = "savetheworld";
                    break;
                case 3:
                    sec = "queuestarted";
                    break;
                case 4:
                    sec = "matchmakingcompleted";
                    break;
                case 5:
                    sec = "gameended";
                    break;
                case 6:
                    sec = "gameexited";
                    break;
                case 7:
                    sec = "skydivingstarted";
                    break;
                case 8:
                    sec = "skydivingended";
                    break;
            }

            jsonObj["gamestatecolors"][sec]["r"] = Convert.ToInt32(c.R);
            jsonObj["gamestatecolors"][sec]["g"] = Convert.ToInt32(c.G);
            jsonObj["gamestatecolors"][sec]["b"] = Convert.ToInt32(c.B);
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText("Config//hue.json", output);
        }
        public bool CheckIfEnabled(int index)
        {
            bool b = false;
            switch (index)
            {
                case 0:
                    b = h.gamestatecolors.mainmenu.enabled;
                    break;
                case 1:
                    b = h.gamestatecolors.battleroyale.enabled;
                    break;
                case 2:
                    b = h.gamestatecolors.savetheworld.enabled;
                    break;
                case 3:
                    b = h.gamestatecolors.queuestarted.enabled;
                    break;
                case 4:
                    b = h.gamestatecolors.matchmakingcompleted.enabled;
                    break;
                case 5:
                    b = h.gamestatecolors.gameended.enabled;
                    break;
                case 6:
                    b = h.gamestatecolors.gameexited.enabled;
                    break;
                case 7:
                    b = h.gamestatecolors.skydivingstarted.enabled;
                    break;
                case 8:
                    b = h.gamestatecolors.skydivingended.enabled;
                    break;
            }
            return b;
        }
        public void EnableColor(int index, bool b)
        {
            string sec = "";
            switch (index)
            {
                case 0:
                    sec = "mainmenu";
                    break;
                case 1:
                    sec = "battleroyale";
                    break;
                case 2:
                    sec = "savetheworld";
                    break;
                case 3:
                    sec = "queuestarted";
                    break;
                case 4:
                    sec = "matchmakingcompleted";
                    break;
                case 5:
                    sec = "gameended";
                    break;
                case 6:
                    sec = "gameexited";
                    break;
                case 7:
                    sec = "skydivingstarted";
                    break;
                case 8:
                    sec = "skydivingended";
                    break;
            }

            jsonObj["gamestatecolors"][sec]["enabled"] = b;
            jsonObj["gamestatecolors"][sec]["enabled"] = b;
            jsonObj["gamestatecolors"][sec]["enabled"] = b;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText("Config//hue.json", output);
        }
    }
}
