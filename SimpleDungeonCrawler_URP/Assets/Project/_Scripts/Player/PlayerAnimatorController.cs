// ######################################################################
// PlayerAnimatorController - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
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
		private static int s_takeHealthDamageTriggerAnimParam = Animator.StringToHash("TakeHealthDamage");
		private static int s_takeStaminaDamageTriggerAnimParam = Animator.StringToHash("TakeStaminaDamage");
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable()
		{
			m_healthStat.OnValueChangedEvent += Stat_OnValuedChangedCallback;
			m_staminaStat.OnValueChangedEvent += Stat_OnValuedChangedCallback;
		}
		private void OnDisable()
		{
			m_healthStat.OnValueChangedEvent -= Stat_OnValuedChangedCallback;
			m_staminaStat.OnValueChangedEvent -= Stat_OnValuedChangedCallback;
		}
        #endregion

        #region Public API:
        public void SetMoveSpeed(float _moveSpeed) => m_animator.SetFloat(s_moveSpeedFloatAnimParam, _moveSpeed);
		#endregion

		#region Internally Used Method(s):
		private int GetAnimHashFromStatComponent(StatComponent _statComponent) => 
			(_statComponent == m_healthStat) ? s_takeHealthDamageTriggerAnimParam : s_takeStaminaDamageTriggerAnimParam;
		#endregion

		#region Callback Method(s):
        private void Stat_OnValuedChangedCallback(float _value, StatComponent _statComponent)
        {
            if (_value < 0)
			{
				m_animator.SetTrigger(GetAnimHashFromStatComponent(_statComponent));
			}
        }
		#endregion
	}
}
