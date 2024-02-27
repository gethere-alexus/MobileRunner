using Infrastructure.Services.ServiceLocating;
using Infrastructure.Services.WindowInstantiator;
using Sources.UI.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Elements.Buttons
{
    [RequireComponent(typeof(Button))]
    public class OpenWindowButton : MonoBehaviour
    {
        [SerializeField] private WindowID _instantiatingWindowID;
        [SerializeField] private Button _button;

        private IWindowInstantiator _windowInstantiator;

        public void OpenWindow()
        {
            _windowInstantiator.InstantiateWindow(_instantiatingWindowID);
        }
        private void Construct()
        {
            _windowInstantiator = ServiceLocator.Container.Single<IWindowInstantiator>();
        }

        private void Awake()
        {
            Construct();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OpenWindow);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OpenWindow);
        }
    }
}