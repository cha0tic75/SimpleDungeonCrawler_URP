// ######################################################################
// PlayerController - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using Project.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Actors.Player
{
    public class PlayerInputManager : SingletonMonoBehaviour<PlayerInputManager>, IMovementInputProvider
	{
		#region Delegate(s):
		public event Action<Vector2> OnMovementInputEvent;
		public event Action OnItemInteractionEvent;
		public event Action<bool> OnSprintInputEvent;
		#endregion
		
		#region Internal State Field(s):
		private PlayerControls m_playerControls;
		#endregion

		#region MonoBehaviour Callback Method(s):
		protected override void Awake()
		{
			base.Awake();
			m_playerControls = new PlayerControls();
		}
		private void OnEnable()
		{
			m_playerControls.Player.Move.performed += PlayerControls_MovementInputCallback;
			m_playerControls.Player.Interact.performed += PlayerControls_InteractInputCallback;
			m_playerControls.Player.Sprint.performed += PlayerControls_SprintInputCallback;
			m_playerControls.Enable();
		}

        private void OnDisable()
		{
			m_playerControls.Disable();
			m_playerControls.Player.Move.performed -= PlayerControls_MovementInputCallback;
			m_playerControls.Player.Interact.performed -= PlayerControls_InteractInputCallback;
			m_playerControls.Player.Sprint.performed -= PlayerControls_SprintInputCallback;
		}
		#endregion

		#region Callback(s):
        private void PlayerControls_MovementInputCallback(InputAction.CallbackContext _context) => 
            OnMovementInputEvent?.Invoke(_context.ReadValue<Vector2>());
        private void PlayerControls_InteractInputCallback(InputAction.CallbackContext _context) => 
            OnItemInteractionEvent?.Invoke();
        private void PlayerControls_SprintInputCallback(InputAction.CallbackContext _context) => 
            OnSprintInputEvent?.Invoke(_context.ReadValueAsButton());
		#endregion
	}
}