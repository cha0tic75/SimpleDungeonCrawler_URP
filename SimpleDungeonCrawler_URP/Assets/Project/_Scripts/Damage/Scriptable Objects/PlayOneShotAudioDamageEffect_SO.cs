// ######################################################################
// PlayOneShotAudioDamageEffect_SO - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
    [CreateAssetMenu(menuName = "SO/Damage Effects/Play OneShot Audio Damage Effect")]
	public class PlayOneShotAudioDamageEffect_SO : BaseDamageEffect_SO
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private AudioClip m_audioClip;
		#endregion

		#region Public API:
		public override void PerformEffect() => 
                PersistentObjects.Instance.AudioSource.PlayOneShot(m_audioClip);
		#endregion
	}
}