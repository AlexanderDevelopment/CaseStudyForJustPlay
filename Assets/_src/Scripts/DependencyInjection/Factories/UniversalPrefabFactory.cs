using UnityEngine;
using Zenject;


namespace _src.Scripts.DependencyInjection.Factories
{
	public class UniversalPrefabFactory: IFactory<GameObject, GameObject>
	{
		private readonly DiContainer _container;

		public UniversalPrefabFactory(DiContainer container)
		{
			_container = container;
		}

		public GameObject Create(GameObject prefab)
		{
			var instance = _container.InstantiatePrefab(prefab);
			_container.Inject(instance);
			return instance;
		}
	}
}
