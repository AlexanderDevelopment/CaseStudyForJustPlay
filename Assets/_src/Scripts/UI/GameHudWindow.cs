using _src.Scripts.Data;
using _src.Scripts.UI.Core;
using _src.Scripts.UI.CurrenciesButtons;
using AwesomeAttributes;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace _src.Scripts.UI
{
    public class GameHudWindow : UiWindow
    {
        private CurrencyButtonsCollection _currencyButtonsCollection;


        [SerializeField, Required]
        private GridLayoutGroup _gridLayoutGroup;


        [SerializeField, Required]
        private CurrencyButtonUI _currencyButtonUIPrefab;


        [Inject]
        private readonly GameConfig _gameConfig;
        
        
        protected override void Awake()
        {
            _currencyButtonsCollection = new CurrencyButtonsCollection(_gridLayoutGroup, _currencyButtonUIPrefab, _gameConfig);
            _currencyButtonsCollection.CreateButtons();
            base.Awake();
            
        }
    }
}