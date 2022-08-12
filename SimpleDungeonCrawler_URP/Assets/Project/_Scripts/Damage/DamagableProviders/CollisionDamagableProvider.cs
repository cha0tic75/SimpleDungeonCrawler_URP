// ######################################################################
// CollisionDamagableProvider - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Damage
{
    [RequireComponent(typeof(Collider2D))]
	public class CollisionDamagableProvider : BaseDamagableProvider
	{
		#region MonoBEhaviour Callback Method(s):
		private void OnCollisionEnter2D(Collision2D _collision) 
		{
			if (_collision.gameObject.TryGetComponent<IDamagable>(out var damagable))
			{
				InvokeOnDamagableEnterEvent(damagable);
			}
		}
		private void OnCollisionExit2D(Collision2D _collision) 
		{
			if (_collision.gameObject.TryGetComponent<IDamagable>(out var damagable))
			{
				InvokeOnDamagableExitEvent(damagable);
			}
		}
		#endregion
	}
}
