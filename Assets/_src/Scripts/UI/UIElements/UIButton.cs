using _src.Scripts.CoreFeatures;
using MoreMountains.Feedbacks;
using TetraCreations.Attributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;


namespace _src.Scripts.UI.UIElements
{
	public abstract class UIButton : MonoBehaviour
	{
		[SerializeField, Required]
		protected MMF_Player ClickFeedbacks;


		[SerializeField, Required]
		protected Button _button;


		[Inject]
		private MessageBus _messageBus;
		
		
		public Button ButtonComponent => _button;
		


		protected void Start()
		{
			_button.onClick.AddListener(Click);
		}


		protected void OnDestroy()
		{
			_button.onClick.RemoveListener(Click);
		}


		private void Click()
		{
			_messageBus.Invoke(BusMessages.OnButtonClick, new OnButtonClickSignal(this));
			if (ClickFeedbacks)
				ClickFeedbacks.PlayFeedbacks();
		}
	}
}
