using System;
using Infrastructure.Services.ServiceLocating;
using UnityEngine;

namespace Infrastructure.Services.InputService
{
    internal interface IInputProcessingService : IService
    {
        public event Action<Vector2> OnTouchStarted, OnTouchPerformed, OnTouchEnded;
    }
}