using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FortniteHUE.HTTPRequests.HTTPRequests;
using static FortniteHUE.Json.Storage;
namespace FortniteHUE.GameState
{
    public class GameState
    {
        private static FileStream fileStream;
        private static StreamReader streamReader;
        private string gameLogFile;
        public GameState(string logFile)
        {
            gameLogFile = logFile;
        }
        public void getGameState()
        {
            fileStream = File.Open(gameLogFile + @"\FortniteGame\Saved\Logs\FortniteGame.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            streamReader = new StreamReader(fileStream);

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Filter = "FortniteGame.log";
            watcher.Path = gameLogFile + @"\FortniteGame\Saved\Logs\";
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Changed += readNewLines;
            watcher.EnableRaisingEvents = true;
            scanOldLines(new object(), new FileSystemEventArgs(WatcherChangeTypes.Changed, "", ""));
        }
        private static void scanOldLines(object source, FileSystemEventArgs e)
        { while ((streamReader.ReadLine()) != null) { } }
        private static void readNewLines(object source, FileSystemEventArgs e)
        {
            double hue, saturation, value;
            string CurrentLine = "";
            List<string> NewLines = new List<string>();

            if (logFileEmpty())
                streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

            while ((CurrentLine = streamReader.ReadLine()) != null)
            {
                if (CurrentLine != "")
                {
                    NewLines.Add(CurrentLine);
                }
            }
            foreach (string i in NewLines)
            {
                if (i.Contains("to [UI.State.Startup.SubgameSelect]"))
                {
                    ColorToHSV(Color.FromArgb(h.gamestatecolors.mainmenu.r, h.gamestatecolors.mainmenu.g, h.gamestatecolors.mainmenu.b), out hue, out saturation, out value);
                    for (int n = 1; n < h.lightCount + 1; n++)
                        PutRequest("http://" + h.internalIP + "/api/" + h.username + "/lights/" + n + "/state", "{\"on\":true, \"sat\":" + ((float)Math.Round(saturation * 254)) + ", \"bri\":" + ((float)Math.Round(value * 254)) + ",\"hue\":" + ((float)Math.Round(hue * 65565 / 360)) + "}");
                }

                if (i.Contains("to [UI.State.Athena.Frontend]"))
                {
                    ColorToHSV(Color.FromArgb(h.gamestatecolors.battleroyale.r, h.gamestatecolors.battleroyale.g, h.gamestatecolors.battleroyale.b), out hue, out saturation, out value);
                    for (int n = 1; n < h.lightCount + 1; n++)
                        PutRequest("http://" + h.internalIP + "/api/" + h.username + "/lights/" + n + "/state", "{\"on\":true, \"sat\":" + ((float)Math.Round(saturation * 254)) + ", \"bri\":" + ((float)Math.Round(value * 254)) + ",\"hue\":" + ((float)Math.Round(hue * 65565 / 360)) + "}");
                }

                if (i.Contains("to FrontEnd"))
                {
                    ColorToHSV(Color.FromArgb(h.gamestatecolors.savetheworld.r, h.gamestatecolors.savetheworld.g, h.gamestatecolors.savetheworld.b), out hue, out saturation, out value);
                    for (int n = 1; n < h.lightCount + 1; n++)
                        PutRequest("http://" + h.internalIP + "/api/" + h.username + "/lights/" + n + "/state", "{\"on\":true, \"sat\":" + ((float)Math.Round(saturation * 254)) + ", \"bri\":" + ((float)Math.Round(value * 254)) + ",\"hue\":" + ((float)Math.Round(hue * 65565 / 360)) + "}");
                }

                if (i.Contains("NewState: Finished"))
                {
                    ColorToHSV(Color.FromArgb(h.gamestatecolors.matchmakingcompleted.r, h.gamestatecolors.matchmakingcompleted.g, h.gamestatecolors.matchmakingcompleted.b), out hue, out saturation, out value);
                    for (int n = 1; n < h.lightCount + 1; n++)
                        PutRequest("http://" + h.internalIP + "/api/" + h.username + "/lights/" + n + "/state", "{\"on\":true, \"sat\":" + ((float)Math.Round(saturation * 254)) + ", \"bri\":" + ((float)Math.Round(value * 254)) + ",\"hue\":" + ((float)Math.Round(hue * 65565 / 360)) + "}");
                }

                if (i.Contains("current=WaitingPostMatch"))
                {
                    ColorToHSV(Color.FromArgb(h.gamestatecolors.gameended.r, h.gamestatecolors.gameended.g, h.gamestatecolors.gameended.b), out hue, out saturation, out value);
                    for (int n = 1; n < h.lightCount + 1; n++)
                        PutRequest("http://" + h.internalIP + "/api/" + h.username + "/lights/" + n + "/state", "{\"on\":true, \"sat\":" + ((float)Math.Round(saturation * 254)) + ", \"bri\":" + ((float)Math.Round(value * 254)) + ",\"hue\":" + ((float)Math.Round(hue * 65565 / 360)) + "}");
                }

                if (i.Contains("Preparing to exit"))
                {
                    ColorToHSV(Color.FromArgb(h.gamestatecolors.gameexited.r, h.gamestatecolors.gameexited.g, h.gamestatecolors.gameexited.b), out hue, out saturation, out value);
                    for (int n = 1; n < h.lightCount + 1; n++)
                        PutRequest("http://" + h.internalIP + "/api/" + h.username + "/lights/" + n + "/state", "{\"on\":true, \"sat\":" + ((float)Math.Round(saturation * 254)) + ", \"bri\":" + ((float)Math.Round(value * 254)) + ",\"hue\":" + ((float)Math.Round(hue * 65565 / 360)) + "}");
                }

                if (i.Contains("Update State WaitingOnInitialLoad -> InitialLoadComplete"))
                {
                    ColorToHSV(Color.FromArgb(h.gamestatecolors.queuestarted.r, h.gamestatecolors.queuestarted.g, h.gamestatecolors.queuestarted.b), out hue, out saturation, out value);
                    for (int n = 1; n < h.lightCount + 1; n++)
                        PutRequest("http://" + h.internalIP + "/api/" + h.username + "/lights/" + n + "/state", "{\"on\":true, \"sat\":" + ((float)Math.Round(saturation * 254)) + ", \"bri\":" + ((float)Math.Round(value * 254)) + ",\"hue\":" + ((float)Math.Round(hue * 65565 / 360)) + "}");
                }

                if (i.Contains("Player is skydiving from bus"))
                {
                    ColorToHSV(Color.FromArgb(h.gamestatecolors.skydivingstarted.r, h.gamestatecolors.skydivingstarted.g, h.gamestatecolors.skydivingstarted.b), out hue, out saturation, out value);
                    for (int n = 1; n < h.lightCount + 1; n++)
                        PutRequest("http://" + h.internalIP + "/api/" + h.username + "/lights/" + n + "/state", "{\"on\":true, \"sat\":" + ((float)Math.Round(saturation * 254)) + ", \"bri\":" + ((float)Math.Round(value * 254)) + ",\"hue\":" + ((float)Math.Round(hue * 65565 / 360)) + "}");
                }

                if (i.Contains("Player is not skydiving from bus"))
                {
                    ColorToHSV(Color.FromArgb(h.gamestatecolors.skydivingended.r, h.gamestatecolors.skydivingended.g, h.gamestatecolors.skydivingended.b), out hue, out saturation, out value);
                    for (int n = 1; n < h.lightCount + 1; n++)
                        PutRequest("http://" + h.internalIP + "/api/" + h.username + "/lights/" + n + "/state", "{\"on\":true, \"sat\":" + ((float)Math.Round(saturation * 254)) + ", \"bri\":" + ((float)Math.Round(value * 254)) + ",\"hue\":" + ((float)Math.Round(hue * 65565 / 360)) + "}");
                }
            }
        }
        private static bool logFileEmpty()
        {
            long pos = streamReader.BaseStream.Position;
            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            bool empty = streamReader.ReadLine() == null;
            streamReader.BaseStream.Seek(pos, SeekOrigin.Begin);
            return empty;
        }
        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }
    }
}
