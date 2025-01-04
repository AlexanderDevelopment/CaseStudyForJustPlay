using System;
using _src.Scripts.CoreFeatures.EventBus;
using _src.Scripts.Data;
using _src.Scripts.Tools;
using Cysharp.Threading.Tasks;
using MoreMountains.Feedbacks;
using TetraCreations.Attributes;
using UnityEngine;
using Zenject;


namespace _src.Scripts.CoreFeatures.Mines
{
	[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
	public class OreParticle : MonoBehaviour
	{
		public CurrencyType OreType;


		[SerializeField, Required]
		private MMF_Player ReturnToPoolFeedbacks;


		private Material _material;
		private float _lifetime;
		private OreParticlesSpawner _spawner;

		private Rigidbody _rigidbody;


		[Inject]
		private MessageBus _messageBus;


		private void Awake()
		{
			RoutineWork.InitializeComponentFromGameObject(gameObject, ref _rigidbody);
		}



		public void Initialize(OreParticlesSpawner spawner, float lifeTime)
		{
			_lifetime = lifeTime;
			_spawner = spawner;
		}


		public void SetForce(Vector3 force)
		{
			_rigidbody.velocity = force;
		}


		public async UniTask PlayLifeTimeAndReturnToPool()
		{
			ReturnToPoolFeedbacks.InitialDelay = _lifetime - ReturnToPoolFeedbacks.TotalDuration;
			ReturnToPoolFeedbacks.PlayFeedbacks();
			await UniTask.Delay(TimeSpan.FromSeconds(_lifetime));
			_spawner.ReturnToPool(this);
		}
	}
}
