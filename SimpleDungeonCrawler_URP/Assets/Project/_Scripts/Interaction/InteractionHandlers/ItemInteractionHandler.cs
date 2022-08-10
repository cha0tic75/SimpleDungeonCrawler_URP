// ######################################################################
// ItemInteractionHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Items;
using Project.Player;
using UnityEngine;

namespace Project.Interaction
{
    public class ItemInteractionHandler : BaseInteractionHandler
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField] public Item_SO ItemSO { get; private set; }
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start() => GetComponentInChildren<SpriteRenderer>().color = ItemSO.ItemVisuals.Color;
		#endregion

		#region Public API:
		public override void HandleInteraction(GameObject _interactor)
		{
			Debug.Log("ItemInteractionHandler: HandleInteraction");
			if (_interactor.TryGetComponent<PlayerInventory>(out var inventory))
			{
				inventory.AddItem(this);
			}
		}
		#endregion
	}
}