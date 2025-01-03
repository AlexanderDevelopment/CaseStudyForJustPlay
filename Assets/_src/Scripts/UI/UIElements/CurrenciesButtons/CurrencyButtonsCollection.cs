using System.Collections.Generic;
using _src.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;


namespace _src.Scripts.UI.CurrenciesButtons
{
	public class CurrencyButtonsCollection
	{
		private GridLayoutGroup _gridLayoutGroupButtons;
		
		
		private CurrencyButtonUI _currencyButtonUIPrefab;
		
		
		private readonly GameConfig _gameConfig;


		private Dictionary<CurrencyType,CurrencyButtonUI> _buttons = new();


		public Dictionary<CurrencyType, CurrencyButtonUI> Buttons => _buttons;


		public CurrencyButtonsCollection(GridLayoutGroup gridLayoutGroupButtons, CurrencyButtonUI currencyButtonUIPrefab, GameConfig gameConfig)
		{
			_gridLayoutGroupButtons = gridLayoutGroupButtons;
			_currencyButtonUIPrefab = currencyButtonUIPrefab;
			_gameConfig = gameConfig;
		}


		public void CreateButtons()
		{
			foreach (var gameCurrency in _gameConfig.CurrenciesData.GameCurrencies.Values)
			{
				var newCurrencyButton = GameObject.Instantiate(_currencyButtonUIPrefab, _gridLayoutGroupButtons.transform);
				newCurrencyButton.gameObject.name = $"{gameCurrency.CurrencyType.ToString()} UIButton";
				newCurrencyButton.InitializeFields(gameCurrency.CurrencyIcon,gameCurrency.CurrencyButtonSprite , gameCurrency.CurrencyType);
				_buttons.Add(gameCurrency.CurrencyType, newCurrencyButton);
			}
		}
		
	}
}
