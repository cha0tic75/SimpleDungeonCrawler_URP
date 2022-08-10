// ######################################################################
// PlayerController - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using UnityEngine;

namespace Project.Player
{
    public class PlayerController : BaseEntity
	{
		#region Delegate(s):
		public event Action OnItemInteractionEvent;
		#endregion

		#region Inspector Assigned Field(s):
		[SerializeField] private float m_moveSpeed = 4f;
		[SerializeField] private float m_sprintSpeedModifier = 1.4f;
		[SerializeField] private PlayerInventory m_playerHoldPoint;
		[SerializeField] private float m_offset = 1f;
		#endregion

		#region Internal State Field(s):
		private Vector2 m_movementInputVector = Vector2.zero;
		[SerializeField] private bool m_isSprinting = false;
        #endregion

        #region Properties:
        private float CurrentMoveSpeed => m_moveSpeed * ((m_isSprinting) ? m_sprintSpeedModifier : 1f);
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Update()
		{
			m_movementInputVector.x = Input.GetAxisRaw("Horizontal");
			m_movementInputVector.y = Input.GetAxisRaw("Vertical");

			m_isSprinting = Input.GetKey(KeyCode.LeftShift);

			if (Input.GetKeyDown(KeyCode.Space))
			{
				OnItemInteractionEvent?.Invoke();
				// m_playerHoldPoint.Interaction();
			}

		}

		private void FixedUpdate()
		{
			Vector3 movementVector = new Vector3(m_movementInputVector.x, m_movementInputVector.y, 0f).normalized;
			Transform.position += movementVector * CurrentMoveSpeed * Time.deltaTime;

			// m_playerHoldPoint.Transform.position = Transform.position + movementVector * m_offset;
		}
		#endregion
	}
}