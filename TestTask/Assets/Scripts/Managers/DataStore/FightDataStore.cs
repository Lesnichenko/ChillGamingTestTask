using System.Linq;
using Models.Fight;
using Models.Fighter;
using UnityEngine;

namespace Managers.DataStore
{
    public class FightDataStore : IDataStore
    {
        public FighterData RobotFighterData
        {
            get => _robotFighterData;
            set => _robotFighterData = value;
        }

        public FighterData CopFighterData
        {
            get => _copFighterData;
            set => _copFighterData = value;
        }

        private FighterData _robotFighterData = new FighterData(new Stat[0], new Buff[0]);
        private FighterData _copFighterData = new FighterData(new Stat[0], new Buff[0]);
        private FightSettings _fightSettings;

        private const string FIGHT_DATA_PATH = "data";
        
        public void Init()
        {
            LoadFightData(out _fightSettings, FIGHT_DATA_PATH);
            GenerateFight(false);
        }

        public void Release()
        {
            
        }

        public void GenerateFight(bool useBuffs)
        {
            GenerateFighterData(_robotFighterData, _fightSettings, useBuffs);
            
            GenerateFighterData(_copFighterData, _fightSettings, useBuffs);
        }

        private void GenerateFighterData(FighterData fighterData, FightSettings fightSettings, bool useBuffs)
        {
            var stats = GenerateStats(fightSettings);
            
            var buffs = GenerateBuffs(fightSettings, useBuffs);
            
            fighterData.UpdateFighterData(stats, buffs);
        }
        
        private Stat[] GenerateStats(FightSettings fightSettings)
        {
            Stat[] stats = fightSettings.statsCollection;
            
            return stats;
        }
        
        private Buff[] GenerateBuffs(FightSettings fightSettings, bool useBuffs)
        {
            if (!useBuffs) return new Buff[0];

            var countBuffs = Random.Range(fightSettings.buffSettings.buffCountMin, fightSettings.buffSettings.buffCountMax);
            
            var buffs = new Buff[countBuffs];

            if (fightSettings.buffSettings.allowDuplicateBuffs)
            {
                for (int i = 0; i < countBuffs; i++)
                {
                    buffs[i] = fightSettings.buffsCollection[Random.Range(0, fightSettings.buffsCollection.Length)];
                }
            }
            else
            {
                var tempBuffs = fightSettings.buffsCollection.ToList();

                while (tempBuffs.Count > countBuffs)
                {
                    var index = Random.Range(0, tempBuffs.Count);
                    
                    tempBuffs.RemoveAt(index);
                }

                buffs = tempBuffs.ToArray();
            }

            return buffs;
        }

        private void LoadFightData(out FightSettings fightSettings, string path)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(path);
            
            fightSettings = JsonUtility.FromJson<FightSettings>(textAsset.text);
        }
    }
}