// ######################################################################
// PlayerInventory - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Player
{
	public class PlayerInventory : TransformMonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private PlayerController m_controller;
		[SerializeField] private float m_radius = 0.4f;
		[SerializeField] private LayerMask m_layerMask;
#if UNITY_EDITOR
		[ReadOnly]
#endif
		[SerializeField]private Items.Item m_currentItem;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable()
		{
			if (m_controller == null)
			{
				m_controller = GetComponentInParent<PlayerController>();
			}
			m_controller.OnItemInteractionEvent += Controller_OnItemInteractionCallback;
		}
		private void OnDisable() => m_controller.OnItemInteractionEvent -= Controller_OnItemInteractionCallback;
		#endregion

		#region Inspector Assigned Field(s):
		private void Controller_OnItemInteractionCallback()
		{
			if (m_currentItem == null) { CheckForItemToPickup(); }
			else { DropItem();}
		}
		#endregion

		#region Internally Used Method(s):
		private void CheckForItemToPickup()
		{
			Collider2D itemCollider = Physics2D.OverlapCircle(Transform.position, m_radius, m_layerMask);

			if (itemCollider != null)
			{
				PickupItem(itemCollider.GetComponent<Items.Item>());
			}
		}

		private void PickupItem(Items.Item _item)
		{
			m_currentItem = _item;
			m_currentItem.Transform.parent = Transform;
			m_currentItem.transform.localPosition = Vector3.zero;
		}
		private void DropItem()
		{
			m_currentItem.Transform.parent = null;
			m_currentItem = null;
		}
		#endregion
	}
}