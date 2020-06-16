using Core.Interfaces;
using Core.Wrappers;

namespace Core.Controllers
{
    public abstract class ControlBase : MonoBehaviorWrapper, IInitializable, IReleaseble
    {
        public SceneControlBase SceneController { set; get; }
        
        public abstract void Init();

        public abstract void Release();
    }
}