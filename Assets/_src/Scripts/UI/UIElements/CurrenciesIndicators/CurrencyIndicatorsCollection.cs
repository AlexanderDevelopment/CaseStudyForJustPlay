using System.Collections.Generic;
using _src.Scripts.Data;
using _src.Scripts.UI.CurrenciesButtons;
using UnityEngine;
using UnityEngine.UI;


namespace _src.Scripts.UI.UIElements.CurrenciesIndicators
{
	public class CurrencyIndicatorsCollection
	{
		private HorizontalLayoutGroup _horizontalLayoutGroupIndicators;
		
		private CurrencyIndicator _currencyIndicatorPrefab;
		
		private Dictionary<CurrencyType,CurrencyButtonUI> _buttons = new();


		private Dictionary<CurrencyType,CurrencyIndicator> _indicators = new();


		public CurrencyIndicatorsCollection(HorizontalLayoutGroup horizontalLayoutGroupIndicators, CurrencyIndicator currencyIndicatorPrefab, Dictionary<CurrencyType,CurrencyButtonUI> buttons)
		{
			_horizontalLayoutGroupIndicators = horizontalLayoutGroupIndicators;
			_currencyIndicatorPrefab = currencyIndicatorPrefab;
			_buttons = buttons;
		}


		public void CreateIndicators()
		{
			foreach (var button in _buttons.Values)
			{
				var newCurrencyIndicator = GameObject.Instantiate(_currencyIndicatorPrefab, _horizontalLayoutGroupIndicators.transform);
				newCurrencyIndicator.gameObject.name = $"{button.CurrencyType.ToString()} UIButton Indicator";
				//TODO Add loading last currency value from PlayerPrefs
				newCurrencyIndicator.Initialize(0, button.Icon.sprite, button.CurrencyType);
				_indicators.Add(button.CurrencyType,newCurrencyIndicator);
			}
		}
	}
}
