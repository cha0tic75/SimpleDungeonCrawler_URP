// ######################################################################
// PlayerStaminaStatComponent - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Stats
{
    public class PlayerStaminaStatComponent : BaseStatComponent
	{  
		#region Public API(s):
        public void Consume(float _amount)
        {
            AlterCurrentValue(-_amount);
            m_lastAlterCurrentValueTime = Time.time;
        }
        #endregion
	}
}
