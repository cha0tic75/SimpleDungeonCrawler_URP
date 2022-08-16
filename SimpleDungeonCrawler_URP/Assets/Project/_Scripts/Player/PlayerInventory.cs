// ######################################################################
// PlayerInventory - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Interaction;
using UnityEngine;

namespace Project.Player
{
    public class PlayerInventory : TransformMonoBehaviour, IResetable
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField, ReadOnly] public ItemInteractionHandler CurrentItem { get; private set;} = null;
		#endregion

		#region Properties:
		public bool HasItem => CurrentItem != null;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start() { } // This is just here to expose the enable/disable toggle in inspector
		#endregion

		#region Public API:
		public void AddItem(ItemInteractionHandler _item)
		{
			if (CurrentItem != null) { RemoveItem(CurrentItem); }

			CurrentItem = _item;
			CurrentItem.transform.parent = Transform;
			CurrentItem.transform.localPosition = Vector3.zero;
			CurrentItem.gameObject.layer = LayerMask.NameToLayer("Default");
		}

		public void RemoveItem(ItemInteractionHandler _item)
		{
			_item.transform.parent = null;
			_item.gameObject.layer = LayerMask.NameToLayer("Interactable");
			CurrentItem = null;
		}

		public void AttemptToDropCurrent()
		{
			if (CurrentItem == null) { return; }
			
			RemoveItem(CurrentItem);
		}

		public override void Reset() => CurrentItem = null;
		#endregion
	}
}