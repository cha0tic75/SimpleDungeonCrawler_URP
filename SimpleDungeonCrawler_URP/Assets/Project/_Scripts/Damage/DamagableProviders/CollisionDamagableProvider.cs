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
		private void Start() => GetComponent<Collider2D>().isTrigger = false;
		private void OnCollisionEnter2D(Collision2D _collision) => HandleOnEnter(_collision.collider);
		private void OnCollisionExit2D(Collision2D _collision) => HandleOnExit(_collision.collider);
		#endregion
	}
}
