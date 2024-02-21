using System;
using Infrastructure.ServiceLocating;
using UnityEngine;

namespace Infrastructure.InputService
{
    internal interface IInputProcessingService : IService
    {
        public event Action<Vector2> OnTouchStarted, OnTouchPerformed, OnTouchEnded;
    }
}