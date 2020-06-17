using System;
using Models.Fighter;

namespace Models.Fight
{
    [Serializable]
    public class FightSettings
    {
        public BuffSettings buffSettings;
        public Stat[] statsCollection;
        public Buff[] buffsCollection;

        public FightSettings(BuffSettings buffSettings, Stat[] statsCollection, Buff[] buffsCollection)
        {
            this.buffSettings = buffSettings;
            this.statsCollection = statsCollection;
            this.buffsCollection = buffsCollection;
        }
    }
}