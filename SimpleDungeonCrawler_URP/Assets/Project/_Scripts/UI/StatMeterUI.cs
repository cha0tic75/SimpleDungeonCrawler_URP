// ######################################################################
// StatMeterUI - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI
{
    public class StatMeterUI : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private Image m_fillImage;
		[SerializeField] private BaseStatComponent m_statComponent;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable()
		{
			if (m_statComponent == null) { return; }
			m_statComponent.OnValueChangedEvent += StatComponent_OnValueChangedCallback;
		}
        private void OnDisable()
		{
			if (m_statComponent == null) { return; }
			m_statComponent.OnValueChangedEvent -= StatComponent_OnValueChangedCallback;
		}
		#endregion

		#region Callback Method(s):
        private void StatComponent_OnValueChangedCallback(float _value, BaseStatComponent _statComponent) => 
            m_fillImage.fillAmount = _statComponent.Percent;
		#endregion
	}
}
