using Sources.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Sources.Infrastructure
{
    public class ShopMenuInstaller : MonoInstaller
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