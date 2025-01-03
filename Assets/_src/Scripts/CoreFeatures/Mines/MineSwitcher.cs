using System;
using System.Linq;
using _src.Scripts.Data;
using AYellowpaper.SerializedCollections;
using TetraCreations.Attributes;
using UnityEngine;


namespace _src.Scripts.CoreFeatures
{
	public class MineSwitcher : MonoBehaviour, IMineSwitcher
	{
		[SerializeField]
		private SerializedDictionary<CurrencyType, MineOre> _mineOres = new();

		[SerializeField,ReadOnly]
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
			_mineOres[mineOreType].ShowMine.PlayFeedbacks();
			_activeOre = _mineOres[mineOreType];
		}
	}
}
