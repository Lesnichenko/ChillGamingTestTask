using System;

namespace Models.Fighter
{
    [Serializable]
    public class BuffSettings
    {
        public int buffCountMin;
        public int buffCountMax;
        public bool allowDuplicateBuffs;
        
        public BuffSettings(int buffCountMin, int buffCountMax, bool allowDuplicateBuffs)
        {
            this.buffCountMin = buffCountMin >= 0 ? buffCountMin : 0;
            this.buffCountMax = buffCountMax >= buffCountMin ? buffCountMax : buffCountMin;
            this.allowDuplicateBuffs = allowDuplicateBuffs;
        }
    }
}