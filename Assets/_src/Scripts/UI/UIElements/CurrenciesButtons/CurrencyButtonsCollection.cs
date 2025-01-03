using System.Collections.Generic;
using _src.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;


namespace _src.Scripts.UI.CurrenciesButtons
{
	public class CurrencyButtonsCollection
	{
		private GridLayoutGroup _verticalLayoutGroup;

		
		private CurrencyButtonUI _currencyButtonUIPrefab;
		
		
		private readonly GameConfig _gameConfig;


		private Dictionary<CurrencyType,CurrencyButtonUI> _buttons = new();


		public CurrencyButtonsCollection(GridLayoutGroup verticalLayoutGroup, CurrencyButtonUI currencyButtonUIPrefab, GameConfig gameConfig)
		{
			_verticalLayoutGroup = verticalLayoutGroup;
			_currencyButtonUIPrefab = currencyButtonUIPrefab;
			_gameConfig = gameConfig;
		}


		public void CreateButtons()
		{
			foreach (var gameCurrency in _gameConfig.CurrenciesData.GameCurrencies.Values)
			{
				var newCurrencyButton = GameObject.Instantiate(_currencyButtonUIPrefab, _verticalLayoutGroup.transform);
				newCurrencyButton.gameObject.name = $"{gameCurrency.CurrencyType.ToString()} UIButton";
				newCurrencyButton.InitializeFields(gameCurrency.CurrencyIcon, gameCurrency.CurrencyType.ToString(), gameCurrency.Value);
				_buttons.Add(gameCurrency.CurrencyType, newCurrencyButton);
			}
		}
	}
}
