// ######################################################################
// TriggerDamagableProvider - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Damage
{
    [RequireComponent(typeof(Collider2D))]
	public class TriggerDamagableProvider : BaseDamagableProvider
	{
		#region MonoBehaviour Callback Method(s):
		private void Start() => GetComponent<Collider2D>().isTrigger = true;
		private void OnTriggerEnter2D(Collider2D _collider) => HandleOnEnter(_collider);
		private void OnTriggerExit2D(Collider2D _collider) => HandleOnExit(_collider);
		#endregion
	}
}