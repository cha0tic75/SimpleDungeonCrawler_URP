// ######################################################################
// SimpleFollow - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
	public class SimpleFollow : BaseEntity
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private Transform m_targetTransform;
		[SerializeField] private float m_smoothness = 10f;
		#endregion

		#region Internal State Field(s):
		
		#endregion
		
		#region Properties:
		
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void FixedUpdate()
		{
			Vector3 desiredPosition = new Vector3(m_targetTransform.position.x, m_targetTransform.position.y, Transform.position.z);
			Transform.position = Vector3.Lerp(Transform.position, desiredPosition, m_smoothness * Time.deltaTime);
		}
		#endregion
		
		#region Public API:
		
		#endregion

		#region Internally Used Method(s):
		
		#endregion
	}
}