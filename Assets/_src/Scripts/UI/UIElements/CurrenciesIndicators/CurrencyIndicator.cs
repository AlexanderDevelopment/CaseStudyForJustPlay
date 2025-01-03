using _src.Scripts.Data;
using AwesomeAttributes;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace _src.Scripts.UI.UIElements.CurrenciesIndicators
{
	public class CurrencyIndicator : MonoBehaviour
	{
		[SerializeField, Required]
		private TextMeshProUGUI _value;


		[SerializeField]
		private CurrencyType _currencyType;
		
		public CurrencyType CurrencyType => _currencyType;


		[SerializeField, Required]
		private Image _icon;


		[SerializeField, Required]
		private MMF_Player _changeCurrencyValueFeedbacks;


		public void Initialize(int value, Sprite icon, CurrencyType currencyType)
		{
			_value.text = value.ToString();
			_icon.sprite = icon;
			_currencyType = currencyType;
		}


		public void SetValueText(string value)
		{
			_value.text = value;

			if (_changeCurrencyValueFeedbacks)
				_changeCurrencyValueFeedbacks.PlayFeedbacks();
		}
	}
}
