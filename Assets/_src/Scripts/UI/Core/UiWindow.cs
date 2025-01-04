using UnityEngine;
using Zenject;


namespace _src.Scripts.UI.Core
{
	public abstract class UiWindow : MonoBehaviour
	{
		[SerializeField]
		protected GameObject _content;


		[Inject]
		protected UiController _uiController;


		protected enum State : byte
		{
			None = 0,
			Shown = 1,
			Hidden = 2,
		}


		protected State _state = State.None;


		protected virtual void Awake()
		{
			Hide();
		}


		protected void OnEnable()
		{
			_uiController.UIWindowsCollection.AddWindow(this);
		}


		protected void OnDisable()
		{
			_uiController.UIWindowsCollection.RemoveWindow(this);
		}


		public void Show()
		{
			if (_state == State.Shown)
				return;

			_state = State.Shown;
			_content.SetActive(true);


			OnShown();
		}


		public void Hide()
		{
			if (_state == State.Hidden)
				return;

			_state = State.Hidden;
			_content.SetActive(false);


			OnHidden();
		}


		protected virtual void OnShown()
		{
		}


		protected virtual void OnHidden()
		{
		}
	}
}
