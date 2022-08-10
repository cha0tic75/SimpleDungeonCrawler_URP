// ######################################################################
// TransformMonoBehaviour - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Core
{
    public abstract class TransformMonoBehaviour : MonoBehaviour
	{
        #region Properties:
		public Transform Transform { get; private set; }
        #endregion

        #region MonoBehaviour Callback Method(s):
		protected virtual void Awake() => Transform = transform;
        #endregion
	}
}