using System;
using System.Collections.Generic;

namespace LGUVirtualOffice.Framework {
	public interface IChainEventSubscription
	{
		public int SubscribeCount { get; }
		IChainEventUnSubscribe Subscribe(Type eventType, int actionHashCode, Action onOnSubscribe);
		List<Type> GetEventTypeList();
		public bool IsSubscribed(Type eventType);
		int GetActionHashCode(Type eventType);
		bool UnSubscribe(Type eventType);
	}
}
