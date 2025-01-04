using TetraCreations.Attributes;
using UnityEngine;


namespace _src.Scripts.UI.Core
{
	public class UiController : MonoBehaviour
	{
		private UiWindowsCollection _uiWindowsCollection = new();


		public UiWindowsCollection UIWindowsCollection => _uiWindowsCollection;


		public GameHudWindow GameHudWindow => _uiWindowsCollection.FindWindow<GameHudWindow>();


		[Button("ShowMainWindow")]
		public void ShowMainWindow()
		{
			_uiWindowsCollection.FindWindow<GameHudWindow>().Show();
		}


		[Button("HideMainWindow")]
		public void HideMainWindow()
		{
			_uiWindowsCollection.FindWindow<GameHudWindow>().Hide();
		}


		private void Start()
		{
			//Showing start game window
			_uiWindowsCollection.FindWindow<GameHudWindow>().Show();
		}
	}
}
