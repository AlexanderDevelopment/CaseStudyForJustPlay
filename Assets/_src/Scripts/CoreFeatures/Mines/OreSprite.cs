using _src.Scripts.CoreFeatures.EventBus;
using _src.Scripts.Data;
using _src.Scripts.Tools;
using AYellowpaper.SerializedCollections;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace _src.Scripts.CoreFeatures.Mines
{
	public class OreSprite : MonoBehaviour
	{
		[SerializeField]
		private SerializedDictionary<CurrencyType, Sprite> _currencySprites = new();


		private Image _image;
		private RectTransform _rectTransform;
		private OreParticlesSpawner _spawner;
		private Vector3 _initialPosition;
		private CurrencyType _currencyType;
		private float _attractionSpeed;
		private RectTransform _target;
		private bool _isMoving;
		private Vector3 _lastPosition;


		[Inject]
		private MessageBus _messageBus;



		private void Awake()
		{
			RoutineWork.InitializeComponentFromGameObject(gameObject, ref _image);
			RoutineWork.InitializeComponentFromGameObject(gameObject, ref _rectTransform);
		}


		public void Initialize(OreParticlesSpawner spawner, float attractionSpeed, Vector3 initialPosition, RectTransform target, CurrencyType currencyType)
		{
			_spawner = spawner;
			_initialPosition = initialPosition;
			_attractionSpeed = attractionSpeed;
			_target = target;
			_currencyType = currencyType;
			_image.sprite = _currencySprites[currencyType];
		}


		private void Update()
		{
			if (_isMoving)
				MoveToTarget();
		}


		public void StartMove()
		{
			_rectTransform.anchoredPosition = _initialPosition;
			_isMoving = true;
		}


		private void MoveToTarget()
		{
			NativeReference<Vector3> result = new NativeReference<Vector3>(Allocator.TempJob);

			if (_lastPosition == Vector3.zero)
				_lastPosition = _rectTransform.position;

			float speedWithDeltaTime = _attractionSpeed * Time.deltaTime;

			MoveJob moveJob = new MoveJob
			{
				StartPosition = _lastPosition,
				TargetPosition = _target.position,
				Speed = speedWithDeltaTime,
				Result = result,
			};

			JobHandle jobHandle = moveJob.Schedule();
			jobHandle.Complete();

			_rectTransform.position = result.Value;
			_lastPosition = result.Value;

			if (Vector3.Distance(_rectTransform.position, _target.position) <= 0.1f)
			{
				_isMoving = false;
				_messageBus.Invoke(BusMessages.OnOreCollected, new OreCollectedSignal(_currencyType));
				_spawner.ReturnToSpritePool(this);
				_lastPosition = Vector3.zero;
			}

			result.Dispose();
		}
	}
}
