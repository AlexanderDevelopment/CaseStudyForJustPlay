using _src.Scripts.Data;


namespace _src.Scripts.CoreFeatures.EventBus
{
	public struct OreHitSignal
	{
		public CurrencyType OreType { get; }


		public OreHitSignal(CurrencyType oreType)
		{
			OreType = oreType;
		}
	}
}
