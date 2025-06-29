using System;
using System.Collections.Generic;

namespace EnaApp.Serif
{
    public class SerifManager
    {
        private Dictionary<string, string[]> serifMap;

        public SerifManager()
        {
            serifMap = new Dictionary<string, string[]>
            {
                { "morning", new[] { "おはようございます。今日はどうなさいますか？" } },
                { "afternoon", new[] { "お昼です。きちんと昼食はとってくださいね" } },
                { "evening", new[] { "お疲れ様です。もう夜になります。" } },
                { "night", new[] { "もう遅いです。就寝の支度をされては？" } }
            };
        }

        public string GetRandomSerif()
        {
            string key = GetTimePeriodKey();
            string[] list;

            if (!serifMap.TryGetValue(key, out list))
            {
                list = new[] { "…" };
            }

            Random rand = new Random();
            return list[rand.Next(list.Length)];
        }

        private string GetTimePeriodKey()
        {
            int hour = DateTime.Now.Hour;

            if (hour >= 6 && hour < 12)
                return "morning";
            else if (hour >= 12 && hour < 18)
                return "afternoon";
            else if (hour >= 18 && hour < 24)
                return "evening";
            else
                return "night";
        }
    }
}