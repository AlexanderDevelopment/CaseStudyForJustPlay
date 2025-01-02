using _src.Scripts.CoreFeatures;
using UnityEngine;
using Zenject;

namespace _src.Scripts.DependencyInjection.Installers
{
    public class CurrencyFarmCenterInstaller: MonoInstaller
    {
        [SerializeField] private CurrencyFarmCenter _currencyFarmCenter;


        public override void InstallBindings()
        {
            Container
                .Bind<CurrencyFarmCenter>()
                .FromInstance(_currencyFarmCenter);
        }
    }
}