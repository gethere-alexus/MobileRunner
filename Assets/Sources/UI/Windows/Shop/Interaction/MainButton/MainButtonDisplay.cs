using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.ServiceLocating;
using Sources.Data;
using Sources.StaticData;
using Sources.UI.Windows.Shop.Interaction.MainButton.StateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Windows.Shop.Interaction.MainButton
{
    public class MainButtonDisplay : MonoBehaviour
    {
        [SerializeField] private SkinShopRepresenter _skinShopRepresenter;
        [SerializeField] private Button _interactionButton;
        
        private ButtonStateMachine<SkinStaticData> _buttonStateMachine;
        

        private void OnEnable()
        {
            _skinShopRepresenter.ShopInitialized += SubscribeSkinShopEvents;
            SubscribeSkinShopEvents();
        }

        private void OnDisable()
        {
            if (_skinShopRepresenter.SkinShopInstance != null)
            {
                _skinShopRepresenter.SkinShopInstance.NewItemPreviewed -= ConstructButton;
            }
            _skinShopRepresenter.ShopInitialized -= SubscribeSkinShopEvents;
        }

        private void SubscribeSkinShopEvents()
        {
            if (_skinShopRepresenter.SkinShopInstance != null)
            {
                _buttonStateMachine = new ButtonStateMachine<SkinStaticData>(_skinShopRepresenter, _interactionButton, ServiceLocator.Container.Single<IAssetProvider>());
                _skinShopRepresenter.SkinShopInstance.NewItemPreviewed += ConstructButton;
            }
        }

        private void ConstructButton(ItemData<SkinStaticData> obj)
        {
            _buttonStateMachine.EnterButtonState(obj);
        }
        
    }
}