using _src.Scripts.Data;
using _src.Scripts.Tools;
using _src.Scripts.UI.Core;
using _src.Scripts.UI.UIElements.CurrenciesButtons;
using _src.Scripts.UI.UIElements.CurrenciesIndicators;
using TetraCreations.Attributes;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace _src.Scripts.UI
{
	public class GameHudWindow : UiWindow
	{
		private CurrencyButtonsCollection _currencyButtonsCollection;


		public CurrencyButtonsCollection CurrencyButtonsCollection => _currencyButtonsCollection;


		private CurrencyIndicatorsCollection _currencyIndicatorsCollection;


		public CurrencyIndicatorsCollection CurrencyIndicatorsCollection => _currencyIndicatorsCollection;


		[SerializeField, Required]
		private Canvas _canvas;


		public Canvas Canvas => _canvas;


		[SerializeField, Required]
		private GridLayoutGroup _gridLayoutGroupButtons;


		[SerializeField, Required]
		private HorizontalLayoutGroup _horizontalLayoutGroupIndicators;


		[SerializeField, Required]
		private CurrencyIndicator _currencyIndicatorPrefab;


		[SerializeField, Required]
		private CurrencyButtonUI _currencyButtonUIPrefab;


		[Inject]
		private readonly GameConfig _gameConfig;


		[Inject]
		private IFactory<GameObject, GameObject> _factory;


		protected override void Awake()
		{
			RoutineWork.InitializeComponentFromChildren(gameObject, ref _canvas);
			_currencyButtonsCollection = new CurrencyButtonsCollection(_gridLayoutGroupButtons, _currencyButtonUIPrefab, _gameConfig);
			_currencyButtonsCollection.CreateButtons(_factory);
			_currencyIndicatorsCollection = new CurrencyIndicatorsCollection(_horizontalLayoutGroupIndicators, _currencyIndicatorPrefab, _currencyButtonsCollection.Buttons, _gameConfig);
			_currencyIndicatorsCollection.CreateIndicators(_factory);
			base.Awake();
		}
	}
}
