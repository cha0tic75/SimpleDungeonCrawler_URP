// ######################################################################
// Section - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

namespace Project
{
	[RequireComponent(typeof(Collider2D))]
	public class Section : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private int m_sectionNumber;
		[SerializeField] private List<GameObject> m_activeOnEnterGos;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start()
		{
			GetComponent<Collider2D>().isTrigger = true;
			SetActiveState(false);
		}
		private void OnTriggerEnter2D(Collider2D _collider) => SetActiveState(true);
		private void OnTriggerExit2D(Collider2D _collider) => SetActiveState(false);
		#endregion

		#region Internally Used Method(s):
		private void SetActiveState(bool _state) => m_activeOnEnterGos.ForEach(x => x.SetActive(_state));
		#endregion
	}
}
