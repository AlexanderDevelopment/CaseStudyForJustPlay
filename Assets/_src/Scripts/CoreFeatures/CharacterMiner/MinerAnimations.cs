using _src.Scripts.Utils;
using Cysharp.Threading.Tasks;
using TetraCreations.Attributes;
using UnityEngine;


namespace _src.Scripts.CoreFeatures.CharacterMiner
{
	public class MinerAnimations : MonoBehaviour
	{
		private Animator _animator;


		[SerializeField, Required]
		private Transform _mineOreDetector;
		
		private static readonly int TriggerName = Animator.StringToHash("Mine");
		private static readonly int IdleStateName = Animator.StringToHash("Idle");
		
		private void Awake()
		{
			RoutineWork.InitializeComponentFromGameObject(gameObject, ref _animator);
		}


		public async UniTask PlayMineAnimationAsync()
		{
			_animator.SetTrigger(TriggerName);
			
			await UniTask.WaitUntil(() => 
				_animator.GetCurrentAnimatorStateInfo(0).shortNameHash == IdleStateName
				&& !_animator.IsInTransition(0));
		}


		public void PlayHitPickaxeFeedbacks()
		{
			var results = new Collider[10];
			Physics.OverlapSphereNonAlloc(_mineOreDetector.position, 1, results);

			if (results.Length > 0)
			{
				foreach (var collider in results)
				{
					if (collider && collider.gameObject.TryGetComponent(out MineOre mineOre))
					{
						mineOre.PickAxeHit.PlayFeedbacks();
					}
				}
			}
		}
	}
}
