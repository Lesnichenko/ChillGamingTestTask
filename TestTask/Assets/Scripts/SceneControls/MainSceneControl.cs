using System.Collections;
using Controls.Common;
using Controls.Fight;
using Core.Controllers;
using Managers.DataStore;

namespace SceneControls
{
    public class MainSceneControl : SceneControlBase
    {
        protected override IEnumerator Init()
        {
            EnableControl<CameraControl>();
            EnableControl<LightControl>();
            EnableControl<FightControl>();
            yield return null;
        }
    }
}