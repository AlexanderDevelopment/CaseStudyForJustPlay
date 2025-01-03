using _src.Scripts.Data;
using _src.Scripts.UI.Core;
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
        
        private void Start()
        {
            
        }
    }
}