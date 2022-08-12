// ######################################################################
// DamageSingleDamageDealerHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Damage
{
    public class DamageSingleDamageDealerHandler : BaseDamageDealerHandler
	{
		#region Public API:
		public override void HandleOnEnterDamage(IDamagable _damagable) => 
			_damagable.TakeDamage(m_damageRange.GetRandomValueInRange());
        #endregion
    }
}