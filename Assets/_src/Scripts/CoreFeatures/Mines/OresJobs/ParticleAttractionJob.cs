using Unity.Collections;
using Unity.Jobs;
using UnityEngine;


namespace _src.Scripts.CoreFeatures.OresJobs
{
	public struct ParticleAttractionJob : IJobParallelFor
	{
		public NativeArray<Vector3> positions;
		public NativeArray<Vector3> targetPositions;
		public NativeArray<Vector3> updatedPositions;
		public float attractionSpeed;
		public float deltaTime;
		public NativeArray<bool> isAttracted;

		public void Execute(int index)
		{
			if (!isAttracted[index])  
			{
				Vector3 direction = targetPositions[index] - positions[index];
				float distance = direction.magnitude;
				direction.Normalize();
				
				float moveAmount = attractionSpeed * deltaTime;
				updatedPositions[index] = positions[index] + direction * Mathf.Min(moveAmount, distance);
				
				if (distance < 0.1f)
				{
					updatedPositions[index] = targetPositions[index];
					isAttracted[index] = true;
				}
			}
			else
			{
				updatedPositions[index] = positions[index];
			}
		}
	}


}
