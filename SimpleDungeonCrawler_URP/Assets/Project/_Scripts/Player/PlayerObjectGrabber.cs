// ######################################################################
// PlayerObjectGrabber - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Core;
using Project.Items;
using UnityEngine;

namespace Project
{
	public class PlayerObjectGrabber : TransformMonoBehaviour
	{	
		#region Inspector Assigned Field(s):
		[SerializeField] private Item m_currentItem = null;
		#endregion

		#region Public API:
		public void AttachItem(Item _item)
		{
			_item.Transform.parent = Transform;
			_item.Transform.localPosition = Vector3.zero;

			m_currentItem = _item;
		}
		public void DropCurrentItem()
		{
			if (m_currentItem == null) { return; }

			Debug.Log("Asked to drop current Item!");

			m_currentItem.Transform.parent = null;
			m_currentItem.Transform.position = Transform.position * 1f;
			m_currentItem = null;
		}
		#endregion
	}
}