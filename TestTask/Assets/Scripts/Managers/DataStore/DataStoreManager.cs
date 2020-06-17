using Core.Managers;
using UnityEngine;

namespace Managers.DataStore
{
    public class DataStoreManager : IManager
    {
        public FightDataStore FightDataStore { get; set; }

        public void Init()
        {
            FightDataStore = new FightDataStore();
            FightDataStore.Init();
        }

        public void Release()
        {
            FightDataStore.Release();
        }
    }
}