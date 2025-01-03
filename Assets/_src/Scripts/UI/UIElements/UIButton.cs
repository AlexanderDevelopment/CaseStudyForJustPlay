using AwesomeAttributes;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace _src.Scripts.UI.UIElements
{
	public abstract class UIButton : MonoBehaviour
	{
		[SerializeField, Required]
		protected MMF_Player ClickFeedbacks;


		[SerializeField, Required]
		protected Button _button;


		public UnityEvent OnButtonClick = new();


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
			OnButtonClick.Invoke();
			if (ClickFeedbacks)
				ClickFeedbacks.PlayFeedbacks();
		}
	}
}
