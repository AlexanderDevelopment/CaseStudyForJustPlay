using System;
using _src.Scripts.Utils;
using Cysharp.Threading.Tasks;
using UnityEngine;


namespace _src.Scripts.CoreFeatures.CharacterMiner
{
	public class MinerCommander : MonoBehaviour, IMinerCommander
	{
		private MinerAnimations _minerAnimations;


		private void Awake()
		{
			RoutineWork.InitializeComponentFromGameObject(gameObject, ref _minerAnimations);
		}


		public async UniTask CommandToMine()
		{
			await _minerAnimations.PlayMineAnimationAsync();
		}
	}
}
