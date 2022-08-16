// ######################################################################
// SpawnPrefabAtEffect_SO - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
    [CreateAssetMenu(menuName = "SO/Effects/Spawn Prefab At Effect", fileName = "New Spawn Prefab At Effect")]
	public class SpawnPrefabAtEffect_SO : BaseEffect_SO
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private GameObject m_prefab;
		#endregion

		#region Public API:
		public override void PerformEffect(GameObject _gameObject)
		{
			if (m_prefab == null) { return; }
			Instantiate(m_prefab, _gameObject.transform.position, Quaternion.identity);
		}
		#endregion
	}
}