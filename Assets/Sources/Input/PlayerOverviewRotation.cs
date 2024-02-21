using Infrastructure.InputService;
using UnityEngine;

namespace Sources.Input
{
    public class PlayerOverviewRotation : MonoBehaviour
    {
        [SerializeField] private InputProcessor _inputProcessor;
        [SerializeField] private Rigidbody _playerRigidbody;

        [SerializeField] private float _rotationSensitivity;

        private float _startTouchPositionX, _currentTouchPositionX;

        private void OnEnable()
        {
            _inputProcessor.OnTouchStarted += OnTouchStarted;
            _inputProcessor.OnTouchPerformed += OnTouchPerformed;
        }

        private void OnDisable()
        {
            _inputProcessor.OnTouchStarted -= OnTouchStarted;
            _inputProcessor.OnTouchPerformed -= OnTouchPerformed;
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