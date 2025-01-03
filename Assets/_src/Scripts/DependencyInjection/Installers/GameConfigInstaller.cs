using _src.Scripts.CoreFeatures;
using _src.Scripts.CoreFeatures.CharacterMiner;
using _src.Scripts.Data;
using _src.Scripts.UI.Core;
using UnityEngine;
using Zenject;


namespace _src.Scripts.DependencyInjection.Installers
{
	[CreateAssetMenu(menuName = "GameData/Zenject/Game Settings Installer")]
	public class GameConfigInstaller : ScriptableObjectInstaller<GameConfigInstaller>
	{
		public GameConfig GameConfig;
		public UiController UiController;
		
		public override void InstallBindings()
		{
			Container.BindInstances(GameConfig);
			Container
				.Bind<UiController>()
				.FromComponentInNewPrefab(UiController)
				.AsSingle();
			Container.Bind<IMinerCommander>()
				.FromComponentInHierarchy()
				.AsSingle();
			Container.Bind<IMineSwitcher>()
				.FromComponentInHierarchy()
				.AsSingle();
		}
	}
}
