using Core.Controllers;
using UnityEngine;

namespace Controls.Common
{
    public class LightControl : ControlBase
    {
        [SerializeField] private Light _light;
        
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