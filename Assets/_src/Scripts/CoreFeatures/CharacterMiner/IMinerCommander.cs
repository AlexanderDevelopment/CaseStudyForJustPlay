using Cysharp.Threading.Tasks;


namespace _src.Scripts.CoreFeatures.CharacterMiner
{
	public interface IMinerCommander
	{
		public UniTask CommandToMine();
	}
}
