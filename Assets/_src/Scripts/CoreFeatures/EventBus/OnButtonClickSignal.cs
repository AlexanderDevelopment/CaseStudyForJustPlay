using _src.Scripts.UI.UIElements;


namespace _src.Scripts.CoreFeatures.EventBus
{
	public struct OnButtonClickSignal
	{
		public UIButton Button;


		public OnButtonClickSignal(UIButton button)
		{
			Button = button;
		}
	}
}
