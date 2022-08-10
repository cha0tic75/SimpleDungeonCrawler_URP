// ######################################################################
// DamageWallStateManager - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
	public class DamageWallStateManager : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private GameObject m_damageWall;
		[SerializeField] private GameObject m_generalWall;		
		#endregion

		#region Internal State Field(s):
		private bool m_currentDamageState = false;
		#endregion
		
		#region Public API:
		public void ToggleState()
		{
			m_currentDamageState = !m_currentDamageState;
			SetState();
		}
		public void ChangeStateTo(bool _state)
		{
			m_currentDamageState = _state;
			SetState();
		}
		#endregion

		#region Internally Used Method(s):
		private void SetState()
		{
			m_damageWall.SetActive(m_currentDamageState);
			m_generalWall.SetActive(!m_currentDamageState);
		}
		#endregion
	}
}
