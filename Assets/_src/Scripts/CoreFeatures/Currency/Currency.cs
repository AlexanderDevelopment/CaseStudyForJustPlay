using System;
using _src.Scripts.Data;
using UnityEngine;


namespace _src.Scripts.CoreFeatures.Currency
{
	[Serializable]
	public class Currency
	{
		public CurrencyType CurrencyType;

		public Sprite CurrencyIcon;

		public Color TextColor = Color.white;

		public AudioClip CollectSound;

		public Sprite CurrencyButtonSprite;
		


		public Currency(CurrencyType currencyType, Sprite currencyIcon)
		{
			CurrencyType = currencyType;
			CurrencyIcon = currencyIcon;
		}

	}
}
