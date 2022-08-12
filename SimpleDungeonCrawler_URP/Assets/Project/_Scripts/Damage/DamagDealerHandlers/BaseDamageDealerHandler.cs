// ######################################################################
// BaseDamageDealerHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Damage
{
    public abstract class BaseDamageDealerHandler : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private bool m_hideOnExit = false;
		[SerializeField] protected MinMaxFloat m_damageRange;
		[SerializeField] protected AudioSource m_audiosource;
		#endregion


        #region MonoBehaviour Callback Method(s):
		private void Start() => m_audiosource = GetComponent<AudioSource>();
        #endregion

		#region Public API:
		public abstract void HandleOnEnterDamage(IDamagable _damagable);
		public virtual void HandleOnExitDamage(IDamagable _damagable)
		{
			if (m_hideOnExit) { gameObject.SetActive(false); }
		}
		#endregion
	}
}