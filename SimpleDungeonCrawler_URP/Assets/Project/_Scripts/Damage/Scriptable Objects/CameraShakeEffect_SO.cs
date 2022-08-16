// ######################################################################
// CameraShakeEffect_SO - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
    [CreateAssetMenu(menuName = "SO/Effects/Camera Shake Effect")]
	public class CameraShakeEffect_SO : BaseEffect_SO
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_shakeDuration;
		[SerializeField] private float m_shakeMagnitude;
		#endregion

		#region Public API:
		public override void PerformEffect() => 
                GameManager.Instance.CameraTools.CameraShaker.Shake(m_shakeDuration, m_shakeMagnitude);
		#endregion
	}
}