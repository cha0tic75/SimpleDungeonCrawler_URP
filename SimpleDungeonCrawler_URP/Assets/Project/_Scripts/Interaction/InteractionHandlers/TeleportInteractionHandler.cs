// ######################################################################
// TeleportInteractionHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Player;
using UnityEngine;

namespace Project.Interaction
{
    public class TeleportInteractionHandler : BaseInteractionHandler
	{
        #region Inspector Assigned Field(s):
        [SerializeField] private Vector3 m_teleportOffset;
        #endregion

        #region Properties:
        private Vector3 TeleportLocation => Transform.position + m_teleportOffset;
        #endregion

#if UNITY_EDITOR
        private void OnDrawGizmosSelected() 
        {
            if (Transform == null) { Transform = transform; }
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(TeleportLocation, 0.2f);
        }
#endif

		#region Public API:
		public override void HandleInteraction(GameObject _interactor)
		{
			if (_interactor.TryGetComponent<PlayerController>(out var controller))
            {
                _interactor.transform.position = TeleportLocation;
            }
		}
		#endregion
	}
}