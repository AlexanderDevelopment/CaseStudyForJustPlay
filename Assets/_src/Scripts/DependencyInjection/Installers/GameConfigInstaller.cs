using _src.Scripts.Data;
using Zenject;


namespace _src.Scripts.DependencyInjection.Installers
{
	public class GameConfigInstaller : ScriptableObjectInstaller
	{
		public GameConfig GameConfig;
		
		public override void InstallBindings()
		{
			Container.BindInstances(GameConfig);
		}
	}
}
