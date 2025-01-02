using System;
using _src.Scripts.UI.Core;
using UnityEngine;

namespace _src.Scripts.UI
{
    public class UIInitializer : MonoBehaviour
    {
        private void Start()
        {
            UiController.FindWindow<GameHud>().Show();
        }
    }
}