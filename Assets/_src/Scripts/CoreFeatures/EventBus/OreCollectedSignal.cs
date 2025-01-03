using _src.Scripts.Data;


namespace _src.Scripts.CoreFeatures
{
	public struct OreCollectedSignal
	{
		public CurrencyType OreType { get; }

		public OreCollectedSignal(CurrencyType oreType)
		{
			OreType = oreType;
		}
	}
}
