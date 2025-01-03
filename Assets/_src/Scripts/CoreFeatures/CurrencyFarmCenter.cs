using _src.Scripts.Data;
using _src.Scripts.UI.Core;
using _src.Scripts.UI.CurrenciesButtons;
using _src.Scripts.UI.UIElements;
using UnityEngine;
using Zenject;


namespace _src.Scripts.CoreFeatures
{
    public class CurrencyFarmCenter : MonoBehaviour
    {
        [Inject]
        private GameConfig _gameConfig;


        [Inject]
        private UiController _uiController;
        
        private void Start()
        {
            foreach (var button in _uiController.GameHudWindow.CurrencyButtonsCollection.Buttons.Values)
            {
                button.OnButtonClick.AddListener(ButtonClickHandle);
            }
        }



        private void ButtonClickHandle(UIButton currencyButtonUI)
        {
            if (currencyButtonUI is CurrencyButtonUI currencyButton)
            {
            }
        }
        
    }
}