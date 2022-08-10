// ######################################################################
// HealthComponent - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using UnityEngine;

namespace Project.Damage
{
    public class HealthComponent : MonoBehaviour, IDamagable
	{
		#region Delegate(s):
		public event Action<int, HealthComponent> OnTakeDamageEvent;
		public event Action<Vector3, HealthComponent> OnDeathEvent;
		#endregion

		#region Inspector Assigned Field(s):
		[field: SerializeField] public int StartHealth { get; private set; } = 10;
#if UNITY_EDITOR
		[field: SerializeField, ReadOnly] 
#endif
		public int CurrentHealth { get; protected set; }
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start() => CurrentHealth = StartHealth;
		#endregion
		
		#region Public API:
		public void TakeDamage(int _damageAmount)
		{
			CurrentHealth = Mathf.Clamp(CurrentHealth - _damageAmount, 0, StartHealth);
			OnTakeDamageEvent?.Invoke(_damageAmount, this);

			if (CurrentHealth == 0) { OnDeathEvent?.Invoke(transform.position, this); }
		}
		#endregion
	}
}
