// ######################################################################
// Section - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project.Environment
{
	[RequireComponent(typeof(Collider2D))]
	public class Section : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
#if UNITY_EDITOR
		[SerializeField] private bool m_runOnValidate = false;
#endif
		[SerializeField] private int m_sectionNumber;
		[SerializeField] private UnityEngine.Tilemaps.Tilemap m_renderer;
		[SerializeField] private Color m_groundColor = new Color(1f, 1f, 1f, 1f);
		[SerializeField] private bool m_shouldNotChangeStateOnTrigger = false;
		[SerializeField] private List<GameObject> m_activeOnEnterGos;
		#endregion

		#region MonoBehaviour Callback Method(s):
#if UNITY_EDITOR
		private void OnValidate()
		{
			if (!m_runOnValidate) { return; }
			m_renderer.color = m_groundColor;
			m_renderer.transform.name = $"Ground_{m_sectionNumber}";
			m_runOnValidate = false;
		}
#endif
		private void Start()
		{
			GetComponent<Collider2D>().isTrigger = true;
			SetActiveState(false);
		}
		private void OnTriggerEnter2D(Collider2D _collider) => SetActiveState(true);
		private void OnTriggerExit2D(Collider2D _collider) => SetActiveState(false);
		#endregion

		#region Internally Used Method(s):
		private void SetActiveState(bool _state)
		{
			if (m_shouldNotChangeStateOnTrigger) { return; }
			m_activeOnEnterGos.ForEach(x => x.SetActive(_state));
		}
		#endregion
	}
}
