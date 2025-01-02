using UnityEngine;

namespace _src.Scripts.UI.Core
{
    [CreateAssetMenu(menuName = "GameData/UiConfig")]
    public class UiConfig : ScriptableObject
    {
        [SerializeField] private GameObject[] _gameWindowPrefabs;

        public GameObject[] GameWindowPrefabs => _gameWindowPrefabs;
    }
}