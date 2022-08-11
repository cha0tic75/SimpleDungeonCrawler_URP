// ######################################################################
// HelperMethods - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using UnityEngine;

namespace Project
{
	public static class HelperMethods
	{
		#region Internal State Field(s):
		
		#endregion

		#region Public API:
		public static IEnumerator CustomWFS(float _delayTime)
		{
			float timer = 0;
			while (timer < _delayTime)
			{
				timer += Time.deltaTime;
				yield return null;
			}
		}
		#endregion
	}
}