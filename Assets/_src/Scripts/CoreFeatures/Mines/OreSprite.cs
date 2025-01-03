using System;
using _src.Scripts.Data;
using _src.Scripts.Utils;
using AYellowpaper.SerializedCollections;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace _src.Scripts.CoreFeatures
{
	public class OreSprite : MonoBehaviour
	{
		private float _attractionDuration;
		private RectTransform _target;


		[SerializeField]
		private SerializedDictionary<CurrencyType, Sprite> _currencySprites = new();


		private AnimationCurve _movementCurve;

		private Image _image;

		private RectTransform _rectTransform;
		private ParticleSpawner _spawner;
		private Vector3 _initialPosition;

		private CurrencyType _currencyType;
			
		[Inject]
		private MessageBus _messageBus;


		private void Awake()
		{
			RoutineWork.InitializeComponentFromGameObject(gameObject, ref _image);
			RoutineWork.InitializeComponentFromGameObject(gameObject, ref _rectTransform);
		}


		public void Initialize(ParticleSpawner spawner, AnimationCurve movementCurve, float attractionDuration, Vector2 initialPosition, RectTransform target, CurrencyType currencyType)
		{
			_spawner = spawner;
			_movementCurve = movementCurve;
			_initialPosition = initialPosition;
			_attractionDuration = attractionDuration;
			_target = target;
			_currencyType = currencyType;
			_image.sprite = _currencySprites[currencyType];
		}


		public async UniTask MoveToTarget()
		{
			_rectTransform.anchoredPosition = _initialPosition;
			
			var tweener = _rectTransform.DOMove(_target.position, _attractionDuration).SetEase(_movementCurve);
			
			var timeoutTask = UniTask.Delay(TimeSpan.FromSeconds(_attractionDuration + 0.5f));
			var animationTask = tweener.AsyncWaitForCompletion().AsUniTask();
			await UniTask.WhenAny(animationTask, timeoutTask);
			_messageBus.Invoke(BusMessages.OnOreCollected, new OreCollectedSignal(_currencyType));
			_spawner.ReturnToSpritePool(this);
		}



	}
}
