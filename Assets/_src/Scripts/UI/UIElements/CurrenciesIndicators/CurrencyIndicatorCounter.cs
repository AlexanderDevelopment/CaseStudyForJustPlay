using _src.Scripts.CoreFeatures;
using _src.Scripts.Utils;
using UnityEngine;
using Zenject;


namespace _src.Scripts.UI.UIElements.CurrenciesIndicators
{
	public class CurrencyIndicatorCounter : MonoBehaviour
	{
		private CurrencyIndicator _currencyIndicator;


		[Inject]
		private MessageBus _messageBus;

		private void Awake()
		{
			RoutineWork.InitializeComponentFromGameObject(gameObject, ref _currencyIndicator);
			_messageBus.Subscribe(BusMessages.OnOreCollected, OreCollectedHandle);
		}


		private void OnDestroy()
		{
			_messageBus.Unsubscribe(BusMessages.OnOreCollected, OreCollectedHandle);
		}


		private void OreCollectedHandle(object data)
		{
			if (data is OreCollectedSignal oreCollectedSignal)
			{
				if (_currencyIndicator.CurrencyType == oreCollectedSignal.OreType)
				{
					//TODO Add value multiplier
					_currencyIndicator.AddValue(1);
				}
			}
		}
	}
}
