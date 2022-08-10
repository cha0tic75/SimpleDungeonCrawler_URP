// ######################################################################
// PlayerController - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Core;
using UnityEngine;

namespace Project.Player
{
	[System.Serializable]
	public class PlayerHoldPointData
	{
		[field: SerializeField] public PlayerHoldPoint PlayerHoldPoint { get; private set; }
		[field: SerializeField] public float Offset { get; private set; } = 0.25f;
	}
    public class PlayerController : BaseEntity
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_moveSpeed = 3f;
		[SerializeField] private float m_sprintSpeedModifier = 1.65f;
		[SerializeField, ReadOnly] private bool m_isSprinting = false;
		[SerializeField] private PlayerHoldPointData m_playerHoldPointData;
		#endregion

		#region Internal State Field(s):
		private Vector2 m_movementInputVector = Vector2.zero;
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
		}

		private void FixedUpdate()
		{
			Vector3 movementVector = new Vector3(m_movementInputVector.x, m_movementInputVector.y, 0f).normalized;
			Transform.position += movementVector * CurrentMoveSpeed * Time.deltaTime;

			m_playerHoldPointData.PlayerHoldPoint.Transform.position = Transform.position + movementVector * m_playerHoldPointData.Offset;
		}
		#endregion
	}
}