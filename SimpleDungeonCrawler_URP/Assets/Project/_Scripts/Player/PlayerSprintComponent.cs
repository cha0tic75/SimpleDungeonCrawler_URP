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
		
		#region Properties:
		public bool IsSprinting { get; private set; }
		private float SprintCostDelta => m_sprintCost * Time.deltaTime;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Update()
		{
			if (!IsSprinting) { return; }

			m_statComponent.Consume(SprintCostDelta, ConsumeType.Use);
		}
		#endregion
		
		#region Public API:
		public void SetSprintInput(bool _sprintInput) =>
			IsSprinting = _sprintInput && CanSprint();
		#endregion

		#region Internally Used Method(s):
		private bool CanSprint() => m_statComponent.CurrentValue > SprintCostDelta;
		#endregion
	}
}