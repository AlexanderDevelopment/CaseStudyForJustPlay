using _src.Scripts.CoreFeatures.Currency;
using AYellowpaper.SerializedCollections;
using UnityEngine;


namespace _src.Scripts.Data
{
	[CreateAssetMenu(fileName = "NewCurrencyData", menuName = "GameData/Currency", order = 1)]
	public class CurrenciesData : ScriptableObject
	{
		public SerializedDictionary<CurrencyType, Currency> GameCurrencies = new();
	}
}
