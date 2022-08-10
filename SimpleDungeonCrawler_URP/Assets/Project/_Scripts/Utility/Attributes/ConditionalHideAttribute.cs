// =========================================================================================
// ConditionalHideAttribute - Description goes here
//
// Original version of the ConditionalHideAttribute created by Brecht Lecluyse (www.brechtos.com)
// Modified by: Sebastian Lague
// =========================================================================================

using System;

using UnityEngine;

namespace Project
{
    //Original version of the ConditionalHideAttribute created by Brecht Lecluyse (www.brechtos.com)
    //Modified by: Sebastian Lague

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
	public class ConditionalHideAttribute : PropertyAttribute
	{
		#region Public Field(s):
		public string conditionalSourceField;
		public int enumIndex;
		#endregion

		#region Public API:
		public ConditionalHideAttribute(string _boolVariableName)
		{
			conditionalSourceField = _boolVariableName;
		}

		public ConditionalHideAttribute(string _enumVariableName, int _enumIndex)
		{
			conditionalSourceField = _enumVariableName;
			enumIndex = _enumIndex;
		}
		#endregion
	}
}