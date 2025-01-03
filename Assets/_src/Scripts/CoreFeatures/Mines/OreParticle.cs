using System;
using System.Linq;
using _src.Scripts.Data;
using _src.Scripts.UI.Core;
using _src.Scripts.Utils;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Unity.Collections;
using UnityEngine;
using Zenject;


namespace _src.Scripts.CoreFeatures
{
	[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
	public class OreParticle : MonoBehaviour
	{
		public CurrencyType OreType;

		private Material _material;
		public float _lifetime = 5f;
		private ParticleSpawner _spawner;

		private Rigidbody _rigidbody;
		private Renderer _renderer;

		[Inject]
		private MessageBus _messageBus;

		private void Awake()
		{
			RoutineWork.InitializeComponentFromGameObject(gameObject, ref _rigidbody);
			RoutineWork.InitializeComponentFromGameObject(gameObject, ref _renderer);
			_material = _renderer.materials[0];
		}

		private void OnDisable()
		{
			_material.SetFloat("_EmissionIntensity", 0);
		}

		public void Initialize(ParticleSpawner spawner,float lifeTime)
		{
			_lifetime = lifeTime;
			_spawner = spawner;
			_material.SetFloat("_EmissionIntensity", 0);
		}
		
		public void SetForce(Vector3 force)
		{
			_rigidbody.velocity = force;
		}


		public async UniTask PlayLifeTimeAndReturnToPool()
		{
			await UniTask.Delay(TimeSpan.FromSeconds(_lifetime));
			_spawner.ReturnToPool(this);
		}
	}

}
