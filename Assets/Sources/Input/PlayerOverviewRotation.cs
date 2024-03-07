using Infrastructure.Services.InputService;
using UnityEngine;

namespace Sources.Input
{
    public class PlayerOverviewRotation : MonoBehaviour
    {
        [SerializeField] private IInputProcessingService _inputProcessor;
        [SerializeField] private Rigidbody _playerRigidbody;

        [SerializeField] private float _rotationSensitivity = 5.0f;

        private float _startTouchPositionX, _currentTouchPositionX;
        private bool _isSubscribed;

        public void Construct(IInputProcessingService inputProcessor, Rigidbody charRb)
        {
            _inputProcessor = inputProcessor;
            _playerRigidbody = charRb;
            SubscribeInputEvents();
        }

        private void OnEnable()
        {
            if (_inputProcessor != null)
            {
                _inputProcessor.OnTouchStarted += OnTouchStarted;
                _inputProcessor.OnTouchPerformed += OnTouchPerformed;
            }
        }

        private void SubscribeInputEvents()
        {
            _inputProcessor.OnTouchStarted += OnTouchStarted;
            _inputProcessor.OnTouchPerformed += OnTouchPerformed;
            _isSubscribed = true;
        }

        private void OnDisable()
        {
            if (_isSubscribed)
            {
                _inputProcessor.OnTouchStarted -= OnTouchStarted;
                _inputProcessor.OnTouchPerformed -= OnTouchPerformed;
            }
        }

        private void OnTouchStarted(Vector2 position) => _startTouchPositionX = position.x;

        private void OnTouchPerformed(Vector2 position)
        {
            _currentTouchPositionX = position.x;

            float touchPositionXDifference = _startTouchPositionX - _currentTouchPositionX;

            _playerRigidbody.AddTorque(0, touchPositionXDifference / _rotationSensitivity, 0, ForceMode.Acceleration);
        }
    }
}