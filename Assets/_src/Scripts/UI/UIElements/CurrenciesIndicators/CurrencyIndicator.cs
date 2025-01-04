using _src.Scripts.Data;
using MoreMountains.Feedbacks;
using TetraCreations.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace _src.Scripts.UI.UIElements.CurrenciesIndicators
{
	public class CurrencyIndicator : MonoBehaviour
	{
		[SerializeField, Required]
		private TextMeshProUGUI _textMeshProUGUI;


		public TextMeshProUGUI TextMeshProUGUI => _textMeshProUGUI;


		[SerializeField, Required]
		private ParticleSystem _glowParticles;


		[SerializeField, Required]
		private MMF_Player _changeCurrencyValueFeedbacks;


		private int _currentValue;


		public int CurrentValue => _currentValue;


		[SerializeField]
		private CurrencyType _currencyType;


		public CurrencyType CurrencyType => _currencyType;


		[SerializeField, Required]
		private Image _icon;


		public void Initialize(int value, Sprite icon, CurrencyType currencyType, Color textColor, AudioClip clip)
		{
			_textMeshProUGUI.text = value.ToString();
			_icon.sprite = icon;
			_currencyType = currencyType;
			_currentValue = 0;
			SetValueText(_currentValue.ToString());
			var main = _glowParticles.main;
			main.startColor = textColor;
			_textMeshProUGUI.color = textColor;
			_changeCurrencyValueFeedbacks.GetFeedbackOfType<MMF_Sound>().Sfx = clip;
		}


		public void AddValue(int value)
		{
			_currentValue += value;
			SetValueText(_currentValue.ToString());
			_changeCurrencyValueFeedbacks.PlayFeedbacks();
		}


		private void SetValueText(string value)
		{
			_textMeshProUGUI.text = value;
		}
	}
}
