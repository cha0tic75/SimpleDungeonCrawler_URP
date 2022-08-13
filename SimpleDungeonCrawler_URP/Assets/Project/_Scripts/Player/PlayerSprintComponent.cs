// ######################################################################
// PlayerSprintComponent - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Stats;
using UnityEngine;

namespace Project.Player
{
	public class PlayerSprintComponent : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_sprintCost = 1f;
		[SerializeField] private StatComponent m_statComponent;
		#endregion

		#region Internal State Field(s):
		private bool m_sprintInput;
		#endregion
		
		#region Properties:
		public bool IsSprinting { get; private set; }
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Update()
		{
			if (!m_sprintInput) { return; }
			float sprintCostDelta = m_sprintCost * Time.deltaTime;

			IsSprinting = m_statComponent.CurrentValue > sprintCostDelta;
			m_statComponent.Consume(sprintCostDelta);
		}
		#endregion
		
		#region Public API:
		public void SetSprintInput(bool _sprintInput) => m_sprintInput = _sprintInput;
		#endregion
	}
}