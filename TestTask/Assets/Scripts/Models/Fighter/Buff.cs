using System;

namespace Models.Fighter
{
    [Serializable]
    public class Buff
    {
        public string icon;
        public int id;
        public string title;
        public BuffStat[] stats;

        public Buff(string icon, int id, string title, BuffStat[] stats)
        {
            this.icon = icon;
            this.id = id;
            this.title = title;
            this.stats = stats;
        }
    }
}