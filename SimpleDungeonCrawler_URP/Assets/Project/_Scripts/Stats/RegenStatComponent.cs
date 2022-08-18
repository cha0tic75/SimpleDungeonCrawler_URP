// ######################################################################
// RegenStatComponent - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;
using Project.Actors.Player;
using System;

namespace Project.Stats
{
    public class RegenStatComponent : StatComponent
    {
        #region Inspector Assigned Field(s):
		[Header("Regen Settings:")]
        [SerializeField] private float m_regenAmount = 0.5f;
        [SerializeField] private float m_regenAfterWaitTime = 2f;
        #endregion

        #region Internal State Field(s):
        private float m_lastConsumeCurrentValueTime;
        private bool m_isMovementInput = false;
        #endregion

        #region MonoBehaviour Callback Method(s):
        private void OnEnable() => 
            PlayerInputManager.Instance.OnMovementInputEvent += InputManager_OnMoveInputCallback;
        private void OnDisable()
        {
            if (PlayerInputManager.Instance == null) { return; }
            PlayerInputManager.Instance.OnMovementInputEvent -= InputManager_OnMoveInputCallback;
        }

        private void Update() => AttemptRegeneration();
        #endregion

        #region Public API:
        public override void Consume(float _consumeAmount, ConsumeType _consumeType)
        {
            m_lastConsumeCurrentValueTime = Time.time;
            base.Consume(_consumeAmount, _consumeType);
        }
        #endregion

        #region Internally Used Method(s):
        private void AttemptRegeneration()
        {
            if (m_isMovementInput)
            { 
                m_lastConsumeCurrentValueTime = Time.time;
            }
            if (Time.time >  m_regenAfterWaitTime + m_lastConsumeCurrentValueTime)
            {
                if (CurrentValue < ValueRange.Max)
                {
                    AlterCurrentValue(m_regenAmount * Time.deltaTime);
                }
            }
        }
        #endregion

        #region Callback(s):
        private void InputManager_OnMoveInputCallback(Vector2 _movementInput) => 
            m_isMovementInput = !(_movementInput == Vector2.zero);
        #endregion
    }
}