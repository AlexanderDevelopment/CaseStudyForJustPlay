using System;
using System.Collections.Generic;
using UnityEngine;


namespace _src.Scripts.CoreFeatures.EventBus
{
	public class MessageBus : MonoBehaviour
	{
		private Dictionary<string, Action<object>> _messageListeners = new();


		public void Subscribe(string message, Action<object> listener)
		{
			if (!_messageListeners.TryAdd(message, listener))
			{
				_messageListeners[message] += listener;
			}
		}


		public void Unsubscribe(string message, Action<object> listener)
		{
			if (_messageListeners.ContainsKey(message))
			{
				_messageListeners[message] -= listener;
			}
		}


		public void Invoke(string message, object data = null)
		{
			if (_messageListeners.ContainsKey(message))
			{
				_messageListeners[message]?.Invoke(data);
			}
		}
	}
}
