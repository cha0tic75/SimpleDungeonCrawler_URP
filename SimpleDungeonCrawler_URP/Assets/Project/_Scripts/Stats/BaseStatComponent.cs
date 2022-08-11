// ######################################################################
// BaseStatComponent - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using UnityEngine;

namespace Project.Stats
{
    public abstract class BaseStatComponent : MonoBehaviour
	{
		#region Delegate(s):
		public event Action<float, BaseStatComponent> OnValueChangedEvent;
		#endregion

		#region Inspector Assigned Field(s):
		[field: SerializeField] public float StartValue { get; protected set; } = 10;
		[field: SerializeField] public MinMaxFloat ValueRange { get; private set; }
#if UNITY_EDITOR
		[field: SerializeField, ReadOnly] 
#endif
		public float CurrentValue { get; protected set; }
		#endregion

		#region Properties:
		public float Percent => CurrentValue / (float)ValueRange.Max;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start() => CurrentValue = StartValue;
		#endregion

		#region Internally Used Method(s):
		protected void AlterCurrentValue(float _value)
		{
			CurrentValue = Mathf.Clamp(CurrentValue + _value, 0, ValueRange.Max);
			OnValueChangedEvent?.Invoke(_value, this);
		}
		#endregion
	}
}
