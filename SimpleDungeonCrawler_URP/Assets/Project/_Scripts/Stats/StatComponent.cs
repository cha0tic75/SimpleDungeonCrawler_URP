// ######################################################################
// StatComponent - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project.Stats
{
    public class StatComponent : MonoBehaviour, IDamagable, IHealable
	{
		#region Delegate(s):
		public event Action<float, StatComponent> OnValueChangedEvent;
		#endregion

		#region Inspector Assigned Field(s):
		[field: SerializeField] public StatType_SO StatType { get; private set; }
        [SerializeField] private UI.StatMeterUI m_statMeter;
		[field: SerializeField] public MinMaxFloat ValueRange { get; private set; } = new MinMaxFloat(0f, 10f);
#if UNITY_EDITOR
		[field: SerializeField, ReadOnly] 
#endif
		public float CurrentValue { get; protected set; }
        #endregion

		#region Properties:
		public float Percent => CurrentValue / (float)ValueRange.Max;
		#endregion

        #region MonoBehaviour Callback Method(s):
        private void Start()
        {
            CurrentValue = ValueRange.Max;

            if (m_statMeter == null)
            {
                List<UI.StatMeterUI> statMeters = FindObjectsOfType<UI.StatMeterUI>().ToList();
                m_statMeter = statMeters.Find(sm => sm.StatType == StatType);
            }
        }
        #endregion

        #region Public API:
        public virtual void Consume(float _consumeAmount) => AlterCurrentValue(-_consumeAmount);

        public virtual void Apply(float _applyAmount) => AlterCurrentValue(_applyAmount);
        #endregion

		#region Internally Used Method(s):
		protected void AlterCurrentValue(float _value)
		{
			CurrentValue = Mathf.Clamp(CurrentValue + _value, 0, ValueRange.Max);
            m_statMeter?.UpdateMeter(this);
			OnValueChangedEvent?.Invoke(_value, this);
		}
		#endregion
	}
}