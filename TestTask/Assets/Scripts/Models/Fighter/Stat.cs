using System;

namespace Models.Fighter
{
    [Serializable]
    public class Stat
    {
        public int id;
        public string title;
        public string icon;
        public float value;

        public Stat(int id, string title, string icon, float value)
        {
            this.id = id;
            this.title = title;
            this.icon = icon;
            this.value = value >= 0 ? value : 0;
        }
    }
}