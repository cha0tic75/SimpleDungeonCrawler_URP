// ######################################################################
// BaseAnimatorController - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Actors
{
    public abstract class BaseAnimatorController : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] protected Animator m_animator;
		#endregion

		#region Internal State Field(s):
		protected abstract IMovementInputProvider MovementProvider { get; }
		protected static int s_moveSpeedFloatAnimParam = Animator.StringToHash("MoveSpeed");
		#endregion

		#region MonoBehaviour Callback Method(s):
		protected virtual void OnEnable() =>
			MovementProvider.OnMovementInputEvent += IMovementProvider_OnMovementInputCallback;
		protected virtual void OnDisable()
		{
			if (MovementProvider == null) { return; }
			MovementProvider.OnMovementInputEvent -= IMovementProvider_OnMovementInputCallback;
		}
		#endregion
	
		#region Internally Used Method(s):
        private void IMovementProvider_OnMovementInputCallback(Vector2 _movementInput)
        {
            m_animator.SetFloat(s_moveSpeedFloatAnimParam, _movementInput.magnitude);
        }
		#endregion
	}
}
