using _src.Scripts.Data;
using _src.Scripts.Utils;
using AYellowpaper.SerializedCollections;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


[BurstCompile]
public struct MoveJob : IJob
{
	public Vector3 StartPosition;
	public Vector3 TargetPosition;
	public NativeReference<Vector3> Result;
	public float Speed;


	public void Execute()
	{
		Result.Value = Vector3.MoveTowards(StartPosition, TargetPosition, Speed);
	}
}


namespace _src.Scripts.CoreFeatures
{
	public class OreSprite : MonoBehaviour
	{
		private float _attractionSpeed;
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


		private bool _isMoving;
		private float _elapsedTime;
		private Vector3 _lastPostion;


		private void Awake()
		{
			RoutineWork.InitializeComponentFromGameObject(gameObject, ref _image);
			RoutineWork.InitializeComponentFromGameObject(gameObject, ref _rectTransform);
		}


		public void Initialize(ParticleSpawner spawner, AnimationCurve movementCurve, float attractionSpeed, Vector3 initialPosition, RectTransform target, CurrencyType currencyType)
		{
			_spawner = spawner;
			_movementCurve = movementCurve;
			_initialPosition = initialPosition;
			_attractionSpeed = attractionSpeed;
			_target = target;
			_currencyType = currencyType;
			_image.sprite = _currencySprites[currencyType];
		}


		private void Update()
		{
			if (_isMoving)
			{
				MoveToTarget();
			}
		}


		public void StartMove()
		{
			_rectTransform.anchoredPosition = _initialPosition;
			_isMoving = true;
			_elapsedTime = 0f;
		}


		private void MoveToTarget()
		{
			_elapsedTime += Time.deltaTime;

			NativeReference<Vector3> result = new NativeReference<Vector3>(Allocator.TempJob);

			if (_lastPostion == Vector3.zero)
				_lastPostion = _rectTransform.position;

			float speedWithDeltaTime = _attractionSpeed * Time.deltaTime;

			MoveJob moveJob = new MoveJob
			{
				StartPosition = _lastPostion,
				TargetPosition = _target.position,
				Speed = speedWithDeltaTime,
				Result = result,
			};

			JobHandle jobHandle = moveJob.Schedule();
			jobHandle.Complete();

			_rectTransform.position = result.Value;
			_lastPostion = result.Value;

			if (Vector3.Distance(_rectTransform.position, _target.position) <= 0.1f)
			{
				_isMoving = false;
				_messageBus.Invoke(BusMessages.OnOreCollected, new OreCollectedSignal(_currencyType));
				_spawner.ReturnToSpritePool(this);
				_lastPostion = Vector3.zero;
			}

			result.Dispose();
		}
	}
}
