// ######################################################################
// PersistentSinglonMonoBehaviour - Generic implementation of a singleton that
//                                  derives from MonoBehaviour with dontdestroyonload
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Utility
{
    public abstract class PersistentSinglonMonoBehaviour<T> : SingletonMonoBehaviour<T> where T : MonoBehaviour
	{
		#region MonoBehaiour Callback Method(s):
		protected override void Awake()
		{
			base.Awake();
			DontDestroyOnLoad(gameObject);
		}
		#endregion
	}
}