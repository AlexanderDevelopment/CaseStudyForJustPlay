using _src.Scripts.UI.UIElements;
using _src.Scripts.UI.UIElements.CurrenciesIndicators;
using AwesomeAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace _src.Scripts.UI.CurrenciesButtons
{
	public class CurrencyButtonUI : UIButton
	{
		[SerializeField, Required]
		private TextMeshProUGUI _currencyValue;
		
		[SerializeField, Required]
		private TextMeshProUGUI _currencyName;
		

		[SerializeField, Required]
		private Image _icon;


		[SerializeField, Required]
		private CurrencyIndicator _currencyIndicator;


		public CurrencyIndicator CurrencyIndicator => _currencyIndicator;

		public void InitializeFields(Sprite icon, string currencyName, int currencyValue)
		{
			_icon.sprite = icon;
			_currencyName.text = currencyName;
			_currencyValue.text = currencyValue.ToString();
		}
	}
}
