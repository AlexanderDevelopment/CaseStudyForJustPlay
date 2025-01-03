using System.Collections.Generic;
using _src.Scripts.Data;
using _src.Scripts.UI.Core;
using AYellowpaper.SerializedCollections;
using Cysharp.Threading.Tasks;
using TetraCreations.Attributes;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;


namespace _src.Scripts.CoreFeatures
{
	public class ParticleSpawner : MonoBehaviour
	{
		[SerializeField]
		private SerializedDictionary<CurrencyType, OreParticle> _oreParticles = new();


		[SerializeField]
		private OreSprite _oreSpritePrefab2D;


		[SerializeField]
		private AnimationCurve _movementCurve;


		[SerializeField]
		private float _lifetime = 5f;


		[SerializeField]
		private float _attractionDuration = 5f;


		[SerializeField]
		[MinMaxSlider(0, 2)]
		private Vector2 MinMaxSliderForce;


		[SerializeField]
		private float _initialScale = 0.034f;


		[SerializeField]
		private int _poolSize = 30;


		private Dictionary<CurrencyType, Queue<OreParticle>> _particlePools = new();
		private Queue<OreSprite> _spritePool = new();


		[Inject]
		private MessageBus _messageBus;


		[Inject]
		private UiController _uiController;


		[Inject]
		private IFactory<GameObject, GameObject> _factory;


		private void Start()
		{
			foreach (var oreParticlePair in _oreParticles)
			{
				_particlePools[oreParticlePair.Key] = new Queue<OreParticle>();

				for (int i = 0; i < _poolSize; i++)
				{
					var particleInstance = CreateNewParticle(oreParticlePair.Key);
					_particlePools[oreParticlePair.Key].Enqueue(particleInstance);
					particleInstance.gameObject.SetActive(false);
				}
			}

			_spritePool = new Queue<OreSprite>();

			for (int i = 0; i < _poolSize; i++)
			{
				var spriteInstance = CreateNewOreSprite();
				_spritePool.Enqueue(spriteInstance);
				spriteInstance.gameObject.SetActive(false);
			}

			_messageBus.Subscribe(BusMessages.OnOreHit, OreHitHandler);
		}


		private void OnDestroy()
		{
			_messageBus.Unsubscribe(BusMessages.OnOreHit, OreHitHandler);
		}


		private void OreHitHandler(object data)
		{
			if (data is OreHitSignal oreHitSignal)
			{
				SpawnParticles(10, oreHitSignal.OreType);
			}
		}


		private void SpawnParticles(int count, CurrencyType particleType)
		{
			for (int i = 0; i < count; i++)
			{
				OreParticle particle = GetParticleFromPool(particleType);
				particle.Initialize(this, _lifetime);

				Vector3 force = new Vector3(Random.Range(-MinMaxSliderForce.x, MinMaxSliderForce.y), Random.Range(MinMaxSliderForce.x, MinMaxSliderForce.y),
					Random.Range(-MinMaxSliderForce.x, MinMaxSliderForce.y)
				);

				particle.transform.position = transform.position;
				particle.SetForce(force);
				particle.PlayLifeTimeAndReturnToPool().Forget();
			}
		}


		public void ReturnToPool(OreParticle particle)
		{
			_particlePools[particle.OreType].Enqueue(particle);
			particle.gameObject.SetActive(false);
			SpawnParticleSprite(particle.OreType, particle.transform.position);
		}


		private void SpawnParticleSprite(CurrencyType spriteType, Vector3 oreParticleWorldPosition)
		{
			{
				OreSprite oreSprite = GetSpriteFromPool();
				var initialPosition = ConvertWorldCoordinatesToCanvas(oreParticleWorldPosition);
				var targetIndicatorPosition = _uiController.GameHudWindow.CurrencyIndicatorsCollection.Indicators[spriteType].transform.GetComponent<RectTransform>();
				oreSprite.Initialize(this, _movementCurve, _attractionDuration, initialPosition, targetIndicatorPosition, spriteType);
				oreSprite.gameObject.SetActive(true);
				oreSprite.MoveToTarget().Forget();
			}
		}


		private Vector2 ConvertWorldCoordinatesToCanvas(Vector3 worldPosition)
		{
			Vector2 viewportPosition = Camera.main.WorldToViewportPoint(worldPosition);
			var canvas = _uiController.GameHudWindow.Canvas.GetComponent<RectTransform>();
			
			Vector2 worldObjectScreenPosition = new Vector2(
				viewportPosition.x * canvas.sizeDelta.x - canvas.sizeDelta.x * 0.5f, 
				viewportPosition.y * canvas.sizeDelta.y - canvas.sizeDelta.y * 0.5f
			);
			
			Vector2 scaledPosition = new Vector2(
				worldObjectScreenPosition.x / canvas.localScale.x, 
				worldObjectScreenPosition.y / canvas.localScale.y
			);

			return scaledPosition;
		}
		


		public void ReturnToSpritePool(OreSprite oreSprite)
		{
			_spritePool.Enqueue(oreSprite);
			oreSprite.gameObject.SetActive(false);
		}


		private OreParticle CreateNewParticle(CurrencyType particleType)
		{
			var newOreParticlePolledObject = _factory.Create(_oreParticles[particleType].gameObject);
			var oreParticle = newOreParticlePolledObject.GetComponent<OreParticle>();
			oreParticle.transform.SetParent(transform);
			oreParticle.transform.localScale = new Vector3(_initialScale, _initialScale, _initialScale);
			oreParticle.gameObject.SetActive(false);

			return oreParticle;
		}


		private OreParticle GetParticleFromPool(CurrencyType particleType)
		{
			if (_particlePools[particleType].Count > 0)
			{
				OreParticle particle = _particlePools[particleType].Dequeue();
				particle.gameObject.SetActive(true);

				return particle;
			}

			var newOreParticle = CreateNewParticle(particleType);

			return newOreParticle;
		}


		private OreSprite GetSpriteFromPool()
		{
			if (_spritePool.Count > 0)
			{
				OreSprite sprite = _spritePool.Dequeue();
				sprite.gameObject.SetActive(true);

				return sprite;
			}

			return CreateNewOreSprite();
		}


		private OreSprite CreateNewOreSprite()
		{
			var canvas = _uiController.GameHudWindow.Canvas.transform;
			OreSprite newOreSprite = Instantiate(_oreSpritePrefab2D, canvas);
			newOreSprite.gameObject.SetActive(false);

			return newOreSprite;
		}
	}
}
