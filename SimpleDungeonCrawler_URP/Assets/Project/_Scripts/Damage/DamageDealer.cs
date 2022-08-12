// ######################################################################
// DamageDealer - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.Damage
{
	public class DamageDealer : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private BaseDamagableProvider m_damagableProvider;
		[SerializeField] private List<BaseDamageDealerHandler> m_damageDealerHandlers = new List<BaseDamageDealerHandler>();
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable()
		{
			if (m_damagableProvider == null) {  m_damagableProvider = GetComponent<BaseDamagableProvider>(); }
			if (m_damagableProvider == null)
			{
				Debug.LogError($"{transform.name} is missing a damagable provider!");
				return;
			}

			m_damagableProvider.OnDamagableEnterEvent += DamagableProvider_OnDamagableEnterCallback;
			m_damagableProvider.OnDamagableExitEvent += DamagableProvider_OnDamagableExitCallback;

			if (m_damageDealerHandlers.Count == 0) 
			{
				GetComponents<BaseDamageDealerHandler>(results: m_damageDealerHandlers);
			}
		}

		private void OnDisable()
		{
			if (m_damagableProvider == null) { return; }

			m_damagableProvider.OnDamagableEnterEvent -= DamagableProvider_OnDamagableEnterCallback;
			m_damagableProvider.OnDamagableExitEvent -= DamagableProvider_OnDamagableExitCallback;
		}
        #endregion

        #region Callback(s):
        private void DamagableProvider_OnDamagableEnterCallback(IDamagable _damagable) => 
			m_damageDealerHandlers.ForEach(ddh => ddh.HandleOnEnterDamage(_damagable));

        private void DamagableProvider_OnDamagableExitCallback(IDamagable _damagable) =>
			m_damageDealerHandlers.ForEach(ddh => ddh.HandleOnExitDamage(_damagable));
		#endregion
	}
}
