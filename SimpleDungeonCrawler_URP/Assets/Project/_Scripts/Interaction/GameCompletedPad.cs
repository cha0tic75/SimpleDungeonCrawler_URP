// ######################################################################
// GameCompletedPad - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Interaction
{
	// TODO: This is horrible design.  I am sure I have some existing framework to handle this
	[RequireComponent(typeof(Collider2D))]
	public class GameCompletedPad : MonoBehaviour
	{
		#region MonoBehaviour Callback Method(s):
		private void Start() => GetComponent<Collider2D>().isTrigger = true;
		private void OnTriggerEnter2D(Collider2D other) => GameManager.Instance.ChangeGameState(GameState.Win);
		#endregion
	}
}
