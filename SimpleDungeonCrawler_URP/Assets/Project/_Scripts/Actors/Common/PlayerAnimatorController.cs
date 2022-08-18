// ######################################################################
// PlayerAnimatorController - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Stats;
using UnityEngine;

namespace Project.Actors.Player
{
    public class PlayerAnimatorController : BaseAnimatorController
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private StatComponent m_healthStat;
		[SerializeField] private StatComponent m_staminaStat;
		#endregion

		#region Internal State Field(s):
		private static int s_takeDamageTriggerAnimParam = Animator.StringToHash("TakeDamage");
		#endregion

		#region Properties:
		protected override IMovementInputProvider MovementProvider => PlayerInputManager.Instance;
		#endregion

		#region MonoBehaviour Callback Method(s):
		protected override void OnEnable()
		{
			base.OnEnable();
			m_healthStat.OnTakeDamageEvent += Stat_OnTakeDamageCallback;
			m_staminaStat.OnTakeDamageEvent += Stat_OnTakeDamageCallback;
		}
		protected override void OnDisable()
		{
			base.OnDisable();
			m_healthStat.OnTakeDamageEvent -= Stat_OnTakeDamageCallback;
			m_staminaStat.OnTakeDamageEvent -= Stat_OnTakeDamageCallback;
		}
        #endregion

		#region Callback Method(s):
        private void Stat_OnTakeDamageCallback(float _value, StatComponent _statComponent)
        {
            if (_value >= 0) { return; }
			m_animator.SetTrigger(s_takeDamageTriggerAnimParam);
        }

        private void IMovementProvider_OnMovementInputCallback(Vector2 _movementInput)
        {
            m_animator.SetFloat(s_moveSpeedFloatAnimParam, _movementInput.magnitude);
        }
		#endregion
	}
}
