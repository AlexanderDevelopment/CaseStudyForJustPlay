using _src.Scripts.CoreFeatures.CharacterMiner;
using _src.Scripts.Data;
using _src.Scripts.UI.Core;
using _src.Scripts.UI.CurrenciesButtons;
using _src.Scripts.UI.UIElements;
using Cysharp.Threading.Tasks;
using TetraCreations.Attributes;
using UnityEngine;
using Zenject;


namespace _src.Scripts.CoreFeatures
{
	public class CurrencyFarmCenter : MonoBehaviour
	{
		[Inject]
		private GameConfig _gameConfig;


		[Inject]
		private UiController _uiController;


		[Inject]
		private IMinerCommander _minerCommander;


		[Inject]
		private IMineSwitcher _mineSwitcher;


		private void Start()
		{
			foreach (var button in _uiController.GameHudWindow.CurrencyButtonsCollection.Buttons.Values)
			{
				button.OnButtonClick.AddListener(ButtonClickHandle);
			}
		}



		private void ButtonClickHandle(UIButton currencyButtonUI)
		{
			if (currencyButtonUI is CurrencyButtonUI currencyButton)
			{
				MineAsync(currencyButton.CurrencyType).Forget();
			}
		}


		private async UniTask MineAsync(CurrencyType currencyType)
		{
			_mineSwitcher.SwitchMine(currencyType);
			HandleUIButtonsInteractable(false);
			await _minerCommander.CommandToMine();
			HandleUIButtonsInteractable(true);
		}


		private void HandleUIButtonsInteractable(bool value)
		{
			foreach (var button in _uiController.GameHudWindow.CurrencyButtonsCollection.Buttons.Values)
				button.ButtonComponent.interactable = value;
		}
	}
}
