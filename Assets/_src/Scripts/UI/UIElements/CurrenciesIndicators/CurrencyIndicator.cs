using AwesomeAttributes;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;


namespace _src.Scripts.UI.UIElements.CurrenciesIndicators
{
	public class CurrencyIndicator : MonoBehaviour
	{
		[SerializeField, Required]
		private TextMeshProUGUI _value;


		[SerializeField, Required]
		private MMF_Player _changeCurrencyValueFeedbacks;



		public void SetValueText(string value)
		{
			_value.text = value;
			_changeCurrencyValueFeedbacks.PlayFeedbacks();
		}
		
	}
}
