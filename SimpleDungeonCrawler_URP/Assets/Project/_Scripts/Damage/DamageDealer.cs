// ######################################################################
// DamageDealer - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Damage
{
    public class DamageDealer : MonoBehaviour, IDamageDealer
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private int m_damageAmount = 1;
		#endregion

		#region Public API:
		public void DealDamage(IDamagable _damagable) => _damagable.TakeDamage(m_damageAmount);
		#endregion
	}
}
