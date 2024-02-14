using Shop_Scripts;
using UnityEngine;
using Zenject;

namespace Settings.Infrastructure
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
