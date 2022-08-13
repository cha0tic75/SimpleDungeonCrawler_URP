// ######################################################################
// RegenStatComponent - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

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
        #endregion

        #region MonoBehaviour Callback Method(s):
        private void Update() => AttemptRegeneration();
        #endregion

        #region Public API:
        public override void Consume(float _consumeAmount)
        {
            m_lastConsumeCurrentValueTime = Time.time;
            base.Consume(_consumeAmount);
        }
        #endregion

        #region Internally Used Method(s):
        private void AttemptRegeneration()
        {
            if (Time.time >  m_regenAfterWaitTime + m_lastConsumeCurrentValueTime)
            {
                if (CurrentValue < ValueRange.Max)
                {
                    AlterCurrentValue(m_regenAmount * Time.deltaTime);
                }
            }
        }
        #endregion
    }
}