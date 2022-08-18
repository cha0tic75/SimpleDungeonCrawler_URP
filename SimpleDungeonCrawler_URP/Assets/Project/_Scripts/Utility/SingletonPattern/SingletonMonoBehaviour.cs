// ######################################################################
// SingletonMonoBehaviour - Generic implementation of a singleton that
//                          derives from MonoBehaviour
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Utility
{
    [DefaultExecutionOrder(-1)]
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
	{
		#region Properties:
		public static T Instance { get; private set; }
		#endregion

		#region MonoBehaiour Callback Method(s):
		protected virtual void Awake()
		{
			if (Instance != null)
			{
#if UNITY_EDITOR
				DestroyImmediate(this);
#else
				Destroy(gameObject);
#endif
				return;
			}

			Instance = this as T;
		}

		protected virtual private void OnApplicationQuit()
		{
			Instance = null;

			Destroy(this);
		}
		#endregion
	}
}