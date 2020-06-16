using System;
using Core.Interfaces;
using Core.Wrappers;
using Tools.Extensions;
using UnityEngine;

namespace Core.Views
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class ViewBase : MonoBehaviorWrapper, IInitializable, IReleaseble
    {
        private CanvasGroup _canvasGroup;

        public override bool IsEnable => _canvasGroup.IsEnable();

        public virtual void Init()
        {
            CanvasGroupConnect();
        }
        
        public override void Enable()
        {
            _canvasGroup.Show();
        }

        public override void Disable()
        {
            _canvasGroup.Hide();
        }

        public abstract void Release();
        
        private void CanvasGroupConnect()
        {
            if (!TryGetComponent(out _canvasGroup))
            {
                _canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }
        }

        private void OnDestroy()
        {
            Release();
        }
    }
}