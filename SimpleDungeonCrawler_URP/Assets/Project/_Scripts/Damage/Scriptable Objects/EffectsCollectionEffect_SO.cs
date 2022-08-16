// ######################################################################
// EffectsCollectionEffect_SO - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    [CreateAssetMenu(menuName = "SO/Effects/Effects Collection", fileName = "New Effects Collection")]
	public class EffectsCollectionEffect_SO : BaseEffect_SO
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private List<BaseEffect_SO> m_damageEffects;
		#endregion

		#region Public API:
		public override void PerformEffect(GameObject _gameObject) => m_damageEffects.ForEach(de => de.PerformEffect(_gameObject));
		#endregion
	}	
}