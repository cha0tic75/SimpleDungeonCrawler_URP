// ######################################################################
// PlayerController - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using System.Collections;
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
		[SerializeField] private PlayOneShotAudioEffect_SO m_walkingEffect;
		#endregion

		#region Internal State Field(s):
		private Coroutine m_footStepsAudioCoroutine = null;
		private Vector2 m_movementInputVector = Vector2.zero;
		private Vector3 m_movementVector = Vector3.zero;
        #endregion

        #region Properties:
        private float CurrentMoveSpeed => m_moveSpeed * ((m_sprintcomponent.IsSprinting) ? m_sprintSpeedModifier : 1f);
		private float MoveSpeedMagnitude => m_movementVector.magnitude;
		#endregion

		#region MonoBehaviour Callback Method(s):
		protected override void Awake()
		{
			base.Awake();
			GameManager.Instance.CameraTools.CameraFollow.SetTargetTransform(Transform, true);
		}
		private void OnEnable() => m_footStepsAudioCoroutine = StartCoroutine(FootStepsAudioCoroutine());
		private void OnDisable() => HelperMethods.StopCoroutineIfRunning(ref m_footStepsAudioCoroutine, this);


		private void Update()
		{
			if (GameManager.Instance.CurrentState != GameState.GamePlay) { return; }

			m_movementInputVector.x = Input.GetAxisRaw("Horizontal");
			m_movementInputVector.y = Input.GetAxisRaw("Vertical");

			m_sprintcomponent.SetSprintInput(Input.GetKey(KeyCode.LeftShift));

			if (Input.GetKeyDown(KeyCode.Space)) { OnItemInteractionEvent?.Invoke(); }
		}

		private void FixedUpdate()
		{
			// TODO: Use the Rigidbody to move instead of the transform
			m_movementVector = new Vector3(m_movementInputVector.x, m_movementInputVector.y, 0f).normalized;
			Transform.position += m_movementVector * CurrentMoveSpeed * Time.deltaTime;

			m_animatorController?.SetMoveSpeed(MoveSpeedMagnitude);
		}
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