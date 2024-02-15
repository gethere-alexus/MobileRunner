using Sources.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Sources.Infrastructure
{
    public class PlayerConfigInstaller : MonoInstaller
    {
        [SerializeField] private CharacterConfig _playerConfig;

        public override void InstallBindings()
        {
            Container
                .Bind<CharacterConfig>()
                .FromInstance(_playerConfig)
                .AsSingle();
        }
    }
}