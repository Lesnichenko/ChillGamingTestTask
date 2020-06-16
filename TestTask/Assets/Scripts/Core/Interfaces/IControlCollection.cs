using System;
using System.Collections.Generic;
using Core.Controllers;

namespace Core.Interfaces
{
    public interface IControlCollection
    {
        Dictionary<Type, ControlBase> Controls { get; }
        
        void FindAllControl();
        void InitAllControl();
        void ReleaseAllControl();
        
        T GetControl<T>() where T : ControlBase;
        bool TryGetControl<T>(out T control) where T : ControlBase;
        
        void EnableControl<T>() where T : ControlBase;
        bool TryEnableControl<T>() where T : ControlBase;
        void EnableAllControl();
        
        void DisableControl<T>() where T : ControlBase;
        bool TryDisableControl<T>() where T : ControlBase;
        void DisableAllControl();
    }
}