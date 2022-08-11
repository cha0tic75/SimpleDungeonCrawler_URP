// ######################################################################
// HealthStatComponent - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using UnityEngine;

namespace Project.Stats
{

    public class HealthStatComponent : BaseStatComponent, Damage.IDamagable
	{
		#region Delegate(s):
		public event Action<Vector3, BaseStatComponent> OnDeathEvent;
		#endregion
		
		#region Public API:
		public void TakeDamage(float _damageAmount)
		{
			AlterCurrentValue(-_damageAmount);

			if (CurrentValue == 0) { OnDeathEvent?.Invoke(transform.position, this); }
		}
		#endregion
	}
}
