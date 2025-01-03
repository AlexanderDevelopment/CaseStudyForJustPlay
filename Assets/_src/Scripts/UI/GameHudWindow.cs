using _src.Scripts.Data;
using _src.Scripts.UI.Core;
using _src.Scripts.UI.CurrenciesButtons;
using _src.Scripts.UI.UIElements.CurrenciesIndicators;
using AwesomeAttributes;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace _src.Scripts.UI
{
    public class GameHudWindow : UiWindow
    {
        private CurrencyButtonsCollection _currencyButtonsCollection;

        private CurrencyIndicatorsCollection _currencyIndicatorsCollection;
        [SerializeField, Required]
        private GridLayoutGroup _gridLayoutGroupButtons;
        
        [SerializeField, Required]
        private HorizontalLayoutGroup _horizontalLayoutGroupIndicators;


        [SerializeField, Required]
        private CurrencyIndicator _currencyIndicatorPrefab;

        [SerializeField, Required]
        private CurrencyButtonUI _currencyButtonUIPrefab;


        [Inject]
        private readonly GameConfig _gameConfig;
        
        
        protected override void Awake()
        {
            _currencyButtonsCollection = new CurrencyButtonsCollection(_gridLayoutGroupButtons, _currencyButtonUIPrefab, _gameConfig);
            _currencyButtonsCollection.CreateButtons();
            _currencyIndicatorsCollection = new CurrencyIndicatorsCollection(_horizontalLayoutGroupIndicators, _currencyIndicatorPrefab, _currencyButtonsCollection.Buttons);
            base.Awake();
            
        }


        private void IndicatorsSync()
        {
            
        }
    }
}