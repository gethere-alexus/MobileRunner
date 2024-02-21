using System;
using Infrastructure.ServiceLocating;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Infrastructure.InputService
{
    public class InputProcessor : MonoBehaviour, IInputProcessingService
    {
        private InputController _inputController;

        private bool _isTouching;
        public event Action<Vector2> OnTouchStarted, OnTouchPerformed, OnTouchEnded;

        private void Awake()
        {
            _inputController = new InputController();
            
            DontDestroyOnLoad(this);
        }

        private void OnEnable()
        {
            _inputController.Enable();

            _inputController.PlayerMovement.PrimaryContact.started += StartTouchPrimary;
            _inputController.PlayerMovement.PrimaryContact.canceled += EndTouchPrimary;
        }

        private void FixedUpdate()
        {
            if (_isTouching)
                OnTouchPerformed?.Invoke(_inputController.PlayerMovement.PrimaryPosition.ReadValue<Vector2>());
        }

        private void OnDisable()
        {
            _inputController.Disable();
        }

        private void StartTouchPrimary(InputAction.CallbackContext ctx)
        {
            _isTouching = true;
            OnTouchStarted?.Invoke(_inputController.PlayerMovement.PrimaryPosition.ReadValue<Vector2>());
        }

        private void EndTouchPrimary(InputAction.CallbackContext ctx)
        {
            _isTouching = false;
            OnTouchEnded?.Invoke(_inputController.PlayerMovement.PrimaryPosition.ReadValue<Vector2>());
        }
    }
}