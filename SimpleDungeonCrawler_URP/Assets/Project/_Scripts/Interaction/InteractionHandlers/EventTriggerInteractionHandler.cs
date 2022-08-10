// ######################################################################
// EventTriggerInteractionHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;
using UnityEngine.Events;

namespace Project.Interaction
{
    public class EventTriggerInteractionHandler : BaseInteractionHandler
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private UnityEvent m_interactEvent;
		#endregion

		#region Public API:
		public override void HandleInteraction(GameObject _interactor)
		{
			m_interactEvent?.Invoke();
		}
		#endregion
	}
}