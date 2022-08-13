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
		[field: SerializeField] public StatType_SO StatType { get; private set; } 
		[SerializeField] private Image m_fillImage;
		#endregion

		#region Public API(s):
        public void UpdateMeter(StatComponent _statComponent) => 
            m_fillImage.fillAmount = _statComponent.Percent;
		#endregion
	}
}
