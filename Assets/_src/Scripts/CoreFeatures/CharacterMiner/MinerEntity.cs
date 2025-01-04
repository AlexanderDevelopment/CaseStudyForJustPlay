using UnityEngine;


namespace _src.Scripts.CoreFeatures.CharacterMiner
{
	public class MinerEntity : MonoBehaviour, IMinerEntity
	{
		private IMinerCommander _minerCommander;


		public IMinerCommander MinerCommander => _minerCommander;


		private IMinerAnimations _minerAnimations;


		public IMinerAnimations MinerAnimations => _minerAnimations;


		private void Awake()
		{
			TryGetComponent(out _minerCommander);
			TryGetComponent(out _minerAnimations);

			if (_minerCommander is null || _minerAnimations is null)
				Debug.LogError("Miner entity initialisation references is failed", gameObject);
		}
	}
}
