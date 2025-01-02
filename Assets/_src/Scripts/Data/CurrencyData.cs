using _src.Scripts.CoreFeatures;
using OpenUnitySolutions.Serialization;
using UnityEngine;

namespace _src.Scripts.Data
{
    [CreateAssetMenu(fileName = "NewCurrencyData", menuName = "Data/", order = 1)]
    public class CurrencyData : ScriptableObject
    {
        public UnityDictionary<CurrencyType, Currency> GameCurrencies = new();
    }
}