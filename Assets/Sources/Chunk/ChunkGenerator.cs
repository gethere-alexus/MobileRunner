using System;
using System.Collections.Generic;
using Infrastructure.GlobalEventBus;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sources.Chunk
{
    public class ChunkGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _chunkPrefabs;
        [SerializeField] private GameObject _chunkStorage;
        [SerializeField] private int _roadLenght = 10;
        [SerializeField] private float _roadMovingSpeed = 0.1f;
        [SerializeField] private float _chunkLenght;

        private List<GameObject> _activeChunks;
        private Vector3 _nextChunkSpawnPosition;

        private GameObject _lastChunk;

        private int _previousChunkIndex;


        private void OnEnable()
        {
            GlobalEventBus.Sync.Subscribe<OnChunkDeleted>(ProcessChunkDeletionSignal);
        }

        private void Awake()
        {
            _previousChunkIndex = -1;
            _nextChunkSpawnPosition = new Vector3(0, 0, 0);
        }

        private void Start()
        {
            for (int i = 0; i < _roadLenght; i++)
            {
                bool isLastSpawn = i == _roadLenght - 1;
                InstantiateChunk(_nextChunkSpawnPosition, isLastSpawn);
                _nextChunkSpawnPosition += new Vector3(_chunkLenght, 0, 0);
            }
        }

        private void OnDisable()
        {
            GlobalEventBus.Sync.Subscribe<OnChunkDeleted>(ProcessChunkDeletionSignal);
        }

        private void ProcessChunkDeletionSignal(object sender, EventArgs eventArgs)
        {
            InstantiateChunk(_lastChunk.transform.position + new Vector3(_chunkLenght - _roadMovingSpeed, 0, 0), true);
        }

        private void InstantiateChunk(Vector3 chunkSpawnPosition, bool isLastChunk)
        {
            int chunkIndex = Random.Range(0, _chunkPrefabs.Length);

            while (chunkIndex == _previousChunkIndex)
            {
                chunkIndex = Random.Range(0, _chunkPrefabs.Length);
            }

            _previousChunkIndex = chunkIndex;

            GameObject instance = Instantiate(_chunkPrefabs[chunkIndex], _chunkStorage.transform);
            instance.transform.position = chunkSpawnPosition;

            if (isLastChunk) _lastChunk = instance.gameObject;

            ChunkCleaner instanceCleaner = instance.GetComponent<ChunkCleaner>();
            instanceCleaner.DestroyAtXPosition = -_chunkLenght;

            ChunkMovement instanceMovement = instance.GetComponent<ChunkMovement>();
            instanceMovement.MovementSpeed = _roadMovingSpeed;
        }
    }
}