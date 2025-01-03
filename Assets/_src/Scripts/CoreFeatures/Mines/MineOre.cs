using _src.Scripts.Data;
using MoreMountains.Feedbacks;
using TetraCreations.Attributes;
using UnityEngine;


namespace _src.Scripts.CoreFeatures
{
	public class MineOre : MonoBehaviour
	{
		public CurrencyType OreType;
		
		[Required]
		public MMF_Player ShowMine;
		[Required]
		public MMF_Player HideMine;


		[Required]
		public MMF_Player PickAxeHit;
	}
}
