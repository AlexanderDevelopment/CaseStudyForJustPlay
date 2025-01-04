using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;


namespace _src.Scripts.CoreFeatures.Mines
{
	[BurstCompile]
	public struct MoveJob : IJob
	{
		public Vector3 StartPosition;
		public Vector3 TargetPosition;
		public NativeReference<Vector3> Result;
		public float Speed;


		public void Execute()
		{
			Result.Value = Vector3.MoveTowards(StartPosition, TargetPosition, Speed);
		}
	}
}
