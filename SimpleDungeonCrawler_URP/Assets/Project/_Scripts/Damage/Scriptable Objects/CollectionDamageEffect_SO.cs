// ######################################################################
// CollectionDamageEffect_SO - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    [CreateAssetMenu(menuName = "SO/Damage Effects/Collection")]
	public class CollectionDamageEffect_SO : BaseDamageEffect_SO
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private List<BaseDamageEffect_SO> m_damageEffects;
		#endregion

		#region Public API:
		public override void PerformEffect() => m_damageEffects.ForEach(de => de.PerformEffect());
		#endregion
	}	
}