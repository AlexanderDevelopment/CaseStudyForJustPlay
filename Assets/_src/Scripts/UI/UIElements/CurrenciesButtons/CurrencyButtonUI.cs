using _src.Scripts.Data;
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
		private Image _icon;


		public Image Icon => _icon;


		private CurrencyType _currencyType;


		public CurrencyType CurrencyType => _currencyType;
		

		public void InitializeFields(Sprite icon, CurrencyType currencyType)
		{
			_icon.sprite = icon;
			_currencyType = currencyType;
		}
	}
}
