using _src.Scripts.UI.Core;
using Zenject;


namespace _src.Scripts.DependencyInjection.Installers
{
	public class UiControllerInstaller : MonoInstaller
	{

		public UiController UiController;
		public override void InstallBindings()
		{
			Container
				.Bind<UiController>()
				.FromInstance(UiController);
		}
	}
}
