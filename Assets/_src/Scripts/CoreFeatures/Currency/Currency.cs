using System;
using _src.Scripts.Data;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _src.Scripts.CoreFeatures
{
    [Serializable]
    public class Currency
    {
        public CurrencyType CurrencyType;
        
        public Image CurrencyIcon;

        public int Value => _value;

        private int _value;

        public Currency(CurrencyType currencyType, Image currencyIcon)
        {
            CurrencyType = currencyType;
            CurrencyIcon = currencyIcon;
            _value = 0;
        }
        public UnityEvent<int> OnValueChanged = new();

        public void ChangeValue(int value)
        {
            _value = value;
            OnValueChanged?.Invoke(_value);
        }
    }
}