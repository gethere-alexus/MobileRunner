using System.Linq;
using Infrastructure.Services.DataProvider;
using Infrastructure.Services.InputService;
using Infrastructure.Services.StaticData;
using Sources.Input;
using Sources.StaticData;
using UnityEngine;

namespace Infrastructure.Services.Factory.Character
{
    public class CharacterFactory : ICharacterFactory
    {
        private const string SpawnPointTag = "SpawnPoint";

        private readonly IStaticDataProvider _staticDataProvider;
        private readonly IProgressProvider _progressProvider;
        private readonly IInputProcessingService _inputService;

        private GameObject _previewInstance;

        public CharacterFactory(IStaticDataProvider staticDataProvider, IProgressProvider progressProvider,
            IInputProcessingService inputService)
        {
            _staticDataProvider = staticDataProvider;
            _progressProvider = progressProvider;
            _inputService = inputService;
        }

        public void CreateCharacterPreview()
        {
            if (_previewInstance != null)
                Object.Destroy(_previewInstance);
            
            SkinStaticData selectedChar = _staticDataProvider.Skins
                .First(data => data.Character == _progressProvider.GetProgress().SelectedSkin);

            Transform initPoint = GameObject.FindWithTag(SpawnPointTag).transform;

            _previewInstance = Object.Instantiate(selectedChar.ItemPrefab, initPoint);
            _previewInstance.AddComponent<PlayerOverviewRotation>().Construct(_inputService,
                _previewInstance.GetComponent<Rigidbody>());
            
        }
    }
}