using System;
using System.Collections.Generic;
using UnityEngine;

namespace _src.Scripts.UI.Core
{
    public static class UiController
    {
        private static readonly Dictionary<Type, UiWindow> _windows = new();

        public static void AddWindow(UiWindow window)
        {
            if (!_windows.TryAdd(window.GetType(), window))
                Debug.LogError($"[UI] Can't add window, already added: {window.GetType()}");
        }

        public static void RemoveWindow(UiWindow window)
        {
            if (!_windows.Remove(window.GetType()))
                Debug.LogError($"[UI] Can't remove window, not added: {window.GetType()}");
        }

        public static T FindWindow<T>() where T : UiWindow
        {
            return _windows.TryGetValue(typeof(T), out var window) ? (T) window : null;
        }
    }
}