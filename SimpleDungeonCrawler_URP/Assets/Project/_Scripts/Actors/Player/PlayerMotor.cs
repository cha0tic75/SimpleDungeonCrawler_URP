// ######################################################################
// PlayerMotor - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using UnityEngine;

namespace Project.Actors.Player
{
	// TODO: Consider using the rigidbody for movement
	// TODO: Consider moving the footsteps out to a seperate component
    public class PlayerMotor : BaseEntity
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_moveSpeed = 4f;
		[SerializeField] private float m_sprintSpeedModifier = 1.4f;
		[SerializeField] private PlayerSprintComponent m_sprintcomponent;
		[SerializeField] private PlayOneShotAudioEffect_SO m_walkingEffect;
		#endregion

		#region Internal State Field(s):
		private Coroutine m_footStepsAudioCoroutine = null;
		private Vector3 m_movementVector = Vector3.zero;
        #endregion

        #region Properties:
        private float CurrentMoveSpeed => m_moveSpeed * ((m_sprintcomponent.IsSprinting) ? m_sprintSpeedModifier : 1f);
		private float MoveSpeedMagnitude => m_movementVector.magnitude;
		private Vector2 MovementInputVector { get; set; }
		#endregion

		#region MonoBehaviour Callback Method(s):
		protected override void Awake()
		{
			base.Awake();
			GameManager.Instance.CameraTools.CameraFollow.SetTargetTransform(Transform, true);
		}
		private void OnEnable()
		{
			PlayerInputManager.Instance.OnMovementInputEvent += PlayerControls_MovementInputCallback;
			m_footStepsAudioCoroutine = StartCoroutine(FootStepsAudioCoroutine());
		}

        private void OnDisable()
		{
			if (PlayerInputManager.Instance == null) { return; }
			PlayerInputManager.Instance.OnMovementInputEvent -= PlayerControls_MovementInputCallback;
			HelperMethods.StopCoroutineIfRunning(ref m_footStepsAudioCoroutine, this);
		}

		private void FixedUpdate()
		{
			// TODO: Use the Rigidbody to move instead of the transform
			m_movementVector = new Vector3(MovementInputVector.x, MovementInputVector.y, 0f).normalized;
			Transform.position += m_movementVector * CurrentMoveSpeed * Time.deltaTime;
		}
		#endregion

		#region Callback(s):
		private void PlayerControls_MovementInputCallback(Vector2 _movementInput) =>
			MovementInputVector = 
				(GameManager.Instance.CurrentState == GameState.GamePlay) ? _movementInput : Vector2.zero;
		#endregion

		#region Coroutine(s):
		private IEnumerator FootStepsAudioCoroutine()
		{
			float clipLength = m_walkingEffect.AudioClip.length;
			while (true)
			{
				if(MoveSpeedMagnitude > 0)
				{
					m_walkingEffect.PerformEffect(gameObject);
					yield return HelperMethods.CustomWFS(clipLength);
				}
				else
				{
					yield return null;
				}
			}
		}
		#endregion
	}
}