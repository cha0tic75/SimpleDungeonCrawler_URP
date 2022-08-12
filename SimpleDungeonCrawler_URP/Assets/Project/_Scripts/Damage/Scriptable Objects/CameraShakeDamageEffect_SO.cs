// ######################################################################
// CameraShakeDamageEffect_SO - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
    [CreateAssetMenu(menuName = "SO/Damage Effects/Camera Shake Damage Effect")]
	public class CameraShakeDamageEffect_SO : BaseDamageEffect_SO
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_shakeDuration;
		[SerializeField] private float m_shakeMagnitude;
		#endregion

		#region Public API:
		public override void PerformEffect() => 
                PersistentObjects.Instance.CameraTools.CameraShaker.Shake(m_shakeDuration, m_shakeMagnitude);
		#endregion
	}
}