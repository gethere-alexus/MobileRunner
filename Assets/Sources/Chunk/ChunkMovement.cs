using UnityEngine;

namespace Sources.Chunk
{
    public class ChunkMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 0.1f;

        private void FixedUpdate()
        {
            this.gameObject.transform.Translate(-_movementSpeed, 0, 0, Space.World);
        }

        public float MovementSpeed
        {
            set => _movementSpeed = value;
        }
    }
}