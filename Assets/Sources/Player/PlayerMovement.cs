using Infrastructure.Services.InputService;
using Infrastructure.Services.ServiceLocating;
using Sources.Input;
using UnityEngine;

namespace Sources.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Transform[] _movementPoints;

        [SerializeField] private float _minimumSwipeDistance = 0.2f;
        [SerializeField] private float _translationSpeed = 0.25f;

        private int _currentMovementPoint = 0;

        private bool _isMovementRequired = false;

        private Vector2 _startPosition, _endPosition;
        private Vector3 _destination;

        private IInputProcessingService _inputProcessor;

        private void Awake()
        {
            _inputProcessor = ServiceLocator.Container.Single<IInputProcessingService>();
        }

        private void OnEnable()
        {
            _inputProcessor.OnTouchStarted += OnTouchStarted;
            _inputProcessor.OnTouchEnded += OnTouchEnded;
        }

        private void FixedUpdate()
        {
            if (_isMovementRequired)
            {
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position,
                    _movementPoints[_currentMovementPoint].position, _translationSpeed);
                _isMovementRequired = Vector3.Distance(this.gameObject.transform.position, _destination) != 0;
            }
        }

        private void OnDisable()
        {
            _inputProcessor.OnTouchStarted -= OnTouchStarted;
            _inputProcessor.OnTouchEnded -= OnTouchEnded;
        }

        private void OnTouchStarted(Vector2 position) => _startPosition = position;

        private void OnTouchEnded(Vector2 position)
        {
            _endPosition = position;
            DetectSwipe(Mathf.Abs(_startPosition.x - _endPosition.x));
        }

        private void DetectSwipe(float distance)
        {
            if (distance >= _minimumSwipeDistance)
            {
                bool isSwipedRight = (_startPosition.x - _endPosition.x) < 0;
                bool isSwipedLeft = (_startPosition.x - _endPosition.x) > 0;

                if (isSwipedRight)
                {
                    _currentMovementPoint += _currentMovementPoint + 1 >= _movementPoints.Length ? 0 : 1;
                }
                else if (isSwipedLeft)
                {
                    _currentMovementPoint -= _currentMovementPoint - 1 < 0 ? 0 : 1;
                }

                _isMovementRequired = true;
                _destination.z = _movementPoints[_currentMovementPoint].position.z;
            }
        }
    }
}