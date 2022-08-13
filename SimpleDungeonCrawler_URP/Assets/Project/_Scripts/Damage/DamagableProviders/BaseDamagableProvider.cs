// ######################################################################
// BaseDamagableProvider - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using System.Collections.Generic;
using UnityEngine;
using Project.Stats;

namespace Project.Damage
{
	// TODO: Perhaps the DamageDealerProviders should hold the references to the DamageStatType
	//		 And this should just send out an array of IDamagables in the event(s):
	//		 This will allow for more customization on damage dealth.
	//		 IE: Perhaps health and stamina are damaged but we want to do more damage to stamina.

    public abstract class BaseDamagableProvider : MonoBehaviour
	{
		#region Delegate(s):
		public event Action<IDamagable> OnDamagableEnterEvent;
		public event Action<IDamagable> OnDamagableExitEvent;
		#endregion

		#region Inspector Assigned Field(s):
		[SerializeField] protected List<StatType_SO> m_damageStatTypes;
		#endregion

		#region Internally Used Method(s):
		protected void HandleOnEnter(Collider2D _collider)
		{
			if (!DamageStatTypeCheck()) { return; }

			IDamagable[] damagables = _collider.GetComponents<IDamagable>();
			foreach (var damagable in damagables)
			{
				if (!m_damageStatTypes.Contains(damagable.StatType)) { continue; }
				OnDamagableEnterEvent?.Invoke(damagable);
			}
		}
		protected void HandleOnExit(Collider2D _collider)
		{
			if (!DamageStatTypeCheck()) { return; }

			IDamagable[] damagables = _collider.GetComponents<IDamagable>();
			foreach (var damagable in damagables)
			{
				if (!m_damageStatTypes.Contains(damagable.StatType)) { continue; }
				OnDamagableExitEvent?.Invoke(damagable);
			}
		}

		private bool DamageStatTypeCheck()
		{
			if (m_damageStatTypes == null || m_damageStatTypes.Count == 0) 
			{
				Debug.Log($"{transform.name} is missing at least one reference to a DamageStatType");
				return false; 
			}

			return true;
		}
		#endregion
	}
}
