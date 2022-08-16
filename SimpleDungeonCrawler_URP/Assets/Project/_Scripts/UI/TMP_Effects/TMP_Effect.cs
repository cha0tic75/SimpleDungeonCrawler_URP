// ######################################################################
// TMP_Effect - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;
using TMPro;

namespace Project.UI.TextEffects
{
    [RequireComponent(typeof(TMP_Text))]
	public abstract class TMP_Effect : MonoBehaviour
	{
		#region Internal State Field(s):
		protected TMP_Text m_textMesh;
		protected Mesh m_mesh;
		protected Vector3[] m_vertices;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Awake() => m_textMesh = GetComponent<TMP_Text>();
		#endregion
	}
}
