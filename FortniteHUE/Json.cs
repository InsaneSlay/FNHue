using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteHUE.Json
{
    public static class Storage
    {
        public static dynamic jsonObj;
        public static hueJson h;
        public class hueJson
        {
            public string internalIP { get; set; }
            public string bridgeID { get; set; }
            public string username { get; set; }
            public int lightCount { get; set; }
            public GameStateColors gamestatecolors { get; set; }
        }
        public class GameStateColors
        {
            public MainMenu mainmenu { get; set; }
            public BattleRoyale battleroyale { get; set; }
            public SaveTheWorld savetheworld { get; set; }
            public MatchmakingCompleted matchmakingcompleted { get; set; }
            public GameEnded gameended { get; set; }
            public GameExited gameexited { get; set; }
            public QueueStarted queuestarted { get; set; }
            public SkydivingStarted skydivingstarted { get; set; }
            public SkydivingEnded skydivingended { get; set; }
        }
        public class MainMenu
        {
            public bool enabled { get; set; }
            public int r { get; set; }
            public int g { get; set; }
            public int b { get; set; }
        }
        public class BattleRoyale
        {
            public bool enabled { get; set; }
            public int r { get; set; }
            public int g { get; set; }
            public int b { get; set; }
        }
        public class SaveTheWorld
        {
            public bool enabled { get; set; }
            public int r { get; set; }
            public int g { get; set; }
            public int b { get; set; }
        }
        public class MatchmakingCompleted
        {
            public bool enabled { get; set; }
            public int r { get; set; }
            public int g { get; set; }
            public int b { get; set; }
        }
        public class GameEnded
        {
            public bool enabled { get; set; }
            public int r { get; set; }
            public int g { get; set; }
            public int b { get; set; }
        }
        public class GameExited
        {
            public bool enabled { get; set; }
            public int r { get; set; }
            public int g { get; set; }
            public int b { get; set; }
        }
        public class QueueStarted
        {
            public bool enabled { get; set; }
            public int r { get; set; }
            public int g { get; set; }
            public int b { get; set; }
        }
        public class SkydivingStarted
        {
            public bool enabled { get; set; }
            public int r { get; set; }
            public int g { get; set; }
            public int b { get; set; }
        }
        public class SkydivingEnded
        {
            public bool enabled { get; set; }
            public int r { get; set; }
            public int g { get; set; }
            public int b { get; set; }
        }
    }
}
