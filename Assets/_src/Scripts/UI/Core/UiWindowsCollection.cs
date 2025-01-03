using System;
using System.Collections.Generic;
using UnityEngine;

namespace _src.Scripts.UI.Core
{
    public class UiWindowsCollection
    {
        private readonly Dictionary<Type, UiWindow> _windows = new();

        public void AddWindow(UiWindow window)
        {
            if (!_windows.TryAdd(window.GetType(), window))
                Debug.LogError($"[UI] Can't add window, already added: {window.GetType()}");
        }

        public void RemoveWindow(UiWindow window)
        {
            if (!_windows.Remove(window.GetType()))
                Debug.LogError($"[UI] Can't remove window, not added: {window.GetType()}");
        }

        public T FindWindow<T>() where T : UiWindow
        {
            return _windows.TryGetValue(typeof(T), out var window) ? (T) window : null;
        }
    }
}