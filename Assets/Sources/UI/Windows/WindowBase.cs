using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Windows
{
    public abstract class WindowBase : MonoBehaviour
    {
        [SerializeField] private WindowID _windowID;
        [SerializeField] private Button _closeButton;

        public void Close() =>
            Destroy(this.gameObject);

        protected virtual void OnAwake()
        {
            _closeButton.onClick.AddListener(Close);
        }

        private void Awake()
        {
            OnAwake();
        }
    }
}