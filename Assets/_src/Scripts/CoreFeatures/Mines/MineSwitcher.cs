using System.Linq;
using _src.Scripts.Data;
using AYellowpaper.SerializedCollections;
using TetraCreations.Attributes;
using UnityEngine;
using Random = UnityEngine.Random;


namespace _src.Scripts.CoreFeatures.Mines
{
	public class MineSwitcher : MonoBehaviour, IMineSwitcher
	{
		[SerializeField]
		private SerializedDictionary<CurrencyType, MineOre> _mineOres = new();


		[SerializeField, ReadOnly]
		private MineOre _activeOre;


		private void Awake()
		{
			_activeOre = _mineOres.FirstOrDefault().Value;
		}


		public void SwitchMine(CurrencyType mineOreType)
		{
			if (_activeOre.OreType == mineOreType)
				return;

			_activeOre.HideMine.PlayFeedbacks();
			_mineOres[mineOreType].ShowMine[Random.Range(0, _mineOres[mineOreType].ShowMine.Length)].PlayFeedbacks();
			_activeOre = _mineOres[mineOreType];
		}
	}
}
