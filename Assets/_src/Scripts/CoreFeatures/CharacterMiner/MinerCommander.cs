using System;
using System.Threading;
using _src.Scripts.Tools;
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


		public async UniTask CommandToChangeAnimationsSpeed(float animationSpeed, float duration, CancellationToken ct)
		{
			var cachedAnimatorSpeed = _minerAnimations.MinerAnimator.speed;
			_minerAnimations.MinerAnimator.speed = animationSpeed;
			await UniTask.Delay(TimeSpan.FromSeconds(duration), cancellationToken: ct);
			_minerAnimations.MinerAnimator.speed = cachedAnimatorSpeed;
		}
	}
}
