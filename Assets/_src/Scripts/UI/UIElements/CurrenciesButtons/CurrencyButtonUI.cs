using _src.Scripts.Data;
using TetraCreations.Attributes;
using UnityEngine;
using UnityEngine.UI;


namespace _src.Scripts.UI.UIElements.CurrenciesButtons
{
	public class CurrencyButtonUI : UIButton
	{
		[SerializeField, Required]
		private Image _buttonSprite;


		[SerializeField, Required]
		private Image _icon;


		public Image Icon => _icon;


		private CurrencyType _currencyType;


		public CurrencyType CurrencyType => _currencyType;


		public void InitializeFields(Sprite icon, Sprite buttonSprite, CurrencyType currencyType)
		{
			_icon.sprite = icon;
			_buttonSprite.sprite = buttonSprite;
			_currencyType = currencyType;
		}
	}
}
