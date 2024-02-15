using System;
using Sources.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sources.Input
{
    [DefaultExecutionOrder(-1)]
    public class InputProcessor : MonoBehaviourSingleton<InputProcessor>
    {
        private InputController _inputController;

        private bool _isTouching;
        public event EventHandler<Vector2> OnTouchStarted, OnTouchPerformed, OnTouchEnded;

        private void Awake()
        {
            _inputController = new InputController();
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
                OnTouchPerformed?.Invoke(this, _inputController.PlayerMovement.PrimaryPosition.ReadValue<Vector2>());
        }

        private void OnDisable()
        {
            _inputController.Disable();
        }

        private void StartTouchPrimary(InputAction.CallbackContext ctx)
        {
            _isTouching = true;
            OnTouchStarted?.Invoke(this, _inputController.PlayerMovement.PrimaryPosition.ReadValue<Vector2>());
        }

        private void EndTouchPrimary(InputAction.CallbackContext ctx)
        {
            _isTouching = false;
            OnTouchEnded?.Invoke(this, _inputController.PlayerMovement.PrimaryPosition.ReadValue<Vector2>());
        }
    }
}