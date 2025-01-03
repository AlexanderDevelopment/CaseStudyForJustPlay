
using TetraCreations.Attributes;
using UnityEngine;


namespace _src.Scripts.UI.Core
{
	public class UiController : MonoBehaviour
	{
		private UiWindowsCollection _uiWindowsCollection = new();



		public UiWindowsCollection UIWindowsCollection => _uiWindowsCollection;


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
		
	}
}
