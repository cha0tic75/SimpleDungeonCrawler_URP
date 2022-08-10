// ######################################################################
// PlayerHealthComponent - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using UnityEngine;

namespace Project.Damage
{
    public class PlayerHealthComponent : HealthComponent, IHealable
	{
		#region Delegate(s):
		public event Action<int, HealthComponent> OnHealEvent;
		#endregion

		#region Public API:
		public void Heal(int _healAmount)
		{
			CurrentHealth = Mathf.Clamp(CurrentHealth + _healAmount, 0, StartHealth);
			OnHealEvent?.Invoke(_healAmount, this);
		}
		#endregion

		private void OnCollisionEnter2D(Collision2D _collision) 
		{
			if (_collision.gameObject.CompareTag("DamageDealer"))
			{
				if (_collision.gameObject.TryGetComponent<DamageDealer>(out var damageDealer))
				{
					damageDealer.DealDamage(this);
				}
			}	
		}
	}
}
