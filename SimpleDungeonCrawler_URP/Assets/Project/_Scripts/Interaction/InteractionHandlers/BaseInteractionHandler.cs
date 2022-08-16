// ######################################################################
// BaseInteractionHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Interaction
{
    public abstract class BaseInteractionHandler : MonoBehaviour
	{
		#region Public API:
		public abstract void HandleInteraction(GameObject _interactor);
		#endregion
	}
}