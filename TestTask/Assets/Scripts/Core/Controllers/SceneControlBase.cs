using System;
using System.Collections;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Managers;
using Core.Wrappers;
using Tools.Find;
using UnityEngine;

namespace Core.Controllers
{
    public abstract class SceneControlBase : MonoBehaviorWrapper, IManagerCollection, IControlCollection
    {
        public Dictionary<Type, ControlBase> Controls => _controls;
        public Dictionary<Type, IManager> Managers => _managers;

        private readonly Dictionary<Type, ControlBase> _controls = new Dictionary<Type, ControlBase>();
        private readonly Dictionary<Type, IManager> _managers = new Dictionary<Type, IManager>();

        #region Methods for working with SceneControlBase
        
        #region Unity base events

        private void Awake()
        {
            FindAllManager();
            FindAllControl();
        }

        protected virtual IEnumerator Start()
        {
            InitAllManager();
            InitAllControl();
            yield return Init();
        }

        private void OnDestroy()
        {
            ReleaseAllManager();
            ReleaseAllControl();
        }

        #endregion
        
        protected abstract IEnumerator Init();

        #endregion

        #region Methods for working with Managers

        public void FindAllManager()
        {
            _managers.Clear();

            var managerTypes = FindOfType.GetSubclassListThroughHierarchy<IManager>(false);

            foreach (var managerType in managerTypes)
            {
                var manager = (IManager) Activator.CreateInstance(managerType);
                _managers.Add(managerType, manager);
            }
        }

        public void InitAllManager()
        {
            foreach (var manager in _managers)
            {
                try
                {
                    manager.Value.Init();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }

        public void ReleaseAllManager()
        {
            foreach (var manager in _managers)
            {
                try
                {
                    manager.Value.Release();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }

        public T GetManager<T>() where T : IManager
        {
            var type = typeof(T);
            
            if (_managers.ContainsKey(type))
            {
                return (T) _managers[type];
            }
            
            return default(T);
        }

        public bool TryGetManager<T>(out T manager) where T : IManager
        {
            manager = GetManager<T>();
            return manager != null;
        }

        #endregion
        
        #region Methods for working with Controls
        
        public void FindAllControl()
        {
            _controls.Clear();
            
            var controls = FindObjectsOfType(typeof(ControlBase)) as ControlBase[];
            
            if (controls == null) return;
            
            foreach (var control in controls)
            {
                control.SceneController = this;
                _controls.Add(control.GetType(), control);
            }
        }

        public void InitAllControl()
        {
            foreach (var control in _controls)
            {
                try
                {
                    control.Value.Init();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }

        public void ReleaseAllControl()
        {
            foreach (var control in _controls)
            {
                try
                {
                    control.Value.Release();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }

        public T GetControl<T>() where T : ControlBase
        {
            var type = typeof(T);
            if (_controls.ContainsKey(type))
            {
                return (T) _controls[type];
            }
            return default(T);
        }

        public bool TryGetControl<T>(out T control) where T : ControlBase
        {
            control = GetControl<T>();
            return control != null;
        }

        public void EnableControl<T>() where T : ControlBase
        {
            if (TryGetControl(out T control))
            {
                control.Enable();
            }
        }

        public bool TryEnableControl<T>() where T : ControlBase
        {
            if (TryGetControl(out T control))
            {
                control.Enable();
                return true;
            }
            
            return false;
        }

        public void EnableAllControl()
        {
            foreach (var control in _controls)
            {
                control.Value.Enable();
            }
        }

        public void DisableControl<T>() where T : ControlBase
        {
            if (TryGetControl(out T control))
            {
                control.Enable();
            };
        }

        public bool TryDisableControl<T>() where T : ControlBase
        {
            if (TryGetControl(out T control))
            {
                control.Disable();
                return true;
            }
            
            return false;
        }

        public void DisableAllControl()
        {
            foreach (var control in _controls)
            {
                control.Value.Disable();
            }
        }
        
        #endregion
        
    }
}