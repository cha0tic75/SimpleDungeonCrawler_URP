// ######################################################################
// TrapTriggerDamageDealer - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Damage
{
    public class TrapTriggerDamageDealer : TriggerDamageDealer
	{
		#region Inspector Assigned Field(s):
		[SerializeField, Range(0, 100)] private int m_probability;
		[SerializeField] private bool m_destroyOnFirstUse = false;
        #endregion

        #region Internal State Field(s):
        protected override void HandleEnter2D(IDamagable _damagable)
        {
			int rndRoll = UnityEngine.Random.Range(0, 100) + 1;

			if (rndRoll <= m_probability)
			{
				_damagable.TakeDamage(GetRndDamage());

				if (m_destroyOnFirstUse) { Destroy(gameObject); }
			}
        }

        protected override void HandleExit2D(IDamagable _damagable) { }
        #endregion
    }
}