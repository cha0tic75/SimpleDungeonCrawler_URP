// ######################################################################
// Item - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Items
{
	[RequireComponent(typeof(Collider2D))]
	public class Item : BaseEntity
	{
		#region Internal State Field(s):
		[field: SerializeField] public Item_SO Item_SO { get; private set; }
		[SerializeField] private SpriteRenderer m_spriteRenderer;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start()
		{
			if (m_spriteRenderer != null && Item_SO != null)
			{
				m_spriteRenderer.color = Item_SO.ItemVisuals.Color;
			}
		}
		#endregion

		#region Public API:

		#endregion
	}
}