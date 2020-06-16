using System;
using Models.Fighter;

namespace Models.Fight
{
    [Serializable]
    public class FightSettings
    {
        public BuffSettings buffSettings;
        public Stat[] statsSettings;
        public Buff[] buffsSettings;

        public FightSettings(BuffSettings buffSettings, Stat[] statsSettings, Buff[] buffsSettings)
        {
            this.buffSettings = buffSettings;
            this.statsSettings = statsSettings;
            this.buffsSettings = buffsSettings;
        }
    }
}