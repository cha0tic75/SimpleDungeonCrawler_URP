// ######################################################################
// PlayerAnimatorController - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Stats;
using UnityEngine;

namespace Project.Player
{
	public class PlayerAnimatorController : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private Animator m_animator;
		[SerializeField] private StatComponent m_healthStat;
		[SerializeField] private StatComponent m_staminaStat;
		#endregion

		#region Internal State Field(s):
		private static int s_moveSpeedFloatAnimParam = Animator.StringToHash("MoveSpeed");
		private static int s_takeDamageTriggerAnimParam = Animator.StringToHash("TakeDamage");
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable()
		{
			PlayerInputManager.Instance.OnMovementInputEvent += InputManager_OnMovementInputCallback;
			m_healthStat.OnTakeDamageEvent += Stat_OnTakeDamageCallback;
			m_staminaStat.OnTakeDamageEvent += Stat_OnTakeDamageCallback;
		}
		private void OnDisable()
		{
			m_healthStat.OnTakeDamageEvent -= Stat_OnTakeDamageCallback;
			m_staminaStat.OnTakeDamageEvent -= Stat_OnTakeDamageCallback;

			if (PlayerInputManager.Instance == null) { return; }
			PlayerInputManager.Instance.OnMovementInputEvent -= InputManager_OnMovementInputCallback;
		}
        #endregion

		#region Callback Method(s):
        private void Stat_OnTakeDamageCallback(float _value, StatComponent _statComponent)
        {
            if (_value >= 0) { return; }
			m_animator.SetTrigger(s_takeDamageTriggerAnimParam);
        }

        private void InputManager_OnMovementInputCallback(Vector2 _movementInput)
        {
            m_animator.SetFloat(s_moveSpeedFloatAnimParam, _movementInput.magnitude);
        }
		#endregion
	}
}
