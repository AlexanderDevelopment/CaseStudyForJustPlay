using System;
using _src.Scripts.Data;
using UnityEngine;
using UnityEngine.Events;


namespace _src.Scripts.CoreFeatures
{
	[Serializable]
	public class Currency
	{
		public CurrencyType CurrencyType;

		
		public Sprite CurrencyIcon;

		public Sprite CurrencyButtonSprite;


		public int Value => _value;


		private int _value;


		[HideInInspector]
		public UnityEvent<int> OnValueChanged = new();


		public Currency(CurrencyType currencyType, Sprite currencyIcon)
		{
			CurrencyType = currencyType;
			CurrencyIcon = currencyIcon;
			_value = 0;
		}


		public void ChangeValue(int value)
		{
			_value = value;
			OnValueChanged?.Invoke(_value);
		}
	}
}
