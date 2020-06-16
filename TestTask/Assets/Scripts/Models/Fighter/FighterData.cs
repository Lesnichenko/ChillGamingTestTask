using System;

namespace Models.Fighter
{
    [Serializable]
    public class FighterData : IFighterData
    {
        public Stat[] Stats => stats;
        public Buff[] Buffs => buffs;
        
        public event Action<IFighterData> OnChangedData;  
        
        private Stat[] stats;
        private Buff[] buffs;

        public FighterData(Stat[] stats, Buff[] buffs)
        {
            this.stats = stats;
            this.buffs = buffs;
            StatCalculation();
            OnChangedData?.Invoke(this);
        }

        private void StatCalculation()
        {
            foreach (var buff in buffs)
            {
                foreach (var buffStat in buff.stats)
                {
                    if (stats.Length < buffStat.statId) continue;
                    stats[buffStat.statId].value += buffStat.value;
                }
            }
        }

        public IFighterData ToDamage()
        {
            stats[0].value = (stats[3].value / 100) * stats[2].value;
            OnChangedData?.Invoke(this);
            return this;
        }

        public void TakeDamage(IFighterData fighterData)
        {
            var damage = (1 - stats[1].value / 100) * fighterData.Stats[2].value;
            if (damage < 0) damage = 0;
            stats[0].value -= damage;
            OnChangedData?.Invoke(this);
        }
    }
}