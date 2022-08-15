// ######################################################################
// CameraZoomEffect_SO - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
    [CreateAssetMenu(menuName = "SO/Effects/Camera Zoom Effect")]
	public class CameraZoomEffect_SO : BaseEffect_SO
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_duration = 0.1f;
        [SerializeField] private float m_zoomValue = 1.92f;
		[SerializeField] private float m_delayBetween = 0.15f;
		#endregion

		#region Public API:
		public override void PerformEffect() => 
                PersistentObjects.Instance.CameraTools.CameraZoom.ZoomInOut(m_zoomValue, m_duration, m_delayBetween);
		#endregion
	}
}