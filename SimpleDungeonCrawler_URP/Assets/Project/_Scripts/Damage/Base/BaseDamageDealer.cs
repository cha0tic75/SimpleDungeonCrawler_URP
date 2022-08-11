// ######################################################################
// BaseDamageDealer - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Damage
{
    public abstract class BaseDamageDealer : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] protected MinMaxInt m_damageAmount;
		[SerializeField] protected float m_damageFrequency = 0.5f;
		[SerializeField] protected AudioSource m_audioSource;
		#endregion

		#region Internally Used Method(s):
		protected abstract void HandleEnter2D(IDamagable _damagable);
		protected abstract void HandleExit2D(IDamagable _damagable);
		protected int GetRndDamage() => m_damageAmount.GetRandomValueInRange();
		#endregion
	}
}
