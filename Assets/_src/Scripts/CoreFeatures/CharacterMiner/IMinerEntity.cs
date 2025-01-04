namespace _src.Scripts.CoreFeatures.CharacterMiner
{
	public interface IMinerEntity
	{
		public IMinerCommander MinerCommander { get; }
		
		public IMinerAnimations MinerAnimations { get; }
	}
}
