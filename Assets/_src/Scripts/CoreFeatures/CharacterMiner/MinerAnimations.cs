using _src.Scripts.Utils;
using Cysharp.Threading.Tasks;
using TetraCreations.Attributes;
using UnityEngine;
using Zenject;


namespace _src.Scripts.CoreFeatures.CharacterMiner
{
	public class MinerAnimations : MonoBehaviour
	{
		private Animator _animator;
		
		public Animator MinerAnimator => _animator;

		[SerializeField, Required]
		private Transform _mineOreDetector;
		
		private static readonly int TriggerName = Animator.StringToHash("Mine");
		private static readonly int IdleStateName = Animator.StringToHash("Idle");


		[Inject]
		private MessageBus _messageBus;
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

		//Invoking in animator
		public void PlayHitPickaxeFeedbacks()
		{
			var results = new Collider[10];
			Physics.OverlapSphereNonAlloc(_mineOreDetector.position, 1.5f, results);

			if (results.Length > 0)
			{
				foreach (var collider in results)
				{
					if (collider && collider.gameObject.TryGetComponent(out MineOre mineOre))
					{
						mineOre.PickAxeHit.PlayFeedbacks();
						_messageBus.Invoke(BusMessages.OnOreHit, new OreHitSignal(mineOre.OreType));
					}
				}
			}
			
		}
	}
}
