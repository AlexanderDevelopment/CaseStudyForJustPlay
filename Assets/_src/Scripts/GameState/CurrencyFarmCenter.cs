using _src.Scripts.CoreFeatures.CharacterMiner;
using _src.Scripts.CoreFeatures.EventBus;
using _src.Scripts.CoreFeatures.Mines;
using _src.Scripts.Data;
using _src.Scripts.UI.Core;
using _src.Scripts.UI.UIElements.CurrenciesButtons;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;


namespace _src.Scripts.GameState
{
	public class CurrencyFarmCenter : MonoBehaviour
	{
		[Inject]
		private GameConfig _gameConfig;


		[Inject]
		private UiController _uiController;


		[Inject]
		private IMinerEntity _minerEntity;


		[Inject]
		private IMineSwitcher _mineSwitcher;


		[Inject]
		private MessageBus _messageBus;


		private void Start()
		{
			_messageBus.Subscribe(BusMessages.OnButtonClick, ButtonClickHandle);
		}


		private void OnDestroy()
		{
			_messageBus.Unsubscribe(BusMessages.OnButtonClick, ButtonClickHandle);
		}


		private void ButtonClickHandle(object data)
		{
			if (data is OnButtonClickSignal onButtonClickSignal && onButtonClickSignal.Button is CurrencyButtonUI currencyButtonUI)
				MineAsync(currencyButtonUI.CurrencyType).Forget();
		}


		private async UniTask MineAsync(CurrencyType currencyType)
		{
			_mineSwitcher.SwitchMine(currencyType);
			HandleUIButtonsInteractable(false);
			await _minerEntity.MinerCommander.CommandToMine();
			HandleUIButtonsInteractable(true);
		}


		private void HandleUIButtonsInteractable(bool value)
		{
			foreach (var button in _uiController.GameHudWindow.CurrencyButtonsCollection.Buttons.Values)
				button.ButtonComponent.interactable = value;
		}
	}
}
