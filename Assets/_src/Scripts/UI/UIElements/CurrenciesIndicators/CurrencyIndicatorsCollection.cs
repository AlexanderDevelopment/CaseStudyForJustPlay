using System.Collections.Generic;
using _src.Scripts.Data;
using _src.Scripts.UI.CurrenciesButtons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace _src.Scripts.UI.UIElements.CurrenciesIndicators
{
	public class CurrencyIndicatorsCollection
	{
		private HorizontalLayoutGroup _horizontalLayoutGroupIndicators;

		private CurrencyIndicator _currencyIndicatorPrefab;

		private readonly GameConfig _gameConfig;

		private Dictionary<CurrencyType, CurrencyButtonUI> _buttons = new();


		private Dictionary<CurrencyType, CurrencyIndicator> _indicators = new();


		public Dictionary<CurrencyType, CurrencyIndicator> Indicators => _indicators;


		public CurrencyIndicatorsCollection(HorizontalLayoutGroup horizontalLayoutGroupIndicators, CurrencyIndicator currencyIndicatorPrefab, Dictionary<CurrencyType, CurrencyButtonUI> buttons,
		GameConfig gameConfig)
		{
			_gameConfig = gameConfig;
			_horizontalLayoutGroupIndicators = horizontalLayoutGroupIndicators;
			_currencyIndicatorPrefab = currencyIndicatorPrefab;
			_buttons = buttons;
		}


		public void CreateIndicators(IFactory<GameObject, GameObject> factory)
		{
			foreach (var button in _buttons.Values)
			{
				var newCurrencyIndicatorGameObject = factory.Create(_currencyIndicatorPrefab.gameObject);
				var newCurrencyIndicator = newCurrencyIndicatorGameObject.GetComponent<CurrencyIndicator>();
				newCurrencyIndicator.transform.SetParent(_horizontalLayoutGroupIndicators.transform);
				newCurrencyIndicator.gameObject.name = $"{button.CurrencyType.ToString()} UIButton Indicator";

				//TODO Add loading last currency value from PlayerPrefs
				newCurrencyIndicator.Initialize(0, button.Icon.sprite, button.CurrencyType, _gameConfig.CurrenciesData.GameCurrencies[button.CurrencyType].TextColor,
					_gameConfig.CurrenciesData.GameCurrencies[button.CurrencyType].CollectSound
				);

				_indicators.Add(button.CurrencyType, newCurrencyIndicator);
			}
		}
	}
}
