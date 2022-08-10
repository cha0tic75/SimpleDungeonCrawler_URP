// ######################################################################
// PlayerInventory - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Interaction;
using UnityEngine;

namespace Project.Player
{
	public class PlayerInventory : TransformMonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField] public ItemInteractionHandler m_currentItem = null;
		#endregion

		#region Properties:
		public bool HasItem => m_currentItem != null;
		#endregion

		#region Public API:
		public void AddItem(ItemInteractionHandler _item)
		{
			if (m_currentItem != null) { RemoveItem(m_currentItem); }

			_item.GetComponent<Interactable>().enabled = false;

			m_currentItem = _item;
			m_currentItem.Transform.parent = Transform;
			m_currentItem.Transform.localPosition = Vector3.zero;
		}

		public void RemoveItem(ItemInteractionHandler _item)
		{
			_item.Transform.parent = null;
			_item.GetComponent<Interactable>().enabled = true;
			m_currentItem = null;
		}

		public void AttemptToDropCurrent()
		{
			if (m_currentItem == null) { return; }
			
			RemoveItem(m_currentItem);
		}
		#endregion
	}
}