// ######################################################################
// Interactable - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.Interaction
{
    public class Interactable : MonoBehaviour, IInteractable
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private List<BaseInteractionHandler> m_interactionHandlers;
		#endregion

		#region Inspector Assigned Field(s):
		private void Start() { } // This is just here to expose enable/disable toggle in the inspector
		#endregion
		
		#region Public API:
		public void Interact(GameObject _interactor)
		{
			for (int i = 0; i < m_interactionHandlers.Count; i++)
			{
				BaseInteractionHandler interactionHandler = m_interactionHandlers[i];
				if (interactionHandler != null && interactionHandler.enabled == true)
				{
					interactionHandler.HandleInteraction(_interactor);
				}
			}
		}
		#endregion
	}
}
