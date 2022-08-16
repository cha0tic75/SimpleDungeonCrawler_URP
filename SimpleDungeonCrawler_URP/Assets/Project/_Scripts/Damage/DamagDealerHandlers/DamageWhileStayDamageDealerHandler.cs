// ######################################################################
// DamageWhileCollidingDamageDealerHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project.Damage
{
    public class DamageWhileStayDamageDealerHandler : BaseDamageDealerHandler
    {
        #region Inspector Assigned Field(s):
        [SerializeField] private float m_damageFrequency = 0.5f;
        #endregion

        #region Internal State Field(s):
		private List<IDamagable> m_damagables = new List<IDamagable>();
		private Coroutine m_damageCoroutine = null;
		#endregion

		#region Public API:
		public override void HandleOnEnterDamage(IDamagable _damagable)
		{
			if (m_damagables.Contains(_damagable)) { return; }
			
			m_damagables.Add(_damagable);

			if (m_damageCoroutine == null)
			{
				m_damageCoroutine = StartCoroutine(DamageCoroutine());
			}
		}
		public override void HandleOnExitDamage(IDamagable _damagable)
        {
			if (m_damagables.Contains(_damagable))
			{
				m_damagables.Remove(_damagable);
			}

			if (m_damagables.Count == 0 && m_damageCoroutine != null)
			{
				StopCoroutineIfRunning();
			}

			base.HandleOnExitDamage(_damagable);
        }
		#endregion

        #region Internally Used Method(s):
		private void StopCoroutineIfRunning() => 
			HelperMethods.StopCoroutineIfRunning(ref m_damageCoroutine, this);
        #endregion

		#region Coroutine(s):
		private IEnumerator DamageCoroutine()
		{
			while (m_damagables.Count > 0)
			{
				foreach (var damagable in m_damagables.ToList())
				{
					damagable.Consume(m_damageRange.GetRandomValueInRange(), ConsumeType.Damage);
					yield return PlayDamageEffects(damagable.GO);
					yield return null;
				}
				yield return HelperMethods.CustomWFS(m_damageFrequency);
			}

			m_damageCoroutine = null;
		}
		private IEnumerator PlayDamageEffects(GameObject _gameObject)
		{
			foreach (var damageEffect in m_damageEffects)
			{
				damageEffect?.PerformEffect(_gameObject);
				yield return null;
			}
		}
		#endregion
    }
}