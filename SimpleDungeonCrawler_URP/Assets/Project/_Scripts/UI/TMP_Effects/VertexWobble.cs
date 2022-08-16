// ######################################################################
// VertexWobble - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using UnityEngine;

namespace Project.UI.TextEffects
{
    public class VertexWobble : TMP_Effect
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private Vector2 m_wobble = new Vector2(3.3f, 2.5f);
		[SerializeField] private float m_throttleTime = 0.15f;
		#endregion

		#region Internal State Field(s):
		private Coroutine m_wobbleEffectCoroutine = null;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable() => m_wobbleEffectCoroutine = StartCoroutine(WobbleEffectCoroutine());
		private void OnDisable() => HelperMethods.StopCoroutineIfRunning(ref m_wobbleEffectCoroutine, this);
		#endregion

		#region Internally Used Method(s):
			Vector2 Wobble(float _time) => new Vector2(Mathf.Sin(_time * m_wobble.x), Mathf.Cos(_time * m_wobble.y));
		#endregion

		#region Coroutine(s):
		private IEnumerator WobbleEffectCoroutine()
		{
			while (true)
			{
				m_textMesh.ForceMeshUpdate();
				m_mesh = m_textMesh.mesh;
				m_vertices = m_mesh.vertices;

				for (int i = 0; i < m_vertices.Length; i++)
				{
					Vector3 offset = Wobble(Time.time + i);

					m_vertices[i] = m_vertices[i] + offset;
				}

				m_mesh.vertices = m_vertices;
				m_textMesh.canvasRenderer.SetMesh(m_mesh);

				yield return (m_throttleTime > 0f) ? HelperMethods.CustomWFS(m_throttleTime) : null;
			}
		}
		#endregion
	}
}
