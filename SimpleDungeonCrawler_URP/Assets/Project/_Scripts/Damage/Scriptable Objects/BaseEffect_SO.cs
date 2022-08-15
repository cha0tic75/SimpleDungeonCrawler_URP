// ######################################################################
// BaseEffect_SO - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
    public abstract class BaseEffect_SO : ScriptableObject
	{	
		#region Public API:
		public abstract void PerformEffect();
		#endregion
	}
}