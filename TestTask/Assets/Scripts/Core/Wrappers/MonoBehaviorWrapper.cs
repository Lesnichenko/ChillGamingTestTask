using UnityEngine;

namespace Core.Wrappers
{
    public abstract class MonoBehaviorWrapper : MonoBehaviour
    {
        private Transform _transform;

        public new Transform Transform
        {
            get
            {
                if (_transform == null)
                {
                    _transform = GetComponent<Transform>();
                }

                return _transform;
            }
        }

        public virtual bool IsEnable => gameObject != null && gameObject.activeSelf;

        public virtual void Enable()
        {
            if (!IsEnable) gameObject.SetActive(true);
        }

        public virtual void Disable()
        {
            if (IsEnable) gameObject.SetActive(false);
        }
    }
}