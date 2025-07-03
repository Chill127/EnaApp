using System;
using System.Collections.Generic;

namespace EnaApp.Serif
{
    public class SerifManager//時間帯に応じたセリフをランダムに返すためのクラス
    {
        private Dictionary<string, string[]> serifMap;

        public SerifManager()
        {
            serifMap = new Dictionary<string, string[]>
            {
                { "morning", new[] { "おはようございます。今日はどうなさいますか？","体調は大丈夫ですか？" } },
                { "afternoon", new[] { "お昼です。きちんと昼食はとってくださいね","午後も頑張りましょう。" } },
                { "evening", new[] { "お疲れ様です。もう夜になります。","夕食はどうなさいますか？","今夜提出の課題は把握していますか？" } },
                { "night", new[] { "もう遅いです。就寝の支度をされては？","頑張りすぎです、休まないと明日がきついですよ" } }
            };
        }

        public string GetRandomSerif()//chatGPTより記載。
        {
            string key = GetTimePeriodKey();//時間帯に応じたキーの中身を返す。
            string[] list;

            if (!serifMap.TryGetValue(key, out list))//もし、serifmapにキーが存在しなければ以下を実行(例外処理)
            {
                list = new[] { "…" };//一応[・・・」と静かなキャラクター性を意識
            }

            Random rand = new Random();
            return list[rand.Next(list.Length)];//ランダムの範囲をlistの数にしてある
        }

        private string GetTimePeriodKey()
        {
            int hour = DateTime.Now.Hour;//現在時刻「時(hour)」をだけを取得。以降で応じた条件分岐。

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