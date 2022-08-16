// ######################################################################
// TransformMonoBehaviour - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
    public abstract class TransformMonoBehaviour : MonoBehaviour
	{
        #region Properties:
		public Transform Transform { get; protected set; }
        #endregion

        #region Internal State Field(s):
        private Vector3 m_initialPosition;
        #endregion

        #region MonoBehaviour Callback Method(s):
		protected virtual void Awake()
        {
            Transform = transform;
            m_initialPosition = Transform.position;
        }
        #endregion
	}
}