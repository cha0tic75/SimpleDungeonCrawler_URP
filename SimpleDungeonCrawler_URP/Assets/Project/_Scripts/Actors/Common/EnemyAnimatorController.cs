// ######################################################################
// EnemyAnimatorController - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Actors.Enemies
{
    [RequireComponent(typeof(EnemyMotor))]
    public class EnemyAnimatorController : BaseAnimatorController
	{
		#region Internal State Field(s):
		private IMovementInputProvider m_movementProvider = null;
		#endregion

		#region Properties:
		protected override IMovementInputProvider MovementProvider => m_movementProvider;
		#endregion

		#region MonoBehaviour Callback Method(s):
        private void Awake() => m_movementProvider = GetComponent<EnemyMotor>();
		#endregion
	}
}
