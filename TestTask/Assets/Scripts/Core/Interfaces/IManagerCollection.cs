using System;
using System.Collections.Generic;
using Core.Managers;

namespace Core.Interfaces
{
    public interface IManagerCollection
    {
        Dictionary<Type, IManager> Managers { get; }

        void FindAllManager();
        void InitAllManager();
        void ReleaseAllManager();
        
        T GetManager<T>() where T : IManager;
        bool TryGetManager<T>(out T manager) where T : IManager;
    }
}