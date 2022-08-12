// ######################################################################
// BaseDamagableProvider - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using Project.Stats;
using UnityEngine;

namespace Project.Damage
{
    public abstract class BaseDamagableProvider : MonoBehaviour
	{
		#region Delegate(s):
		public event Action<IDamagable> OnDamagableEnterEvent;
		public event Action<IDamagable> OnDamagableExitEvent;
		#endregion

		#region Inspector Assigned Field(s):
		[SerializeField] protected StatType_SO m_damageStatType;
		#endregion

		#region Internally Used Method(s):
		protected void InvokeOnDamagableEnterEvent(IDamagable _damagable) => OnDamagableEnterEvent?.Invoke(_damagable);
		protected void InvokeOnDamagableExitEvent(IDamagable _damagable) => OnDamagableExitEvent?.Invoke(_damagable);
		#endregion
	}
}
