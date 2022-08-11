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
        [SerializeField] private SpriteRenderer m_spriteRenderer;
        [SerializeField] private Color m_color = new Color(1f, 1f, 1f, 1f);
#if UNITY_EDITOR
        [SerializeField] private bool m_showGizmos;
#endif
        #endregion

        #region Properties:
        private Vector3 TeleportLocation => Transform.position + m_teleportOffset;
        #endregion

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (m_spriteRenderer == null) { return; }
            m_spriteRenderer.color = m_color;
        }
        private void OnDrawGizmosSelected() 
        {
            if (!m_showGizmos) { return; }
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