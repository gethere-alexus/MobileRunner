using UnityEngine;


public class ChunkCleaner : MonoBehaviour
{
    private float _destroyAtXPosition = -1.5f;

    private void FixedUpdate()
    {
        if (this.gameObject.transform.position.x <= _destroyAtXPosition)
        {
            GlobalEventBus.Sync.Publish(this, new OnChunkDeleted());
            Destroy(this.gameObject);
        }
    }

    public float DestroyAtXPosition { set => _destroyAtXPosition = value; }
}
