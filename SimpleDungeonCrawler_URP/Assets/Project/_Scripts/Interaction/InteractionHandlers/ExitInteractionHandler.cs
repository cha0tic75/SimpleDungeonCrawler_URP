// ######################################################################
// ExitInteractionHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Items;
using Project.Player;
using UnityEngine;

namespace Project.Interaction
{
    public class ExitInteractionHandler : BaseInteractionHandler
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField] public Item_SO RequireditemSO { get; private set; }
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start()
		{
			if (RequireditemSO == null) 
			{
				Debug.LogError($"There is no Item associated with {Transform.name}"); 
				return; 
			}
		} 
		#endregion

		#region Public API:
		public override void HandleInteraction(GameObject _interactor)
		{
			if (_interactor.TryGetComponent<PlayerInventory>(out var inventory))
			{
                if (!inventory.HasItem) { return; }

				if (inventory.CurrentItem.ItemSO == RequireditemSO)
				{
					Destroy(inventory.CurrentItem.gameObject);
					OpenExit();
				}
			}
		}
		#endregion

		#region Internally Used Method(s):
		private void OpenExit()
		{
			// TODO: This should do some sort of animation!
            Invoke("DestroyMe", 0.25f);
		}

        private void DestroyMe()
        {
			Destroy(gameObject);
        }
		#endregion
	}
}