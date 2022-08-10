// ######################################################################
// Base_SO - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
    public abstract class Base_SO : ScriptableObject
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField] public string Name { get; private set; }
		#endregion
	}
}