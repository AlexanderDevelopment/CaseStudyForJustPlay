using UnityEngine;


namespace _src.Scripts.CoreFeatures.CharacterMiner
{
	[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
	public class PickAxe : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out MineOre mineOre))
			{
				mineOre.PickAxeHit.PlayFeedbacks();
			}
		}
	}
}
