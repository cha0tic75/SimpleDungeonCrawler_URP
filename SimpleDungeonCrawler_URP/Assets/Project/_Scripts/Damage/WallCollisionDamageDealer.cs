// ######################################################################
// WallCollisionDamageDealer - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Damage
{
    public class WallCollisionDamageDealer : CollisionDamageDealer
	{
		#region Internal State Field(s):
		private List<IDamagable> m_damagables = new List<IDamagable>();
		private Coroutine m_damageCoroutine = null;
		#endregion
		
		#region MonoBehaviour Callback Method(s):
		private void OnDisable() => StopCoroutineIfRunning();
		#endregion

		#region Internally Used Method(s):
		protected override void HandleEnter2D(IDamagable _damagable)
		{
			if (m_damagables.Contains(_damagable)) { return; }
			
			m_damagables.Add(_damagable);

			Debug.Log($"DamageDealer: {m_damagables.Count}");

			if (m_damageCoroutine == null)
			{
				m_damageCoroutine = StartCoroutine(DamageCoroutine());
			}
		}
		protected override void HandleExit2D(IDamagable _damagable)
		{
			if (m_damagables.Contains(_damagable))
			{
				m_damagables.Remove(_damagable);
			}

			if (m_damagables.Count == 0 && m_damageCoroutine != null)
			{
				StopCoroutineIfRunning();
			}
		}

		private void StopCoroutineIfRunning()
		{
			HelperMethods.StopCoroutineIfRunning(ref m_damageCoroutine, this);
			m_audioSource?.Stop();
		}
		#endregion

		#region Coroutine(s):
		private IEnumerator DamageCoroutine()
		{
			m_audioSource?.Play();
			while (m_damagables.Count > 0)
			{
				foreach (var damagable in m_damagables.ToList())
				{
					damagable.TakeDamage(GetRndDamage());
					yield return null;
				}
				yield return HelperMethods.CustomWFS(m_damageFrequency);
			}

			m_audioSource?.Stop();
			m_damageCoroutine = null;
		}
		#endregion
	}
}
