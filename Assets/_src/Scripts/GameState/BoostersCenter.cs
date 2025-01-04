using _src.Data.Boosters;
using _src.Scripts.CoreFeatures.CharacterMiner;
using _src.Scripts.UI.Core;
using Cysharp.Threading.Tasks;
using MoreMountains.Feedbacks;
using TetraCreations.Attributes;
using UnityEngine;
using Zenject;


namespace _src.Scripts.CoreFeatures
{
	public class BoostersCenter : MonoBehaviour
	{
		[Inject]
		private UiController _uiController;
		
		[Inject]
		private IMinerCommander _minerCommander;
		
		[Inject]
		private MessageBus _messageBus;


		[SerializeField]
		private BoosterMineSpeed _boosterMineSpeed;
		
		[SerializeField, Required]
		private BoosterMineSpeedConfig _boosterMineSpeedConfig;


		[SerializeField, Required]
		private MMF_Player _boosterMineSpeedFeedbacks;


		private void Start()
		{
			_boosterMineSpeed.Initialize(_minerCommander, _uiController, _boosterMineSpeedConfig, _boosterMineSpeedFeedbacks, gameObject.GetCancellationTokenOnDestroy());
			_messageBus.Subscribe(BusMessages.OnOreCollected, _boosterMineSpeed.ExecuteConditions);
		}


		private void OnDestroy()
		{
			_messageBus.Unsubscribe(BusMessages.OnOreCollected, _boosterMineSpeed.ExecuteConditions);
		}
	}
}
