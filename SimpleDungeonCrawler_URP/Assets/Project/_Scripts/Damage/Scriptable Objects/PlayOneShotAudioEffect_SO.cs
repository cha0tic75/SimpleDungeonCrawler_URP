// ######################################################################
// PlayOneShotAudioEffect_SO - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
    [CreateAssetMenu(menuName = "SO/Effects/Play OneShot Audio Effect")]
	public class PlayOneShotAudioEffect_SO : BaseEffect_SO
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private AudioClip m_audioClip;
		[SerializeField, Range(0f, 1f)] private float m_volume = 1f;
		#endregion

		#region Public API:
		public override void PerformEffect() => 
                GameManager.Instance.AudioSource.PlayOneShot(m_audioClip, m_volume);
		#endregion
	}
}