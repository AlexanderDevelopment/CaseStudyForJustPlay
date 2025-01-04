using System.Threading;
using Cysharp.Threading.Tasks;


namespace _src.Scripts.CoreFeatures.CharacterMiner
{
	public interface IMinerCommander
	{
		public UniTask CommandToMine();


		public UniTask CommandToChangeAnimationsSpeed(float animationSpeed, float duration, CancellationToken ct);
	}
}
