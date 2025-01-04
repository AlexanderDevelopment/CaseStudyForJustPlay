using System;
using System.Linq;
using System.Threading;
using _src.Scripts.CoreFeatures.CharacterMiner;
using _src.Scripts.Data.Boosters;
using _src.Scripts.UI.Core;
using Cysharp.Threading.Tasks;
using MoreMountains.Feedbacks;


namespace _src.Scripts.CoreFeatures
{
	[Serializable]
	public class BoosterMineSpeed
	{
		private BoosterMineSpeedConfig _boosterMineSpeedConfig;

		private IMinerCommander _minerCommander;

		private bool _isExecuting;

		private CancellationToken _cancellationToken;

		private UiController _uiController;

		private MMF_Player _boosterMineSpeedFeedbacks;


		public void Initialize(IMinerCommander minerCommander, UiController uiController, BoosterMineSpeedConfig boosterMineSpeedConfig, MMF_Player boosterMineSpeedFeedbacks,
		CancellationToken cancellationToken)
		{
			_minerCommander = minerCommander;
			_uiController = uiController;
			_boosterMineSpeedConfig = boosterMineSpeedConfig;
			_boosterMineSpeedFeedbacks = boosterMineSpeedFeedbacks;
			_cancellationToken = cancellationToken;
		}


		public void ExecuteConditions(object data)
		{
			if (_uiController.GameHudWindow.CurrencyIndicatorsCollection.Indicators.Values.Any(a => a.CurrentValue != 0 && a.CurrentValue % _boosterMineSpeedConfig.ExecuteEachCurrencyCount == 0))
			{
				Execute().Forget();
			}
		}



		private async UniTask Execute()
		{
			if (_isExecuting)
				return;

			_isExecuting = true;
			_boosterMineSpeedFeedbacks.PlayFeedbacks();
			await _minerCommander.CommandToChangeAnimationsSpeed(_boosterMineSpeedConfig.AnimationsSpeed, _boosterMineSpeedConfig.Duration, _cancellationToken);
			_isExecuting = false;
		}
	}
}
