// ######################################################################
// PlayerController - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using Project.CameraSystem;
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
		[SerializeField] private PlayerAnimatorController m_animatorController;
		[SerializeField] private PlayerSprintComponent m_sprintcomponent;
		[SerializeField] private float m_sprintSpeedModifier = 1.4f;
		#endregion

		#region Internal State Field(s):
		private Vector2 m_movementInputVector = Vector2.zero;
        #endregion

        #region Properties:
        private float CurrentMoveSpeed => m_moveSpeed * ((m_sprintcomponent.IsSprinting) ? m_sprintSpeedModifier : 1f);
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Update()
		{
			m_movementInputVector.x = Input.GetAxisRaw("Horizontal");
			m_movementInputVector.y = Input.GetAxisRaw("Vertical");

			m_sprintcomponent.SetSprintInput(Input.GetKey(KeyCode.LeftShift));

			if (Input.GetKeyDown(KeyCode.Space)) { OnItemInteractionEvent?.Invoke(); }

			// Test Code: 
			if (Input.GetKeyDown(KeyCode.Escape)) { CameraTools.Instance.CameraShaker.Shake(); }
		}

		private void FixedUpdate()
		{
			// TODO: Use the Rigidbody to move instead of the transform
			Vector3 movementVector = new Vector3(m_movementInputVector.x, m_movementInputVector.y, 0f).normalized;
			Transform.position += movementVector * CurrentMoveSpeed * Time.deltaTime;
			
			m_animatorController?.SetMoveSpeed(movementVector.magnitude);
		}
		#endregion
	}
}