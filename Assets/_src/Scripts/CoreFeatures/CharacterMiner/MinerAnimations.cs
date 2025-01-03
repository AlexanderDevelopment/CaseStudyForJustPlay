using _src.Scripts.Utils;
using Cysharp.Threading.Tasks;
using UnityEngine;


namespace _src.Scripts.CoreFeatures.CharacterMiner
{
	public class MinerAnimations : MonoBehaviour
	{
		private Animator _animator;

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
	}
}
