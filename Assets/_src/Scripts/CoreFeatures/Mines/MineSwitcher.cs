using System;
using System.Linq;
using _src.Scripts.Data;
using AYellowpaper.SerializedCollections;
using UnityEngine;


namespace _src.Scripts.CoreFeatures
{
	public class MineSwitcher : MonoBehaviour, IMineSwitcher
	{
		[SerializeField]
		private SerializedDictionary<CurrencyType, MineOre> _mineOres = new();
		
		private MineOre _activeOre;


		private void Awake()
		{
			_activeOre = _mineOres.FirstOrDefault().Value;
		}


		public void SwitchMine(CurrencyType mineOreType)
		{
			_activeOre.HideMine.PlayFeedbacks();
			_mineOres[mineOreType].ShowMine.PlayFeedbacks();
			_activeOre = _mineOres[mineOreType];
		}
		
	}
}
