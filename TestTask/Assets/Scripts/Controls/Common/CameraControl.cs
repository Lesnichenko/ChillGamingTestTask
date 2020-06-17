using Core.Controllers;
using UnityEngine;

namespace Controls.Common
{
    public class CameraControl : ControlBase
    {
        [SerializeField] private Camera _camera;
        
        public override void Init()
        {
            
        }

        public override void Enable()
        {
            base.Enable();
        }

        public override void Disable()
        {
            base.Disable();
        }

        public override void Release()
        {
            
        }
    }
}