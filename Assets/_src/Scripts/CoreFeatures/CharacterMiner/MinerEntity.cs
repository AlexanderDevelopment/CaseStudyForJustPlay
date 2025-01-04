using _src.Scripts.Utils;
using UnityEngine;


namespace _src.Scripts.CoreFeatures.CharacterMiner
{
	public class MinerEntity : MonoBehaviour, IMinerEntity
	{
		//For sample
		private MinerAnimations _minerAnimations;
		
		
		
		private void Start()
		{
			RoutineWork.InitializeComponentFromGameObject(gameObject, ref _minerAnimations);
		}


		public MinerAnimations MinerAnimations => _minerAnimations;
	}
}
