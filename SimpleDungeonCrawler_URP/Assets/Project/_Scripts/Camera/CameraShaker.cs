// ######################################################################
// CameraShaker - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using UnityEngine;

namespace Project.CameraSystem
{
    public class CameraShaker : TransformMonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_defaultDuration = 0.1f;
		[SerializeField] private float m_defaultMagnitude = 0.15f;
        [SerializeField] private float m_axisRange = -0.5f;
		#endregion

		#region Public API:
		public void Shake(float _duration = 0f, float _magnitude = 0f)
		{
			float duration = (_duration > 0f) ? _duration : m_defaultDuration;
			float magnitude = (_magnitude > 0f) ? _magnitude : m_defaultMagnitude;

			StartCoroutine(ShakeCoroutine(duration, magnitude));
		}
		#endregion

		#region Coroutine(s):
		private IEnumerator ShakeCoroutine(float _duration, float _magnitude)
		{
			float elapsedTime = 0f;

			while (elapsedTime < _duration)
			{
				float xOffset = Random.Range(-m_axisRange, m_axisRange); // * _magnitude;
				float yOffset = Random.Range(-m_axisRange, m_axisRange); // * _magnitude;
				Transform.localPosition = new Vector3(xOffset, yOffset, Transform.position.z) * _magnitude;

				elapsedTime += Time.deltaTime;
				yield return null;			
			}

			Transform.localPosition = Vector3.zero;
		}
		#endregion
	}
}