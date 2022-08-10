// ######################################################################
// Item_SO - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Items
{
    [CreateAssetMenu(menuName = "SO/Items/New Item", fileName ="New Item")]
    public class Item_SO : Base_SO
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField] public ItemBehaviour_SO ItemBehaviour { get; private set; }
		[field: SerializeField] public ItemVisualData ItemVisuals { get; private set; }
		#endregion

		#region Support Class(es):
		[System.Serializable]
		public class ItemVisualData
		{
			[field: SerializeField] public Color Color { get; private set; }
		}
		#endregion
	}
}