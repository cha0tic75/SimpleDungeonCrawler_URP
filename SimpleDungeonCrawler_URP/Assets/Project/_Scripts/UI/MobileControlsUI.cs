// ######################################################################
// MobileControlsUI - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.ui
{
	public class MobileControlsUI : MonoBehaviour
	{
		#region MonoBehaviour Callback Method(s):
		private void Start()
		{
#if !UNITY_ANDROID
			Destroy(gameObject);
#endif
		}
		#endregion
	}
}
