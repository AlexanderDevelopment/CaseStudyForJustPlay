using _src.Scripts.CoreFeatures;
using UnityEngine;


namespace _src.Data.Boosters
{
	[CreateAssetMenu(fileName = "MineSpeedConfig", menuName = "GameData/Boosters/MineSpeedConfig", order = 1)]
	public class BoosterMineSpeedConfig : ScriptableObject
	{
		public float AnimationsSpeed;
		public float Duration;

		public int ExecuteEachCurrencyCount = 200;
	}
}
