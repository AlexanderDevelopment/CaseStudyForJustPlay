using TetraCreations.Attributes;
using UnityEngine;


namespace _src.Scripts.Data
{
	[CreateAssetMenu(fileName = "GameConfig", menuName = "GameData/GameConfig", order = 1)]
	public class GameConfig : ScriptableObject
	{
		[SerializeField, Required]
		private CurrenciesData _currenciesData;


		public CurrenciesData CurrenciesData => _currenciesData;
	}
}
