// ######################################################################
// SimpleCameraFollow - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.CameraSystem
{
    public class SimpleCameraFollow : BaseEntity
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private Transform m_targetTransform;
		[SerializeField] private float m_smoothness = 10f;
		#endregion

		#region Properties:
		private Vector3 DesiredPosition => (m_targetTransform != null) ?
				new Vector3(m_targetTransform.position.x, m_targetTransform.position.y, Transform.position.z) :
				Transform.position;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void FixedUpdate()
		{
			if (m_targetTransform == null) { return; }

			Transform.position = Vector3.Lerp(Transform.position, DesiredPosition, m_smoothness * Time.deltaTime);
		}
		#endregion

		#region Public API:
		public void SetTargetTransform(Transform _targetTransform, bool _snapToTarget = false)
		{
			m_targetTransform = _targetTransform;

			if (_snapToTarget){ Transform.position = DesiredPosition; }
		}
		#endregion
	}
}