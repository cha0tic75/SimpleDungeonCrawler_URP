// ######################################################################
// PlayerInteractor - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

using Project.Interaction;

namespace Project.Actors.Player
{
    [RequireComponent(typeof(PlayerMotor))]
	public class PlayerInteractor : TransformMonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_interactRadius;
        [SerializeField] private LayerMask m_interactLayerMask;
#if UNITY_EDITOR
		[SerializeField] private bool m_showGizmos;
#endif
		#endregion

		#region Internal State Field(s):
		private PlayerInventory m_playerInventory = null;
        #endregion

        #region MonoBehaviour Callback Method(s):
        private void OnEnable() =>
			PlayerInputManager.Instance.OnItemInteractionEvent += Controller_OnItemInteractionCallback;
		private void OnDisable()
		{
			if (PlayerInputManager.Instance == null) { return; }
			PlayerInputManager.Instance.OnItemInteractionEvent -= Controller_OnItemInteractionCallback;
		}
        
#if UNITY_EDITOR
		private void OnDrawGizmos() 
		{
			if (!m_showGizmos) { return; }
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, m_interactRadius);	
		}
#endif
		#endregion

        #region Internally Used Method(s):
        private void Controller_OnItemInteractionCallback()
        {
 			Collider2D interactCollider = Physics2D.OverlapCircle(Transform.position, m_interactRadius, m_interactLayerMask);

			if (interactCollider != null)
			{
				if (interactCollider.TryGetComponent<Interactable>(out var interactable))
				{
					if (interactable.enabled == true)
					{
						interactable.Interact(gameObject);
						return;
					}
				}	
			}

			// No interactable found. lets assume player wants to drop current Item:
			if (m_playerInventory == null) { m_playerInventory = GetComponent<PlayerInventory>(); }

			m_playerInventory.AttemptToDropCurrent();
        }
		#endregion
	}
}