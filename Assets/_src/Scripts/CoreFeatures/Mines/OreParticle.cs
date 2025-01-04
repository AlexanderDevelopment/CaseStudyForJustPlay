using System;
using System.Linq;
using _src.Scripts.Data;
using _src.Scripts.UI.Core;
using _src.Scripts.Utils;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using MoreMountains.Feedbacks;
using TetraCreations.Attributes;
using Unity.Collections;
using UnityEngine;
using Zenject;


namespace _src.Scripts.CoreFeatures
{
	[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
	public class OreParticle : MonoBehaviour
	{
		public CurrencyType OreType;


		[SerializeField, Required]
		private MMF_Player ReturnToPoolFeedbacks;

		private Material _material;
		private float _lifetime;
		private ParticleSpawner _spawner;

		private Rigidbody _rigidbody;

		[Inject]
		private MessageBus _messageBus;

		private void Awake()
		{
			RoutineWork.InitializeComponentFromGameObject(gameObject, ref _rigidbody);
		}

	

		public void Initialize(ParticleSpawner spawner,float lifeTime)
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
